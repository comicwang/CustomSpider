using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CustomSpider
{
    /// <summary>
    /// 保存爬取内容的策略
    /// </summary>
    public class ContentSaver
    {
        /// <summary>
        /// 保存内容
        /// </summary>
        /// <param name="forlder">文件根目录</param>
        /// <param name="buffer">缓存内容</param>
        /// <param name="saveType">保存方式</param>
        /// <param name="fileName">文件名称</param>
        public static void Save(string forlder, byte[] buffer, SaveType saveType,string fileName)
        {
            switch (saveType)
            {
                case SaveType.文本内容:
                    break;
                case SaveType.文件:                  
                    string path = Path.Combine(forlder, fileName.Split('.')[1], fileName);
                    MyConsole.AppendLine(string.Format("正在写入{0}到本地目录{1},写入时间:{2}", fileName, path, DateTime.Now));
                    CheckForlder(path);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    break;
                case SaveType.表格:
                    break;
                case SaveType.数据库:
                    break;
                default:
                    break;
            }
        }

        private static void CheckForlder(string path)
        {
            string forlder = Path.GetDirectoryName(path);
            if (!Directory.Exists(forlder))
                Directory.CreateDirectory(forlder);
        }
    }
}
