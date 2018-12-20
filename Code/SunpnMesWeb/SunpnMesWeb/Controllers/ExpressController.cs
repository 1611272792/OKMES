﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SunpnMesWeb.Controllers
{
    public class ExpressController : Controller
    {
        // GET: Express
        public ActionResult Index(string ShipmentEMNo, string ShipmentEM)
        {
            ViewBag.EmName = ShipmentEM;//获取快递公司名称用于前端判断是否为顺丰快递
            ShipmentEMNo = ShipmentEMNo.Replace(" ",""); ; //快递号
            string str = ShipmentEM + "  " + ShipmentEMNo;
            ViewBag.title = str; 
            ShipmentEM = getPhyCode(ShipmentEM);
            ViewBag.PhyInfo=getPhyInfo(ShipmentEMNo, ShipmentEM);
            return View();
        }

        //public ActionResult Index(string data, string PhyComName)
        //{
        //    ViewBag.title = PhyComName;
        //    ViewBag.PhyInfo = data;
        //    return View();
        //}

        #region 快递公司代码获取
        public string getPhyCode(string typeCom) {
            if (typeCom == "AAE全球专递")
            {
                typeCom = "aae";
            }
            else if (typeCom == "安捷快递")
            {
                typeCom = "anjiekuaidi";
            }
            else if (typeCom == "安信达快递")
            {
                typeCom = "anxindakuaixi";
            }
            else if (typeCom == "百福东方")
            {
                typeCom = "baifudongfang";
            }
            else if (typeCom == "彪记快递")
            {
                typeCom = "biaojikuaidi";
            }
            else if (typeCom == "BHT")
            {
                typeCom = "bht";
            }
            else if (typeCom == "希伊艾斯快递")
            {
                typeCom = "cces";
            }
            else if (typeCom == "中国东方")
            {
                typeCom = "coe";
            }
            else if (typeCom == "长宇物流")
            {
                typeCom = "changyuwuliu";
            }
            else if (typeCom == "大田物流")
            {
                typeCom = "datianwuliu";
            }
            else if (typeCom == "德邦快递")
            {
                typeCom = "debangwuliu";
            }
            else if (typeCom == "DPEX")
            {
                typeCom = "dpex";
            }
            else if (typeCom == "DHL")
            {
                typeCom = "dhl";
            }
            else if (typeCom == "D速快递")
            {
                typeCom = "dsukuaidi";
            }
            else if (typeCom == "fedex")
            {
                typeCom = "fedex";
            }
            else if (typeCom == "飞康达物流")
            {
                typeCom = "feikangda";
            }
            else if (typeCom == "凤凰快递")
            {
                typeCom = "fenghuangkuaidi";
            }
            else if (typeCom == "港中能达物流")
            {
                typeCom = "ganzhongnengda";
            }
            else if (typeCom == "广东邮政物流")
            {
                typeCom = "guangdongyouzhengwuliu";
            }
            else if (typeCom == "汇通快运")
            {
                typeCom = "huitongkuaidi";
            }
            else if (typeCom == "恒路物流")
            {
                typeCom = "hengluwuliu";
            }
            else if (typeCom == "华夏龙物流")
            {
                typeCom = "huaxialongwuliu";
            }
            else if (typeCom == "佳怡物流")
            {
                typeCom = "jiayiwuliu";
            }
            else if (typeCom == "京广速递")
            {
                typeCom = "jinguangsudikuaijian";
            }
            else if (typeCom == "急先达")
            {
                typeCom = "jixianda";
            }
            else if (typeCom == "佳吉物流")
            {
                typeCom = "jiajiwuliu";
            }
            else if (typeCom == "加运美")
            {
                typeCom = "jiayunmeiwuliu";
            }
            else if (typeCom == "快捷速递")
            {
                typeCom = "kuaijiesudi";
            }
            else if (typeCom == "联昊通物流")
            {
                typeCom = "lianhaowuliu";
            }
            else if (typeCom == "龙邦物流")
            {
                typeCom = "longbanwuliu";
            }
            else if (typeCom == "民航快递")
            {
                typeCom = "minghangkuaidi";
            }
            else if (typeCom == "配思货运")
            {
                typeCom = "peisihuoyunkuaidi";
            }
            else if (typeCom == "全晨快递")
            {
                typeCom = "quanchenkuaidi";
            }
            else if (typeCom == "全际通物流")
            {
                typeCom = "quanjitong";
            }
            else if (typeCom == "全日通快递")
            {
                typeCom = "quanritongkuaidi";
            }
            else if (typeCom == "全一快递")
            {
                typeCom = "quanyikuaidi";
            }
            else if (typeCom == "盛辉物流")
            {
                typeCom = "shenghuiwuliu";
            }
            else if (typeCom == "速尔物流")
            {
                typeCom = "suer";
            }
            else if (typeCom == "盛丰物流")
            {
                typeCom = "shengfengwuliu";
            }
            else if (typeCom == "天地华宇")
            {
                typeCom = "tiandihuayu";
            }
            else if (typeCom == "天天")
            {
                typeCom = "tiantian";
            }
            else if (typeCom == "TNT")
            {
                typeCom = "tnt";
            }
            else if (typeCom == "UPS")
            {
                typeCom = "ups";
            }
            else if (typeCom == "万家物流")
            {
                typeCom = "wanjiawuliu";
            }
            else if (typeCom == "文捷航空速递")
            {
                typeCom = "wenjiesudi";
            }
            else if (typeCom == "伍圆速递")
            {
                typeCom = "wuyuansudi";
            }
            else if (typeCom == "万象物流")
            {
                typeCom = "wanxiangwuliu";
            }
            else if (typeCom == "新邦物流")
            {
                typeCom = "xinbangwuliu";
            }
            else if (typeCom == "信丰物流")
            {
                typeCom = "xinfengwuliu";
            }
            else if (typeCom == "星晨急便")
            {
                typeCom = "xingchengjibian";
            }
            else if (typeCom == "鑫飞鸿物流快递")
            {
                typeCom = "xinhongyukuaidi";
            }
            else if (typeCom == "亚风速递")
            {
                typeCom = "yafengsudi";
            }
            else if (typeCom == "一邦速递")
            {
                typeCom = "yibangwuliu";
            }
            else if (typeCom == "优速快递")
            {
                typeCom = "youshuwuliu";
            }
            else if (typeCom == "远成物流")
            {
                typeCom = "yuanchengwuliu";
            }
            else if (typeCom == "圆通快递")
            {
                typeCom = "yuantong";
            }
            else if (typeCom == "源伟丰快递")
            {
                typeCom = "yuanweifeng";
            }
            else if (typeCom == "元智捷诚快递")
            {
                typeCom = "yuanzhijiecheng";
            }
            else if (typeCom == "越丰物流")
            {
                typeCom = "yuefengwuliu";
            }
            else if (typeCom == "韵达快递")
            {
                typeCom = "yunda";
            }
            else if (typeCom == "源安达")
            {
                typeCom = "yuananda";
            }
            else if (typeCom == "运通快递")
            {
                typeCom = "yuntongkuaidi";
            }
            else if (typeCom == "宅急送")
            {
                typeCom = "zhaijisong";
            }
            else if (typeCom == "中铁快运")
            {
                typeCom = "zhongtiewuliu";
            }
            else if (typeCom == "EMS快递")
            {
                typeCom = "ems";
            }
            else if (typeCom == "申通快递")
            {
                typeCom = "shentong";
            }
            else if (typeCom == "顺丰快递" || typeCom == "顺风快递")
            {
                typeCom = "shunfeng";
            }
            else if (typeCom == "中邮物流")
            {
                typeCom = "zhongyouwuliu";
            }
            else if (typeCom == "中通快递")
            {
                typeCom = "zhongtong";
            }
            else if (typeCom == "安能物流")
            {
                typeCom = "annengwuliu";
            }
            return typeCom;

        }
        #endregion


        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <param name="PhyCode">物流单号</param>
        /// <param name="PhyName">物流公司代码</param>
        /// <returns></returns>
        public string getPhyInfo(string PhyCode, string PhyName)
        {
            using (var httpClient = new HttpClient())
            {
                //get
                string Urlstr = "https://www.kuaidi100.com/query?type=" + PhyName + "&postid=" + PhyCode;
                var url = new Uri(Urlstr);
                // response
                var response = httpClient.GetAsync(url).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                return  data;//接口调用成功获取的数据
            }
        }
    }
}