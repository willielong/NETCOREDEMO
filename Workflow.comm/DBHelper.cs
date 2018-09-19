/****************************************************************************
* 类名：DBHelper
* 描述：保存数据连接到配置文件
* 创建人：Author
* 创建时间：2018.05.04 
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：添加反射及读写分离的数据库操作
* **************************************************************************
*/


using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Workflow.comm
{
    [XmlRoot("DBHELPER")]
    public class DBHelper
    {
        /// <summary>
        /// 数据库写入配置-MSSQL
        /// </summary>
        [XmlElement("MS_WRITE_CONNECTION")]
        public string ms_write_connection { get; set; }
        /// <summary>
        /// 数据库读取配置-MSSQL
        /// </summary>
        [XmlElement("MS_READ_CONNECTION")]
        public string ms_read_connection { get; set; }

        /// <summary>
        /// 数据库写入配置-MYSQL
        /// </summary>
        [XmlElement("MY_WRITE_CONNECTION")]
        public string my_write_connection { get; set; }
        /// <summary>
        /// 数据库读取配置-MYSQL
        /// </summary>
        [XmlElement("MY_READ_CONNECTION")]
        public string my_read_connection { get; set; }

        /// <summary>
        /// 数据库写入配置-Oracle
        /// </summary>
        [XmlElement("OC_WRITE_CONNECTION")]
        public string oc_write_connection { get; set; }
        /// <summary>
        /// 数据库读取配置-Oracle
        /// </summary>
        [XmlElement("OC_READ_CONNECTION")]
        public string oc_read_connection { get; set; }
    }
}
