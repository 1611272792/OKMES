﻿using SunpnMesWeb.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Xml;
using Newtonsoft.Json;
using SunpnMesWeb.Models;
using System.Data;
using System.Net.Http;
using System.Configuration;

namespace SunpnMesWeb.Controllers
{
    public class MainController : Controller
    {
        // GET: Main           
        public ActionResult Index(Rows rowsinfo)
        {
            if (rowsinfo.RowNo!="1")
            {
                //return Content("<script>window.location.href='/login/Index'</script>");
                return Redirect("/Login/Index");
            }
          
            ViewBag.userInfo = rowsinfo;  //客户信息
            string XmlInfo = InteefaceHelp.getXmlInfo("83", "<document><CustomerNo>" + rowsinfo.CustomerNo + "</CustomerNo ></document>");
            ViewBag.jsonOrder = JsonHelper.XmlTojson(XmlInfo);  //订单数据



            return View();
        }
        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public ActionResult SelectOrder(string orderID) {
            //ServiceReference1.MesWebSoapClient s = new ServiceReference1.MesWebSoapClient();
            string XmlInfo = InteefaceHelp.getXmlInfo("84", "<document><SoCode>" + orderID + "</SoCode ></document>");
            //解析xml
            var doc = new XmlDocument();
            doc.LoadXml(XmlInfo);

            List<Hashtable> list = InteefaceHelp.AnalyXmlAttribute("/document/Data/Row", doc);
            if (list.Count > 0)
            {
                ViewBag.hs = list;
            }
            else
            {
                ViewBag.hs = null;
            }
            //出货情况及物流单号
            string goodsDeliver = InteefaceHelp.getXmlInfo("86", "<document><SoCode>" + orderID + "</SoCode ></document>");
            var doc2 = new XmlDocument();
            doc2.LoadXml(goodsDeliver);
            List<Hashtable> list2 = InteefaceHelp.AnalyXmlAttribute("/document/Data/Row", doc2);
            if (list2.Count > 0)
            {
                ViewBag.list2 = list2;
            }
            else
            {
                ViewBag.list2 = null;
            }
            return PartialView("_SelectOrder");
        }

        /// <summary>
        /// 获取缺料信息
        /// </summary>
        /// <param name="moCode">生产单号</param>
        /// <returns></returns>
        public ActionResult getMnInfo(string moCode)
        {
            string XmlInfo = InteefaceHelp.getXmlInfo("85", "<document><MoCode>" + moCode + "</MoCode ></document>");
            return Content(JsonHelper.XmlTojson(XmlInfo));
        }

        /// <summary>
        /// 资料信息
        /// </summary>
        /// <param name="moCode">生产单号</param>
        /// <returns></returns>
        public ActionResult downFileInfo(string moCode)
        {
            string XmlInfo = InteefaceHelp.getXmlInfo("87", "<document><MoCode>" + moCode + "</MoCode ></document>");
            return Content(JsonHelper.XmlTojson(XmlInfo));
        }

        /// <summary>
        /// 资料下载
        /// </summary>
        /// <param name="serFileName">服务器文件名</param>
        /// <param name="serFilePath">服务器路径</param>
        /// <returns></returns>
        public ActionResult downFile(string serFileName, string serFilePath,string clicName)
        {
            try
            {
                       
                string Message = "";
                byte[] XmlInfos = InteefaceHelp.GetFileInfo(serFileName, serFilePath, out Message);
                //System.IO.File.WriteAllBytes(dir, XmlInfos);
                return File(XmlInfos, "application/vnd.ms-excel", clicName);// "application/vnd.ms-excel",mime类型

            }
            catch (Exception ex)
            {
                //System.IO.File.WriteAllText("D:\\11.txt", ex.Message);
                return Content(ex.Message); ;
            }
        }
 
         


        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <param name="PhyCode">物流单号</param>
        /// <param name="PhyName">物流公司代码</param>
        /// <returns></returns>
        public ActionResult getPhyInfo(string PhyCode,string PhyName)
        {
            using (var httpClient = new HttpClient())
            {
                //get
                string Urlstr = "https://www.kuaidi100.com/query?type="+ PhyName + "&postid="+ PhyCode;
                var url = new Uri(Urlstr);
                // response
                var response = httpClient.GetAsync(url).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                return Content(data);//接口调用成功获取的数据
            }
        }

        
    }
 
}