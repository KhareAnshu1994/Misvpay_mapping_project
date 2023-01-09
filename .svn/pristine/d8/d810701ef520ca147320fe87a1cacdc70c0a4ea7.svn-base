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

    public class VymoDistributorMappingController : Controller
    {
        // GET: VymoDistributorMapping
        IdalVymoDistributorMapping vymo = new DalVymoDistributorMapping();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();
        IDALEmployeeDetails emp_id = new DALEmployeeDetails();
        IdalUfcMaster UFC = new DalUfcMaster();

        public ActionResult Index(VymoDistributorMappingSearch e, UfcMasterSearch uf)
        {
            ViewBag.UFCcode = e.ufc_name = UserManager.User.Location;

            var ufc = UFC.GetUFCMaster(uf); // It is Coming From Ufc Master
            ViewBag.ufcName = new SelectList(ufc, "ufc_code", "ufc_name");


            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");



            var a = vymo.Get_VymoDistributorMapping_AllDetails(e);
            return View(a);
        }

        [HttpPost]
        public JsonResult Update(List<VymoDistributorMappingDetail> objList)
        {
            var result = vymo.Update_VYMO_DISTRIBUTOR_MAPPING_RTL(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(VymoDistributorMappingDetail objModel)
        {
            var result = vymo.Bulk_Update_Vymo_Distributor(objModel);

            return Json(result);
        }



        public ActionResult _VymoDistributorMappingView(VymoDistributorMappingSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");

            var a = vymo.Get_VymoDistributorMapping_AllDetails(e);
            return PartialView("_VymoDistributorMappingView", a);
        }
    }
}