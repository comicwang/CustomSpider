using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CustomSpider
{
    public class ContentSaver
    {
        public static void Save(string forlder, byte[] buffer, SaveType saveType,string filefilter)
        {
            switch (saveType)
            {
                case SaveType.文本内容:
                    break;
                case SaveType.文件:
                    string path = Path.Combine(forlder,Guid.NewGuid().ToString() + filefilter);
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
    }
}
