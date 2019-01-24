using Microsoft.Extensions.Configuration;
using System.IO;

namespace ChengQ.Common
{
    public class ReadConfig
    {
        public string path
        {
            get
            {
                return "Config/databaseconfig.json";
            }
        }
        private IConfigurationRoot configurationBuilder;
        /// <summary>
        /// 相对路径 如：Config/databaseconfig.json
        /// </summary>
        /// <param name="_path"></param>
        public ReadConfig(string _path)
        {
            //var configBasePath = Directory.GetCurrentDirectory();
            configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(_path).Build();
        }

        /// <summary>
        /// 读取数据库配置
        /// </summary>
        /// <returns></returns>
        public static string ReadConnect()
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Config/databaseconfig.json").Build().GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        /// <summary>
        /// 通过name 获取value
        /// ConnectionStrings
        /// ConnectionStrings:DefaultConnection 节点下的子节点
        /// ConnectionStrings:Item:name 节点下的子节点下的 子节点
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public string ReadSectionValue(string sectionName)
        {
            return configurationBuilder.GetSection(sectionName).Value;
        }
    }
}
