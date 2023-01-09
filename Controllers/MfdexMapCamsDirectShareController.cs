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
    public class MfdexMapCamsDirectShareController : Controller
    {
        // GET: MfdexMapCamsDirectShare
        IdalMfdexMapCamsDirectShare sh = new DalMfdexMapCamsDirectShare();

        IDALEmployeeDetails emp_id = new DALEmployeeDetails();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();
        IdalUfcMaster UFC = new DalUfcMaster();

        public ActionResult Index(MapSearchActivites e, UfcMasterSearch uf)
        {
            ViewBag.ufc_code = e.ufc_name = UserManager.User.Location;

            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");


            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");



            var ufc = UFC.GetUFCMaster(uf); // It is Coming From Ufc Master
            ViewBag.ufcName = new SelectList(ufc, "ufc_code", "ufc_name");

            var add = sh.Get_MfdexMapCamsDirectShare_AllDetails(e);

            return View(add);
        }

        public JsonResult Update(List<MfdexMapCamsDirectShareDetail> objList)
        {
            var result = sh.Update_DIRECT_SINGLE_CITY_TO_RM_MAPPING_RTL(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(MfdexMapCamsDirectShareDetail objModel)
        {
            var result = sh.Bulk_Update_Direct_Single_City(objModel);

            return Json(result);
        }


        public ActionResult _MfdexMapCamsDirectShareView(MapSearchActivites e)
        {

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");

            var add = sh.Get_MfdexMapCamsDirectShare_AllDetails(e);

            return PartialView("_MfdexMapCamsDirectShareView", add);
        }
    }
}