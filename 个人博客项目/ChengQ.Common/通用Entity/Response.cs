using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Common 
{
    public class Response : Response<object>
    {
        public Response() : base() { }
        public Response(int rsp_code, string rsp_message) : base(rsp_code, rsp_message)
        {
        }
        public Response(int rsp_code, object rsp_data, string rsp_message) : base(rsp_code, rsp_data, rsp_message)
        {
        }

    }
    public class Response<T>
    {
        /// <summary>
        /// 返回代码 0代表成功 其它的见代码表 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回JSON字符串
        /// </summary>
        public T data { get; set; }

        public Response(int rsp_code, string rsp_message)
        {
            this.code = rsp_code;
            this.message = rsp_message;
        }
        public Response(int rsp_code, T rsp_data, string rsp_message)
        {
            this.data = rsp_data;
            this.code = rsp_code;
            this.message = rsp_message;
        }
        /// <summary>
        /// 默认失败
        /// </summary>
        public Response()
        {
            this.code = ResponseCode.RspFailed;
            this.message = ResponseMsg.RspFailed;
        }
    }
}
