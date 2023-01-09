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
    public class AddRoleController : Controller
    {
        // GET: AddRole
        IdalAddRole add = new DalAddRole();
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult create(AddRole e)
        {
            return Json(add.AddRole(e));
        }

        public JsonResult Update_permission(AddRole e)
        {
            var result = add.Update_permission(e);
            return Json(result);
        }

        public JsonResult get_permission(string role_id)
        {
            var result = add.get_permission(role_id);
            return Json(result);
        }

    }
}