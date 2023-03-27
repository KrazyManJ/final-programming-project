using System.Collections;
using System.Text.RegularExpressions;

namespace final_programming_project.Toolbox;

public class AlphanumericComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        string[] partsX = Regex.Split(x, "([0-9]+)");
        string[] partsY = Regex.Split(y, "([0-9]+)");

        int i = 0;
        while (i < partsX.Length && i < partsY.Length)
        {
            if (partsX[i] != partsY[i])
            {
                if (int.TryParse(partsX[i], out int resultX) && int.TryParse(partsY[i], out int resultY))
                {
                    return resultX.CompareTo(resultY);
                }
                return string.Compare(partsX[i], partsY[i], StringComparison.OrdinalIgnoreCase);
            }
            i++;
        }

        if (partsX.Length != partsY.Length)
        {
            return partsX.Length.CompareTo(partsY.Length);
        }
        else
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }
}

public class ListViewColumnSorter : IComparer
{
    private readonly AlphanumericComparer ObjectCompare;

    public ListViewColumnSorter()
    {
        SortColumn = 0;
        Order = SortOrder.None;
        ObjectCompare = new AlphanumericComparer();
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