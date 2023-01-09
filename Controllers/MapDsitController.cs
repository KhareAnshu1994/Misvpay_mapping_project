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
    public class MapDsitController : Controller
    {
        // GET: MapDsit
        IDalMapDsit inst = new DalMapDsit();

        IDALEmployeeDetails emp_id = new DALEmployeeDetails();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();
        IDalRegionMaster d = new DalRegionMaster();


        public ActionResult Index(MapSearchActivites e)
        {
            ViewBag.region_code = e.region_code = UserManager.User.Region;

            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");


            var re = d.GetRegionCode();
            ViewBag.region = new SelectList(re, "umr_region_code", "umr_region_name");


            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");

            var a = inst.GetMapDsitInst(e);
            return View(a);
        }

        [HttpPost]
        public JsonResult Update(List<MapDsitDetails> objList)
        {
            var result = inst.UpdateMapDsit(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(MapDsitDetails objModel)
        {
            var result = inst.Bulk_Update_MAP_DSIT_Mapping_INST(objModel);

            return Json(result);
        }


        public ActionResult _MapDsitView(MapSearchActivites e)
        {

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");
            var a = inst.GetMapDsitInst(e);

            return PartialView("_MapDsitView", a);
        }
    }
}