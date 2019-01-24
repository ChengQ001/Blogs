using System;
using System.Collections.Generic;
using System.Text;

namespace ChengQ.Common 
{
   public  class ResponseCode
    {
        #region 响应错误

        /// <summary>
        /// 请求处理成功代码
        /// </summary>
        public const int RspSuccessed = 0;
        /// <summary>
        /// 系统内部异常
        /// </summary>
        public const int RspException = -1;
        /// <summary>
        /// 系统处理失败
        /// </summary>
        public const int RspFailed = 9999;
        /// <summary>
        /// 无数据返回
        /// </summary>
        public const int RspEmpty = 9998;
        /// <summary>
        /// 已存在数据
        /// </summary>
        public const int RspExists = 9997;

        /// <summary>
        /// 　电费付款时订单不存在或订单状态为已付款或已作废
        /// </summary>
        public const int RspOrderNoExists = 9999;

        #endregion
        #region 请求错误

        /// <summary>
        /// 请求发生错误，如请求动词不正确
        /// </summary>
        public const int ReqError = 1000;
        /// <summary>
        /// 不合法的调用凭证
        /// </summary>
        public const int ReqInvalidCredential = 1001;
        /// <summary>
        /// 不合法的token
        /// </summary>
        public const int ReqInvalidToken = 1002;
        /// <summary>
        /// 接口未授权
        /// </summary>
        public const int ReqUnauthorized = 1003;
        /// <summary>
        /// 请求参数无效
        /// </summary>
        public const int ReqInvalidParameter = 1004;
        /// <summary>
        /// 请求参数签名不正确
        /// </summary>
        public const int ReqInvalidSignature = 1005;
        /// <summary>
        /// 请求需要登录，登录超时
        /// </summary>
        public const int ReqLoginRequired = 1006;

        /// <summary>
        /// 阿里实名错误
        /// </summary>
        public const int ReqAli = 1007;

        /// <summary>
        /// 门禁权限过期
        /// </summary>
        public const int ReqPast = 1008;

        /// <summary>
        /// 用户未实名认证
        /// </summary>
        public const int ReqRealNameNonAuthen = 1009;


        /// <summary>
        /// 已过期
        /// </summary>
        public const int ReqTimeOut = 1010;


        #endregion
    }
}
