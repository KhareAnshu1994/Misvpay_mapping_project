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
    public class MapMulticityController : Controller
    {
        // GET: MapMulticity

        IDalMapMulticity ex = new DalMapMulticity();
       
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

            var a = ex.GetMapMulticity(e);
            return View(a);
        }

        [HttpPost]
        public JsonResult Update(List<MapMulticityDetails> objList)
        {
            var result = ex.Update_ARN_UFC_TO_RM_MAPPING_RTL(objList);

            return Json(result);
        }


        public JsonResult BulkUpdate(MapMulticityDetails objModel)
        {
            var result = ex.Bulk_Update_ARN_UFC_TO_RM_MAPPING(objModel);

            return Json(result);
        }

        public ActionResult _MapMulticityView(MapSearchActivites e)
        {
           
            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");

            var a = ex.GetMapMulticity(e);

            return PartialView("_MapMulticityView", a);
        }
    }
}