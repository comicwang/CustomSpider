using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomSpider
{
    public enum SaveType
    {
        文本内容 = 0,
        文件 = 1,
        表格 = 2,
        数据库 = 3
    }

    public enum DataType
    {
        文本 = 0,
        图片 = 1,
        视频 = 2
    }

    public enum SpiderState
    {
        等待中 = 0,
        准备爬取 = 1,
        爬取中 = 2,
        已完成 = 3,
        失败 = 4,
        取消 = 5
    }

    public enum SpiderType
    {
        BaiduBitmap,

        CustiomCatch
    }
}
