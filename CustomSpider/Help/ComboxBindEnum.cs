using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace CustomSpider
{
    /// <summary>
    /// 扩展Combobox和DataGridViewComboBoxColumn绑定Enum类型
    /// 这里的Enum类型必须按照从0开始的顺序赋值
    /// </summary>
    public static class ComboxBindEnum
    {
        /// <summary>
        /// 将Enum类型绑定到combobox
        /// </summary>
        /// <typeparam name="T">任意Enum</typeparam>
        /// <param name="combobox">宿主</param>
        public static void Bind<T>(this ComboBox combobox)
        {
            if (typeof(T).IsEnum == false)
                return;
            combobox.DataSource = System.Enum.GetNames(typeof(T));  
        }

        /// <summary>
        /// 设置combobox的值
        /// </summary>
        /// <typeparam name="T">任意Enum</typeparam>
        /// <param name="combobox">宿主</param>
        /// <param name="seter">Enum的值</param>
        public static void Set<T>(this ComboBox combobox, T seter)
        {
            if (typeof(T).IsEnum == false)
                return;
            combobox.SelectedIndex = combobox.FindString(seter.ToString());
        }

       
        /// <summary>
        /// 获取Enum的值
        /// </summary>
        /// <typeparam name="T">任意Enum</typeparam>
        /// <param name="combobox">宿主</param>
        /// <returns>Enum的值</returns>
        public static T Get<T>(this ComboBox combobox)
        {
            if (typeof(T).IsEnum == false)
                return default(T);
            return (T)Enum.Parse(typeof(T), combobox.SelectedItem.ToString(), false);
        }

        /// <summary>
        /// 将Enum类型绑定到comboColumn
        /// </summary>
        /// <typeparam name="T">任意Enum</typeparam>
        /// <param name="comboColumn">宿主</param>
        public static void Bind<T>(this DataGridViewComboBoxColumn comboColumn)
        {
            if (typeof(T).IsEnum == false)
                return;
            comboColumn.DataSource = System.Enum.GetNames(typeof(T)); 
        }

        /// <summary>
        /// 设置Enum值到DataGridViewComboBoxColumn
        /// </summary>
        /// <typeparam name="T">任意Enum</typeparam>
        /// <param name="combobox">宿主</param>
        /// <param name="seter">Enum的值</param>
        /// <param name="rowIndex">需要赋值的行号</param>
        public static void Set<T>(this DataGridViewComboBoxColumn combobox, T seter,int rowIndex)
        {
            if (typeof(T).IsEnum == false)
                return;
            combobox.DataGridView[combobox.Index, rowIndex].Value = seter;
        }

        /// <summary>
        /// 获取DataGridViewComboBoxColumn的枚举值
        /// </summary>
        /// <typeparam name="T">任意Enum</typeparam>
        /// <param name="combobox">宿主</param>
        /// <param name="rowIndex">需要获取的行号</param>
        /// <returns>Enum的值</returns>
        public static T Get<T>(this DataGridViewComboBoxColumn combobox, int rowIndex)
        {
            if (typeof(T).IsEnum == false)
                return default(T);
            return (T)Enum.Parse(typeof(T), combobox.DataGridView[combobox.Index, rowIndex].Value.ToString(), false);
        }
    }
}
