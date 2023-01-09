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
    public class ArnPrmRmcodeMappingController : Controller
    {
        // GET: ArnPrmRmcodeMapping

        IDalArnPrmRmcodeMapping arn = new DalArnPrmRmcodeMapping();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();
        IdalUfcMaster UFC = new DalUfcMaster();


        public ActionResult Index(MapSearchActivites e, UfcMasterSearch uf)
        {
            ViewBag.ufc_code = e.ufc_name = UserManager.User.Location;

            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var ufc = UFC.GetUFCMaster(uf); // It is Coming From Ufc Master
            ViewBag.ufcName = new SelectList(ufc, "ufc_code", "ufc_name");

            var a = arn.GetArnPrmRmcodeMapping(e);
            return View(a);
        }
        public ActionResult _ArnPrmRmcodeMappingView(MapSearchActivites e)
        {
            var a = arn.GetArnPrmRmcodeMapping(e);
            return PartialView("_ArnPrmRmcodeMappingView", a);
        }
    }
}