using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SunpnMesWeb.Common
{
    public static class InteefaceHelp
    {

        /// <summary>
        /// 访问接口并且获取xml数据
        /// </summary>
        /// <param name="interfaceNo">接口编号</param>
        /// <param name="xmlString">xml格式的参数</param>
        /// <returns></returns>
        public static string getXmlInfo(string interfaceNo,string xmlString)
        {
            ServiceReference1.MesWebSoapClient mws = new ServiceReference1.MesWebSoapClient();
            string XmlInfo = mws.Call(interfaceNo, xmlString, "");
            return XmlInfo;
        }

        /// <summary>
        /// 获取下载文件的byte字节
        /// </summary>
        /// <param name="ServerFileName">文件名</param>
        /// <param name="FilePath">该文件在服务器的路径</param>
        /// <param name="Message">结果信息</param>
        /// <returns></returns>
        public static byte[] GetFileInfo(string ServerFileName,string FilePath,out string Message)
        {
            ServiceReference1.MesWebSoapClient mws = new ServiceReference1.MesWebSoapClient();
            byte[] buffer= mws.DownFile(ServerFileName, FilePath,out Message);
            return buffer;
        }

        /// <summary>
        /// 解析xml属性
        /// </summary>
        /// <param name="xmlUrl">接口编号</param>
        /// <param name="xmlString">xml格式的参数</param>
        /// <returns></returns>
        public static List<Hashtable> AnalyXmlAttribute(string xmlUrl, XmlDocument doc)
        {
            List<Hashtable> list = new List<Hashtable>();
            //DataTable dt = new DataTable();
            foreach (XmlElement xmlInfo in doc.SelectNodes(xmlUrl))
            {
                Hashtable hs = new Hashtable();
                foreach (XmlAttribute attribute in xmlInfo.Attributes)
                {
                    hs.Add(attribute.Name, attribute.Value);
                }
                list.Add(hs);

                //hs.Clear();
            }
            return list;
        }
    }
}