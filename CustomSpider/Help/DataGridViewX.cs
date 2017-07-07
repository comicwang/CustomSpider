using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomSpider
{
    public static class DataGridViewX
    {
        public static int Find(this DataGridView grid, string text)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                int index = Find(grid, text, i);
                if (index >= 0)
                    return index;
            }
            return -1;
        }

        public static int Find(this DataGridView grid, string text, int columnIndex)
        {
            IEnumerable<DataGridViewRow> enumerableList = grid.Rows.Cast<DataGridViewRow>();
            DataGridViewRow list = (from item in enumerableList
                                    where item.Cells[columnIndex].Value != null && item.Cells[columnIndex].Value.ToString() == text
                                    select item).FirstOrDefault();
            if (list != null)
                return list.Index;
            return -1;
        }

        public static int Match(this DataGridView grid, string text, int columnIndex)
        {
            IEnumerable<DataGridViewRow> enumerableList = grid.Rows.Cast<DataGridViewRow>();
           DataGridViewRow list = (from item in enumerableList
                                          where item.Cells[columnIndex].Value!=null&&item.Cells[columnIndex].Value.ToString().Contains(text)
                                          select item).FirstOrDefault();
            if (list != null)
                return list.Index;
            return -1;
        }

        public static int Match(this DataGridView grid, string text)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                int index = Match(grid, text, i);
                if (index >= 0)
                    return index;
            }
            return -1;
        }
    }
}
