using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Workflow.comm
{
    [XmlRoot("TOKENHELPER")]
    public class TokenHelper
    {
        /// <summary>
        /// 私钥
        /// </summary>
        [XmlElement("TOKENSECRE_KEY")]
        public string TokenSecreKey { get; set; }

        /// <summary>
        /// 发行人
        /// </summary>
        [XmlElement("ISSUER")]
        public string Issuer { get; set; }

        /// <summary>
        /// 订阅者
        /// </summary>
        [XmlElement("AUDIENCE")]
        public string Audience { get; set; }


        /// <summary>
        /// 过期时间
        /// </summary>
        [XmlElement("EXPIRATION")]
        public string Expiration { get; set; }

        [XmlElement("AUTHENTICATE_SCHEME")]
        public string AuthenticateScheme { get; set; }

    }
}
