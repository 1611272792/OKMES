using Newtonsoft.Json;
using SunpnMesWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace SunpnMesWeb.Common
{
    public static class JsonHelper
    {
        // 从一个对象信息生成Json串
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息
        public static object JsonToObject(string jsonString, object obj)
        {
            return JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }

        /// <summary>
        /// xml转化为json并去掉key里面的@符号
        /// </summary>
        /// <param name="xmlString">xml字符串</param>
        /// <returns></returns>
        public static string XmlTojson(string xmlString)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xmlString);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            Regex reg = new Regex("\"@([^ \"]*)\"\\s*:\\s*\"(([^ \"]+\\s*)*)\"");
            string strPatten = "\"$1\":\"$2\"";
            json = reg.Replace(json, strPatten);
            return json;

        }

    }
}