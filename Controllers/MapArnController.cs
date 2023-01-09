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
    public class MapArnController : Controller
    {
        // GET: MapArn
        IDalMapArn d = new DalMapArn();
        IDALEmployeeDetails emp_id = new DALEmployeeDetails();
        IdalUfcMaster UFC = new DalUfcMaster();

        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(MapSearchActivites e, UfcMasterSearch uf)
        {
            ViewBag.ufc_code = e.ufc_name = UserManager.User.Location;

            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var ufc = UFC.GetUFCMaster(uf); // It is Coming From Ufc Master
            ViewBag.ufcName = new SelectList(ufc, "ufc_code", "ufc_name");

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");

            var a = d.GetMapArn(e);
            return View(a);
        }



        [HttpPost]
        public JsonResult Update(List<MapArnDetails> objList)
        {
            var result = d.UpdateMapArn(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(MapArnDetails objModel)
        {
            var result = d.Bulk_Update_Mfd_To_RM(objModel);

            return Json(result);
        }





        public ActionResult _MapArnView(MapSearchActivites e)
        {

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");
            var a = d.GetMapArn(e);
            return PartialView("_MapArnView", a);
        }
    }
}
