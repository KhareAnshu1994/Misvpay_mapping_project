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

    public class RegionMasterController : Controller
    {

        IDalRegionMaster d = new DalRegionMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        // GET: RegionMaster
        public ActionResult Index(RegionMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = d.GetRegionCode();
            ViewBag.region = new SelectList(re, "umr_region_code", "umr_region_name");

            var a = d.GetRegionMaster(e);
            return View(a);
        }
        public ActionResult _RegionView(RegionMasterSearch e)
        {
            var a = d.GetRegionMaster(e);
            return PartialView("_RegionView", a);
        }


    }
}