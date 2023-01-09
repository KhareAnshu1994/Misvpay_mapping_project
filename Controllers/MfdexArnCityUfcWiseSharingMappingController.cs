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
    public class MfdexArnCityUfcWiseSharingMappingController : Controller
    {
        // GET: MfdexArnCityUfcWiseSharingMapping

        IDalMfdexArnCityUfcWiseSharingMapping sh = new DalMfdexArnCityUfcWiseSharingMapping();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();


        public ActionResult Index(MapSearchActivites e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var a = sh.GetMfdexArnCityUfcWiseSharing(e);
            return View(a);
        }


        public ActionResult _MfdexArnCityUfcWiseSharingMappingView(MapSearchActivites e)
        {
            var a = sh.GetMfdexArnCityUfcWiseSharing(e);
            return PartialView("_MfdexArnCityUfcWiseSharingMappingView", a);
        }
    }
}