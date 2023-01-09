using Mapping_Solution.CustomHelper;
using Mapping_Solution.DataAccessLayer.DAL;
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mapping_Solution.Controllers
{
    [CustomAuthorize]
    public class KraMasterController : Controller
    {
        // GET: KraMaster

        IDalKraMaster d = new DalKraMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(KraMasterSearch e)
        {

            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = d.GetKraCode();
            ViewBag.KraCode = new SelectList(re, "kra_code", "kra_code");

            var a = d.GetKraMaster(e);

            return View(a);
        }

        public ActionResult _KraView(KraMasterSearch e)
        {
            var a = d.GetKraMaster(e);
            return PartialView("_KraView", a);
        }
    }
}