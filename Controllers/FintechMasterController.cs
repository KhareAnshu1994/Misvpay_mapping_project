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
    public class FintechMasterController : Controller
    {
        IdalFintechMaster FINTECH = new DalFintechMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(FintechMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = FINTECH.GetArnRiaCode();
            ViewBag.arnriacode = new SelectList(re, "arn_ria_code", "arn_ria_code");

            var a = FINTECH.GetFINTECHMaster(e);
            return View(a);
        }
        public ActionResult _FintechView(FintechMasterSearch e)
        {
            var a = FINTECH.GetFINTECHMaster(e);
            return PartialView("_FintechView", a);
        }
    }
}