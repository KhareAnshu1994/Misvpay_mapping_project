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

    public class UfcMasterController : Controller
    {
        // GET: UFC_Master
        IdalUfcMaster UFC = new DalUfcMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(UfcMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");


            var re = UFC.GetSapUfcCode();
            ViewBag.sap_ufc = new SelectList(re, "sap_ufc_code", "sap_ufc_code");

            var a = UFC.GetUFCMaster(e);
            return View(a);
        }
        public ActionResult _UfcView(UfcMasterSearch e)
        {
            var a = UFC.GetUFCMaster(e);
            return PartialView("_UfcView", a);
        }
    }
}