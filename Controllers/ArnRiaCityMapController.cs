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
    public class ArnRiaCityMapController : Controller
    {
        // GET: ArnRiaCityMap
        IdalArnRiaCity cty = new DalArnRiaCity();

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

            var add = cty.Get_ArnRiaCity_AllDetails(e);
            return View(add);
        }

        [HttpPost]
        public JsonResult Update(List<ArnRiaCityDetail> objList)
        {
            var result = cty.Update_ARN_RIA_CITY_MAPPING_RTLL(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(ArnRiaCityDetail objModel)
        {
            var result = cty.Bulk_Update_ARN_Ria_City(objModel);

            return Json(result);
        }



        public ActionResult _ArnRiaCityMapView(MapSearchActivites e)
        {
            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");
            var add = cty.Get_ArnRiaCity_AllDetails(e);
            return PartialView("_ArnRiaCityMapView", add);
        }
    }
}