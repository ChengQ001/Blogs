using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Common 
{
    public class DataInfo
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string src { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string title { get; set; }

    }
    public  class UploadImgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataInfo data { get; set; }
    }
}
