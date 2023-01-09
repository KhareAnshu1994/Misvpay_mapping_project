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
    public class ListOfRolesController : Controller
    {
        // GET: ListOfRoles
        IdalListOfRoles r = new DalListOfRoles();
        public ActionResult Index()
        {
            var a = r.GetListOfRoles();
            return View(a);
        }
    }
}