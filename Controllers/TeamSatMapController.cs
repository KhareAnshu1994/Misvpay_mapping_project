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

    public class TeamSatMapController : Controller
    {
        // GET: TeamSatMap
        IdalTeamSatMap satmap = new DalTeamSatMap();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();
        IdalUfcMaster UFC = new DalUfcMaster();

        public ActionResult Index(MapSearchActivites e, UfcMasterSearch uf)
        {
            ViewBag.ufc_code = e.ufc_name = UserManager.User.Location;

            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var ufc = UFC.GetUFCMaster(uf); // It is Coming From Ufc Master
            ViewBag.ufcName = new SelectList(ufc, "ufc_code", "ufc_name");

            var add = satmap.Get_TeamSatMap_AllDetails(e);
            return View(add);
        }


        public ActionResult _TeamSatMapView(MapSearchActivites e)
        {
            var add = satmap.Get_TeamSatMap_AllDetails(e);
            return PartialView("_TeamSatMapView", add);
        }
    }
}