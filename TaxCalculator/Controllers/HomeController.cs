using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var TaxInfo = new Tax();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "GrossEarnings")] Tax TaxInfo)
        {
            
            TaxInfo.CalculateTax();
            TaxInfo.CalculateNIC();
            var Spending = new PublicExpenditure(TaxInfo.IncomeTax, TaxInfo.NIC);
            if (TaxInfo.GrossEarnings >= 0)
            {
                ViewBag.Display = true;
            }
            else {
                ViewBag.Display = false;
            }
            ViewBag.TaxInfo = TaxInfo;
            ViewBag.Spending = Spending;
            return View(TaxInfo);
        }

    }
}