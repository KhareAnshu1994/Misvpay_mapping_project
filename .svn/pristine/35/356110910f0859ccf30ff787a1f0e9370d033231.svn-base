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
    public class MapDetagSubarnMasterController : Controller
    {
        // GET: MapDetagSubarnMaster
        IdalMapDetagSubarnMaster g = new DalMapDetagSubarnMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(MapDetagSubarnMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = g.GetArnNumber();
            ViewBag.arnno = new SelectList(re, "arn_no", "arn_no");



            var add = g.Get_MapDetagSubarnMaster_AllDetails(e);
            return View(add);
        }
        public ActionResult _MapDetagSubarnMasterView(MapDetagSubarnMasterSearch e)
        {
            var add = g.Get_MapDetagSubarnMaster_AllDetails(e);
            return PartialView("_MapDetagSubarnMasterView", add);
        }
    }
}