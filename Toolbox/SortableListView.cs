using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project.Toolbox
{
    public class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;

        private SortOrder OrderOfSort;

        private CaseInsensitiveComparer ObjectCompare;

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object? x, object? y)
        {
            if (x == null || y == null) return 0;
            int compareResult;
            ListViewItem listviewX, listviewY;
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }

    public class SortableListView : ListView
    {
        private readonly string ARROWUP = "▲";
        private readonly string ARROWDOWN = "▼";
        private readonly string SPACING = "    ";

        private ListViewColumnSorter sorter = new ListViewColumnSorter();

        public SortableListView() : base()
        {
            ListViewItemSorter = sorter;
            ColumnClick += Sort;
        }

        private void Sort(object? sender, ColumnClickEventArgs? e)
        {
            
            foreach (ColumnHeader col in this.Columns)
            {
                if (col.Text.EndsWith(ARROWUP) || col.Text.EndsWith(ARROWDOWN)) col.Text = col.Text[..^(SPACING.Length+1)];
            }
            if (e.Column == sorter.SortColumn)
            {
                if (sorter.Order == SortOrder.Ascending)
                {
                    sorter.Order = SortOrder.Descending;
                    ColumnHeader h = Columns[e.Column];
                    h.Text += SPACING + ARROWUP;
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                    ColumnHeader h = Columns[e.Column];
                    h.Text += SPACING + ARROWDOWN;
                }
            }
            else
            {
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
                ColumnHeader h = Columns[e.Column];
                h.Text += SPACING + ARROWDOWN;
            }
            Sort();
        }
    }
}
