using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Common 
{
    public static class ResponseMsg
    {   /// <summary>
        /// 成功
        /// </summary>
        public const string RspSuccessed = "成功";

        /// <summary>
        /// 系统忙，请稍后再试!
        /// </summary>
        public const string RspException = "系统忙，请稍后再试!";

        /// <summary>
        /// 无权限访问，请求该资源未被授权
        /// </summary>
        public const string ReqUnauthorized = "无权限访问，请求该资源未被授权";

        /// <summary>
        /// 请求参数有误
        /// </summary>
        public const string ReqInvalidParameter = "请求参数有误";

        public const string RspFailed = "操作失败，请稍后再试!";
    }
}
