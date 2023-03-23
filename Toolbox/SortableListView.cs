using System.Collections;

namespace final_programming_project.Toolbox;

public class ListViewColumnSorter : IComparer
{
    private readonly CaseInsensitiveComparer ObjectCompare;

    public ListViewColumnSorter()
    {
        SortColumn = 0;
        Order = SortOrder.None;
        ObjectCompare = new CaseInsensitiveComparer();
    }

    public int SortColumn { set; get; }

    public SortOrder Order { set; get; }

    public int Compare(object? x, object? y)
    {
        if (x == null || y == null) return 0;
        int compareResult;
        ListViewItem listviewX, listviewY;
        listviewX = (ListViewItem)x;
        listviewY = (ListViewItem)y;
        compareResult = ObjectCompare.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);
        if (Order == SortOrder.Ascending)
            return compareResult;
        if (Order == SortOrder.Descending)
            return -compareResult;
        return 0;
    }
}

public class SortableListView : ListView
{
    private readonly string ARROWDOWN = "▼";
    private readonly string ARROWUP = "▲";
    private readonly string SPACING = "    ";

    private readonly ListViewColumnSorter sorter = new();

    public SortableListView()
    {
        ListViewItemSorter = sorter;
        ColumnClick += Sort;
    }

    private void Sort(object? sender, ColumnClickEventArgs? e)
    {
        foreach (ColumnHeader col in Columns)
            if (col.Text.EndsWith(ARROWUP) || col.Text.EndsWith(ARROWDOWN))
                col.Text = col.Text[..^(SPACING.Length + 1)];
        if (e.Column == sorter.SortColumn)
        {
            if (sorter.Order == SortOrder.Ascending)
            {
                sorter.Order = SortOrder.Descending;
                var h = Columns[e.Column];
                h.Text += SPACING + ARROWUP;
            }
            else
            {
                sorter.Order = SortOrder.Ascending;
                var h = Columns[e.Column];
                h.Text += SPACING + ARROWDOWN;
            }
        }
        else
        {
            sorter.SortColumn = e.Column;
            sorter.Order = SortOrder.Ascending;
            var h = Columns[e.Column];
            h.Text += SPACING + ARROWDOWN;
        }

        Sort();
    }
}