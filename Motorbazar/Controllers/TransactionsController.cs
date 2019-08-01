using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Motorbazar.Controllers
{
    public class TransactionsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}