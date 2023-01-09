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
    public class EmployeeDetailController : Controller
    {
        // GET: EmployeeDetail

        IDalZoneMaster z = new DalZoneMaster();
        IdalListOfRoles r = new DalListOfRoles();
        IDalCamsCityUfcMaster d = new DalCamsCityUfcMaster();
        IdalUfcMaster UFC = new DalUfcMaster();
        IDALEmployeeDetails objemp = new DALEmployeeDetails();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();
        IdalChannelmaster m = new DalChannelmaster();

        public ActionResult Index(EmployeeDetailsSearch emp, UfcMasterSearch e)
        {
            var ch = m.GetChannelCode();
            ViewBag.channelcode = new SelectList(ch, "channel_code", "channel_code");

            var ufc = UFC.GetUFCMaster(e); // It is Coming From Ufc Master
            ViewBag.Location = new SelectList(ufc, "ufc_code", "ufc_name");

            var st = drop.GetStatus();
            ViewBag.Status = new SelectList(st, "status_id", "Status");


            var rl = r.GetListOfRoles();
            ViewBag.role = new SelectList(rl, "code", "name");


            var a = objemp.GetEmployeeDetails(emp);
            return View(a);
        }


        public ActionResult _EmployeeDetail(EmployeeDetailsSearch emp)
        {
            var a = objemp.GetEmployeeDetails(emp);
            return PartialView("_EmployeeDetail", a);
        }

        public ActionResult _EmployeeDetailEdit(EmployeeDetails objEmployeeDetails, UfcMasterSearch e)
        {
            var ch = m.GetChannelCode();
            ViewBag.channelcode = new SelectList(ch, "channel_code", "channel_code");

            var rl = drop.GetEMPRole();// It is coming from list of role
            ViewBag.role = new SelectList(rl, "EmployeeRole", "EmployeeRole");

            var re = drop.GetRegion();
            ViewBag.region = new SelectList(re, "Region", "Region");

            var zo = z.GetZoneCode();
            ViewBag.ZoneCode = new SelectList(zo, "umz_zone_code", "umz_zone_code");

            var ufc = UFC.GetUFCMaster(e); // It is Coming From Ufc Master
            ViewBag.Location = new SelectList(ufc, "ufc_code", "ufc_name");


            var res = r.Get_Name();// It is coming from list of role
            ViewBag.Rolename = new SelectList(res, "name", "name");

            var st = drop.GetStatus();
            ViewBag.Status = new SelectList(st, "Status", "Status");

            var mo = drop.GetMovement();
            ViewBag.Movement = new SelectList(mo, "TypeOfMovement", "TypeOfMovement");

            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var a = objemp.GetEmployeeDetails_id(objEmployeeDetails);
            return View(a);
        }

    }
}