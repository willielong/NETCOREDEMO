using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Workflow.comm
{
    public static class ConstantHelper
    { /// <summary>
      /// 获取枚举名称
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="typeValue"></param>
      /// <returns></returns>
        public static string GetEnumValue<T>(int? typeValue)
        {
            if (!typeValue.HasValue) return "未知类型";

            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                return "未知类型";
            }

            return Enum.GetName(enumType, typeValue.Value);
        }
        /// <summary>
        /// 将枚举转换成集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumTypes> GetEnumValue<T>()
        {
            List<EnumTypes> EnumTypes = new List<EnumTypes>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                EnumTypes types = new EnumTypes();
                types.name = item.ToString();
                types.value = ((int)item).ToString();
                EnumTypes.Add(types);
            }
            return EnumTypes;
        }
        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeValue"></param>
        /// <returns></returns>
        public static int ConvertIntFromEnum<T>(string typeValue)
        {
            Type enumType = typeof(T);
            return (int)Enum.Parse(enumType, typeValue);
        }
        /// <summary>
        /// 根据枚举值装换对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typfValue"></param>
        /// <returns></returns>
        public static T ConvertEnumByValue<T>(string typeValue)
        {
            Type enumType = typeof(T);
            return (T)Enum.Parse(enumType, typeValue);
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static DBHelper GetDbBaseConnection()
        {
            DBHelper dbConnection = new DBHelper();
            IConfigFile con = new GeneralConfFileOperator();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Config", "DBHelper.xml");
            dbConnection = con.ReadConfFile<DBHelper>(path, false);
            return dbConnection;
        }
    }

    /// <summary>
    /// 转换成枚举列表
    /// </summary>
    public class EnumTypes
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    
}
