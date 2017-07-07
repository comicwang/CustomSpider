using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace CustomSpider
{
    public static class ComboxBindEnum
    {
        public static void Bind<T>(this ComboBox combobox)
        {
            if (typeof(T).IsEnum == false)
                return;
            combobox.DataSource = System.Enum.GetNames(typeof(T));  
        }

        public static void Set<T>(this ComboBox combobox, T seter)
        {
            if (typeof(T).IsEnum == false)
                return;
            combobox.SelectedIndex = combobox.FindString(seter.ToString());
        }

        public static T Get<T>(this ComboBox combobox)
        {
            if (typeof(T).IsEnum == false)
                return default(T);
            return (T)Enum.Parse(typeof(T), combobox.SelectedItem.ToString(), false);
        }

        public static void Bind<T>(this DataGridViewComboBoxColumn comboColumn)
        {
            if (typeof(T).IsEnum == false)
                return;
            comboColumn.DataSource = System.Enum.GetNames(typeof(T)); 
        }

        public static void Set<T>(this DataGridViewComboBoxColumn combobox, T seter,int rowIndex)
        {
            if (typeof(T).IsEnum == false)
                return;
            combobox.DataGridView[combobox.Index, rowIndex].Value = seter;
        }

        public static T Get<T>(this DataGridViewComboBoxColumn combobox, int rowIndex)
        {
            if (typeof(T).IsEnum == false)
                return default(T);
            return (T)Enum.Parse(typeof(T), combobox.DataGridView[combobox.Index, rowIndex].Value.ToString(), false);
        }
    }
}
