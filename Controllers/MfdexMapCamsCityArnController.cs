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
    public class MfdexMapCamsCityArnController : Controller
    {
        // GET: MfdexMapCamsCityArn
        IdalMfdexMapCamsCityArn dex = new DalMfdexMapCamsCityArn();

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

            var add = dex.Get_MfdexMapCamsCityArn_AllDetails(e);

            return View(add);
        }

        public JsonResult Update(List<MfdexMapCamsCityArnDetail> objList)
        {
            var result = dex.Update_ARN_SINGLE_CITY_TO_RM_MAPPING_RTL(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(MfdexMapCamsCityArnDetail objModel)
        {
            var result = dex.Bulk_Update_Arn_Single_city(objModel);

            return Json(result);
        }



        public ActionResult _MfdexMapCamsCityArnView(MapSearchActivites e)
        {

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");

            var add = dex.Get_MfdexMapCamsCityArn_AllDetails(e);

            return PartialView("_MfdexMapCamsCityArnView", add);
        }
    }
}