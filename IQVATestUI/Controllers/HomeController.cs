using IQVATest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IQVATestUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("TweetRange");
        }


        public ActionResult TweetRange(string start = "01-01-2016", string end = "01-31-2016")
        {
            ViewBag.Title = "Twitter History";
            ViewBag.start = DateTime.Parse(start);
            ViewBag.end = DateTime.Parse(end);

            ViewBag.Tweets = TweetParser.GetFullRange(ViewBag.start, ViewBag.end);
            return View();
        }
    }
}