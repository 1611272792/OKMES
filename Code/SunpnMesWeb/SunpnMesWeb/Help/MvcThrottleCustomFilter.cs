﻿using MvcThrottle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SunpnMesWeb.Help
{
    public class MvcThrottleCustomFilter : ThrottlingFilter
    {
        protected override ActionResult QuotaExceededResult(RequestContext filterContext, string message, System.Net.HttpStatusCode responseCode, string requestId)
        {
            var rateLimitedView = new ViewResult
            {
                ViewName = "RateLimited"
            };
            rateLimitedView.ViewData["Message"] = message;

            return rateLimitedView;
        }
    }
}