using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomSpider
{
    /// <summary>
    /// 扩展DatagridView,用于方便搜索功能
    /// </summary>
    public static class DataGridViewX
    {
        /// <summary>
        /// 在所有内容中寻找关键所在行
        /// 未找到返回-1,找到默认返回第一个数据
        /// </summary>
        /// <param name="grid">宿主</param>
        /// <param name="keyword">关键字</param>
        /// <returns>行号</returns>
        public static int Find(this DataGridView grid, string keyword)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                int index = Find(grid, keyword, i);
                if (index >= 0)
                    return index;
            }
            return -1;
        }

        /// <summary>
        /// 在固定某列中寻找关键字所在行
        /// 未找到返回-1,找到默认返回第一个数据
        /// </summary>
        /// <param name="grid">宿主</param>
        /// <param name="keyword">关键字</param>
        /// <param name="columnIndex">固定的列号</param>
        /// <returns>行号</returns>
        public static int Find(this DataGridView grid, string keyword, int columnIndex)
        {
            IEnumerable<DataGridViewRow> enumerableList = grid.Rows.Cast<DataGridViewRow>();
            DataGridViewRow list = (from item in enumerableList
                                    where item.Cells[columnIndex].Value != null && item.Cells[columnIndex].Value.ToString() == keyword
                                    select item).FirstOrDefault();
            if (list != null)
                return list.Index;
            return -1;
        }

        /// <summary>
        /// 在固定某列中寻找关键字所在行(模糊寻找)
        /// 未找到返回-1,找到默认返回第一个数据
        /// </summary>
        /// <param name="grid">宿主</param>
        /// <param name="keyword">关键字</param>
        /// <param name="columnIndex">固定的列号</param>
        /// <returns>行号</returns>
        public static int Match(this DataGridView grid, string keyword, int columnIndex)
        {
            IEnumerable<DataGridViewRow> enumerableList = grid.Rows.Cast<DataGridViewRow>();
           DataGridViewRow list = (from item in enumerableList
                                          where item.Cells[columnIndex].Value!=null&&item.Cells[columnIndex].Value.ToString().Contains(keyword)
                                          select item).FirstOrDefault();
            if (list != null)
                return list.Index;
            return -1;
        }

        /// <summary>
        /// 在所有内容中寻找关键所在行(模糊寻找)
        /// 未找到返回-1,找到默认返回第一个数据
        /// </summary>
        /// <param name="grid">宿主</param>
        /// <param name="keyword">关键字</param>
        /// <returns>行号</returns>
        public static int Match(this DataGridView grid, string keyword)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                int index = Match(grid, keyword, i);
                if (index >= 0)
                    return index;
            }
            return -1;
        }
    }
}
