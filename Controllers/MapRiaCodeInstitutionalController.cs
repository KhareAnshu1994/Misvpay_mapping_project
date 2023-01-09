﻿using Mapping_Solution.CustomHelper;
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
    public class MapRiaCodeInstitutionalController : Controller
    {
        // GET: MapRiaCodeInstitutional
        IDalMapRiaCodeInstitutional inst = new DalMapRiaCodeInstitutional();

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

            var a = inst.GetMapRiaCodeInstitutional(e);
            return View(a);
        }

        [HttpPost]
        public JsonResult Update(List<MapRiaCodeInstitutionalDetails> objList)
        {
            var result = inst.UpdateMapRiaCodeInst(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(MapRiaCodeInstitutionalDetails objModel)
        {
            var result = inst.Bulk_Update_Ria_Code_Mapping_Inst(objModel);

            return Json(result);
        }


        public ActionResult _MapRiaCodeInstitutionalView(MapSearchActivites e)
        {


            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");


            var a = inst.GetMapRiaCodeInstitutional(e);
            return PartialView("_MapRiaCodeInstitutionalView", a);
        }
    }
}