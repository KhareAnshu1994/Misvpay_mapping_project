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

    public class MfdexMapNewcityDirectController : Controller
    {

        // GET: MfdexMapNewcityDirect
        IDalMfdexMapNewcityDirect map = new DalMfdexMapNewcityDirect();

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

            var a = map.GetMfdexMapNewcityDirect(e);

            return View(a);
        }

        public JsonResult Update(List<MfdexMapNewcityDirectDetails> objList)
        {
            var result = map.Update_DIRECT_GROUP_OF_CITIES_TO_RMMAPPING_RTL(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(MfdexMapNewcityDirectDetails objModel)
        {
            var result = map.Bulk_Update_DirectGroup_of_City(objModel);

            return Json(result);
        }



        public ActionResult _MfdexMapNewcityDirectView(MapSearchActivites e)
        {

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");

            var a = map.GetMfdexMapNewcityDirect(e);

            return PartialView("_MfdexMapNewcityDirectView", a);
        }
    }
}