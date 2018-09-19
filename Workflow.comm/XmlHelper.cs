﻿

/****************************************************************************
* 类名：XmlHelper
* 描述：对接XML文件进行序列化和反序列
* 创建人：李文龙
* 创建时间：2018.05.04 
* 修改人;李文龙
* 修改时间：2018.05.04
* 修改描述：添加反射及读写分离的数据库操作
* **************************************************************************
*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Workflow.comm
{
    public static class XmlHelper
    {
        private static void XmlSerializeInternal(Stream stream, object o, Encoding encoding, bool isDefault)
        {
            try
            {
                if (o == null) throw new ArgumentNullException("o");
                if (encoding == null) throw new ArgumentNullException("encoding");

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                if (!isDefault) ns.Add("", "");

                XmlSerializer serializer = new XmlSerializer(o.GetType());
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineChars = "\r\n";
                settings.Encoding = encoding;
                settings.IndentChars = "    ";

                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, o, ns);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将一个对象序列化为XML字符串 /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>序列化产生的XML字符串</returns> 
        public static string XmlSerialize(object o, Encoding encoding, bool isDefault)
        {
            isDefault = true;
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializeInternal(stream, o, encoding, isDefault);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 将一个对象按XML序列化的方式写入到一个文件 /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">保存文件路径</param>
        /// <param name="encoding">编码方式</param> 
        public static void XmlSerializeToFile(object o, string path, Encoding encoding, bool isDefault)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");

            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializeInternal(file, o, encoding, isDefault);
            }
        }

        /// <summary>
        /// 从XML字符串中反序列化对象 /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="s">包含对象的XML字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserialize<T>(string s, Encoding encoding) where T : class, new()
        {
            try
            {
                if (string.IsNullOrEmpty(s)) throw new ArgumentNullException("s");
                if (encoding == null) throw new ArgumentNullException("encoding");

                XmlSerializer mySerializer = new XmlSerializer(typeof(T));
                using (MemoryStream ms = new MemoryStream(encoding.GetBytes(s)))
                {
                    using (StreamReader sr = new StreamReader(ms, encoding))
                    {
                        return (T)mySerializer.Deserialize(sr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读入一个文件，并按XML的方式反序列化对象。 /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="path">文件路径</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns> 
        public static T XmlDeserializeFromFile<T>(string path, Encoding encoding) where T : class, new()
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
            if (encoding == null) throw new ArgumentNullException("encoding");

            string xml = File.ReadAllText(path, encoding);

            return XmlDeserialize<T>(xml, encoding);
        }
    }
}
