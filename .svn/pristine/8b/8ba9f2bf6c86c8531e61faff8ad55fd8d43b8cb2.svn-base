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
    public class MfdexArnCityUfcWiseSharingMasterController : Controller
    {
        // GET: MfdexArnCityUfcWiseSharingMaster

        IDalMfdexArnCityUfcWiseSharingMaster ws = new DalMfdexArnCityUfcWiseSharingMaster();
        IdalArnMaster ARN = new DalArnMaster();


        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(MfdexArnCityUfcWiseSharingMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            //var re = ARN.GetKRVCode();
            //ViewBag.krv = new SelectList(re, "krv_code", "krv_code");
            var re = ws.GetkrvCode();
            ViewBag.krv = new SelectList(re, "krv_code", "krv_code");

            var a = ws.GetMfdexCityWiseMaster(e);
            return View(a);
        }
        public ActionResult _MfdexArnCityUfcWiseSharingMasterView(MfdexArnCityUfcWiseSharingMasterSearch e)
        {
            var a = ws.GetMfdexCityWiseMaster(e);
            return PartialView("_MfdexArnCityUfcWiseSharingMasterView", a);
        }
    }
}