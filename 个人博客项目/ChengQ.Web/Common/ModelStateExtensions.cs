using ChengQ.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChengQ.Web.Common
{
    public static class ModelStateExtensions
    {

        /// <summary>
        /// 获取所有的Model验证错误信息
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static IEnumerable<ModelStateError> AllModelStateErrors(this ModelStateDictionary modelState)
        {
            var ModelStateError_result = new List<ModelStateError>();
            //找到出错的字段以及出错信息
            var errorFieldsAndMsgs = modelState.Where(m => m.Value.Errors.Any()).Select(x => new
            {
                x.Key,
                x.Value.Errors
            });

            foreach (var item in errorFieldsAndMsgs)
            {

                //获取键
                var fieldKey = item.Key;
                //获取键对应的错误信息
                var fieldErrors = item.Errors.Select(e => new ModelStateError(fieldKey, string.IsNullOrWhiteSpace(e.ErrorMessage) ? e.Exception?.Message : e.ErrorMessage));
                ModelStateError_result.AddRange(fieldErrors);
            }
            return ModelStateError_result;
        }




        public static Response GetAllModelStateErrors(this Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            Response response = new Response(ResponseCode.ReqInvalidParameter, "");

            var ModelStateError_result = new List<ModelStateError>();
            //找到出错的字段以及出错信息
            var errorFieldsAndMsgs = modelState.Where(m => m.Value.Errors.Any()).Select(x => new
            {
                x.Key,
                x.Value.Errors
            });

            foreach (var item in errorFieldsAndMsgs)
            {
                //获取键
                var fieldKey = item.Key;
                //获取键对应的错误信息
                var fieldErrors = item.Errors.Select(e => new ModelStateError(fieldKey, string.IsNullOrWhiteSpace(e.ErrorMessage) ? e.Exception?.Message : e.ErrorMessage));
                ModelStateError_result.AddRange(fieldErrors);
            }
            response.data = ModelStateError_result;
            ModelStateError_result.ForEach(x => response.message += x.Message + ";");
            return response;
        }

    }

    public class ModelStateError
    {

        public ModelStateError(string key, string msg)
        {
            Key = key;
            Message = msg;
        }
        public string Key { get; set; }
        public string Message { get; set; }

    }
}

