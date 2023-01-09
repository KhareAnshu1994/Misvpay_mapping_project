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
    public class BnndMapPincodeArnController : Controller
    {

        // GET: BnndMapPincodeArn
        IdalBnndMapPincodeArn BNND = new DalBnndMapPincodeArn();

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
            var a = BNND.GetBnndMapPincodeArn(e);
            return View(a);
        }

        [HttpPost]
        public JsonResult Update(List<BnndMapPincodeArnDetails> objList)
        {
            var result = BNND.Update_ARN_PINCODE_TO_RM_MAPPING_RTL(objList);

            return Json(result);
        }

        public JsonResult BulkUpdate(BnndMapPincodeArnDetails objModel)
        {
            var result = BNND.Bulk_Update_ARN_Pincode(objModel);

            return Json(result);
        }



        public ActionResult _BnndMapPincodeArnView(MapSearchActivites e)
        {

            var emplid = emp_id.GetEmployeeID();
            ViewBag.rm_code = new SelectList(emplid, "EmployeeId", "EmployeeName");
            var a = BNND.GetBnndMapPincodeArn(e);
            return PartialView("_BnndMapPincodeArnView", a);
        }
    }
}