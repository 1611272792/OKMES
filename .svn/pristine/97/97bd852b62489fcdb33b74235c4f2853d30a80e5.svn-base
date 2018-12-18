using SunpnMesWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using SunpnMesWeb.Help;
using MvcThrottle;

namespace SunpnMesWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [EnableThrottling(PerSecond = 5, PerMinute = 10)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 账号登录验证
        /// </summary>
        /// <param name="userName">客户编号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        [EnableThrottling(PerSecond = 5, PerMinute = 10)]
        [HttpGet]
        public ActionResult CheckUser(string userName,string pwd,string yzm) {
            string code = Session["code"].ToString();
            string XmlInfo = "";
            if (!code.Equals(yzm))
            {
                XmlInfo = "<document><ReturnValue>0</ReturnValue><ReturnMessage>验证码错误！</ReturnMessage></document>";
            }
            else
            {
              XmlInfo = InteefaceHelp.getXmlInfo("81", "<document><CustomerNo>" + userName + "</CustomerNo ><CusPassword>" + pwd + "</CusPassword></document>");
            }
            return Content(JsonHelper.XmlTojson(XmlInfo));
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="oldPwd">原密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdUser(string userName, string oldPwd,string newPwd)
        {
            //ServiceReference1.MesWebSoapClient mws = new ServiceReference1.MesWebSoapClient();
            string XmlInfo = InteefaceHelp.getXmlInfo("82", "<document><CustomerNo>" + userName + "</CustomerNo ><CusPassword>" + oldPwd + "</CusPassword><NewCusPassword>"+newPwd+"</NewCusPassword></document>");
            return Content(JsonHelper.XmlTojson(XmlInfo));
        }

         
        /// <summary>
        /// 验证码控制器代码
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowValidateCode()
         {
            ValidateCode ValidateCode = new ValidateCode();
            string code = ValidateCode.CreateValidateCode(4);//生成验证码，传几就是几位验证码
            Session["code"] = code;
            byte[] buffer = ValidateCode.CreateValidateGraphic(code);//把验证码画到画布
            return File(buffer, "image/jpeg");
        }
    }
}