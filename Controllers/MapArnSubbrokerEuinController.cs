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
    public class MapArnSubbrokerEuinController : Controller
    {
        // GET: MapArnSubbrokerEuin
        IDalMapArnSubbrokerEuin ex = new DalMapArnSubbrokerEuin();
        
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
            var a = ex.GetMapArnSubbrokerEuin(e);

            return View(a);
        }

        [HttpPost]
        public JsonResult Update(List<MapArnSubbrokerEuinDetails> objList)
        {
            var result = ex.Update_ARNEUIN_SUB_ARN_BRANCH_CODE_MAPPING_RTL(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(MapArnSubbrokerEuinDetails objModel)
        {
            var result = ex.Bulk_Update_ARNEUIN_SUB_ARN_BRANCH_CODE(objModel);

            return Json(result);
        }

        public ActionResult _MapArnSubbrokerEuinView(MapSearchActivites e)
        {
           
            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");
            var a = ex.GetMapArnSubbrokerEuin(e);

            return PartialView("_MapArnSubbrokerEuinView", a);
        }

    }
}