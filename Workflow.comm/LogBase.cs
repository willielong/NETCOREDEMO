using log4net;
using log4net.Core;
using log4net.Layout;
using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Workflow.comm
{

    /// <summary>
    /// 日志继承类
    /// </summary>
    public class LogBase<T> where T : class
    {
        //private ILog _Log;
        public static ILog Log { get { return LogManager.GetLogger(ServiceLocator.log4netRepositoryName, typeof(T)); } }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="IP">连接服务器的IP地址</param>
        /// <param name="Name">用户名</param>
        /// <param name="Action">调用的方法</param>
        public static void Error(string message, string Action = "")
        {
            // LogInfo info = new LogInfo(ServiceLocator.Ip, ServiceLocator.currentUser, Action, message);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("当前客户端Ip地址:[{0}];", ServiceLocator.Ip);
            sb.AppendFormat("当前用户:[{0}];", ServiceLocator.currentUser);
            sb.AppendFormat("出现错误的方法:{0};", Action);
            sb.AppendFormat("错误信息:{0};", message);
            Log.Error(sb);
        }

        public static void Fatal(string message, string Action = "")
        {
#if DEBUG
            LogInfo info = new LogInfo(ServiceLocator.Ip, ServiceLocator.currentUser, Action, message);
            Log.Fatal(info);
#endif
        }

        public static void Info(string message, string Action = "")
        {
#if DEBUG
            LogInfo info = new LogInfo(ServiceLocator.Ip, ServiceLocator.currentUser, Action, message);
            Log.Info(info);
#endif
        }

        public static void Warn(string message, string Action = "")
        {
#if DEBUG
            LogInfo info = new LogInfo(ServiceLocator.Ip, ServiceLocator.currentUser, Action, message);
            Log.Warn(info);
#endif
        }
    }

    /// <summary>
    /// 进行级别定义
    /// </summary>
    public enum LogLeve
    {
        Debug,
        Warn,
        Info,
        Fine,
        Error,
    }

    /// <summary>
    /// 定义自定义日志实体类
    /// </summary>
    public class LogInfo
    {
        public LogInfo()
        {
        }

        public LogInfo(string _ip, string _name, string _action, string _message)
        {
            this.ip = _ip;
            this.name = _name;
            this.action = _action;
            this.message = _message;
        }
        /// <summary>
        /// 访问IP
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// 系统登陆用户
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 动作事件
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// 日志描述信息
        /// </summary>
        public string message { get; set; }

    }

    /// <summary>
    /// 自定义日志转换
    /// </summary>
    public class CustomLayout : PatternLayout
    {
        public CustomLayout()
        {
            this.AddConverter("property", typeof(CustomPatternConverter));
        }
    }

    /// <summary>
    /// 自定义日志转换方法
    /// </summary>
    public class CustomPatternConverter : PatternLayoutConverter
    {

        protected override void Convert(System.IO.TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            if (Option != null)
            {
                // Write the value for the specified key
                WriteObject(writer, loggingEvent.Repository, LookupProperty(Option, loggingEvent));
            }
            else
            {
                // Write all the key value pairs
                WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
            }
        }

        /// <summary>
        /// 通过反射获取传入的日志对象的某个属性的值
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private object LookupProperty(string property, log4net.Core.LoggingEvent loggingEvent)
        {
            object propertyValue = string.Empty;
            PropertyInfo propertyInfo = loggingEvent.MessageObject.GetType().GetProperty(property);
            if (propertyInfo != null)
                propertyValue = propertyInfo.GetValue(loggingEvent.MessageObject, null);
            return propertyValue;
        }
    }

}
