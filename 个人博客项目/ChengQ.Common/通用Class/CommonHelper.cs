using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ChengQ.Common
{
  public static class CommonHelper
    {
        public static string CheckInputStr(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            //s = s.Trim().ToLower();
            s = s.Replace("=", "");
            s = s.Replace("'", "");
            s = s.Replace(";", "");
            s = s.Replace(" or ", "");
            s = s.Replace("select", "");
            s = s.Replace("update", "");
            s = s.Replace("insert", "");
            s = s.Replace("delete", "");
            s = s.Replace("declare", "");
            s = s.Replace("exec", "");
            s = s.Replace("drop", "");
            s = s.Replace("create", "");
            s = s.Replace("%", "");
            s = s.Replace("--", "");
            return s;
        }
        /// <summary>
        /// model默认初始值
        /// </summary>
        /// <param name="model"></param>
        public static void InitObject(object model)
        {
            #region
            try
            {
                foreach (PropertyInfo property in model.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance))
                {
                    if (property.PropertyType.FullName.ToLower() == "System.String".ToLower() && property.GetValue(model) == null)
                    {
                        property.SetValue(model, "", null);
                    }
                }
            }
            catch (Exception)
            { }
            #endregion
        }
    }
}
