
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.DataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mapping_Solution.Models;
using Mapping_Solution.CustomHelper;

namespace Mapping_Solution.Controllers
{
    [CustomAuthorize]

    public class UserMasterController : Controller
    {
        // GET: User_Master
        IdalUser user = new DalUser();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(UserDetailSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = user.GetEmpId();
            ViewBag.empid = new SelectList(re, "emp_id", "emp_id");


            var add = user.Get_User_AllDetails(e);
            return View(add);
        }
        public ActionResult _UserView(UserDetailSearch e)
        {
            var add = user.Get_User_AllDetails(e);
            return PartialView("_UserView", add);
        }
    }
}