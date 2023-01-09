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
    public class MapArnCityController : Controller
    {
        // GET: MapArnCity
        IDalMapArnCity ex = new DalMapArnCity();

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


            var a = ex.GetMapArnCity(e);
            return View(a);
        }

        [HttpPost]
        public JsonResult Update(List<MapArnCityDetails> data)
        {
            var result = ex.UpdateMapArnCity(data);

            return Json(result);
        }

        public JsonResult BulkUpdate(MapArnCityDetails objModel)
        {
            var result = ex.Bulk_Update_ARN_CITY_TO_RM_MAPPING_RTL(objModel);

            return Json(result);
        }



        public ActionResult _MapArnCityView(MapSearchActivites e)
        {

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");



            var a = ex.GetMapArnCity(e);
            return PartialView("_MapArnCityView", a);
        }
    }
}