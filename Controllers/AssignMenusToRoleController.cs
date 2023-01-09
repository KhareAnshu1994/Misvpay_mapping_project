using Mapping_Solution.CustomHelper;
using Mapping_Solution.DataAccessLayer.DAL;
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mapping_Solution.Controllers
{
    [CustomAuthorize]
    public class AssignMenusToRoleController : Controller
    {
        // GET: AssignMenusToRole
        IdalListOfRoles r = new DalListOfRoles();
        IdalAssignMenusToRole role = new DalAssignMenusToRole();
        public ActionResult Index()
        {
            var res = r.Get_Name();
            ViewBag.name = new SelectList(res, "code", "name");
            var a = role.Get_AssignMenusToRole_AllDetails();
            return View(a);
        }
    }
}