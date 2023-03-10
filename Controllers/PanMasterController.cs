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

    public class PanMasterController : Controller
    {
        // GET: PAN_Master
        IdalPanMaster PAN = new DalPanMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(PanMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = PAN.GetPanNumber();
            ViewBag.panno = new SelectList(re, "pan", "pan");

            var a = PAN.GetPANMaster(e);
            return View(a);
        }
        public ActionResult _PanMasterView(PanMasterSearch e)
        {
            var a = PAN.GetPANMaster(e);
            return PartialView("_PanMasterView", a);
        }
    }
}