using Mapping_Solution.DataAccessLayer.DAL;
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mapping_Solution.Controllers
{
    public class MappingChangeAccessController : Controller
    {
        // GET: MappingChangeAccess
        IdalMappingChangeAccess acc = new DalMappingChangeAccess();
        public ActionResult Index()
        {
            var a = acc.GetMappingChangeAccess();
            return View(a);
        }
        public ActionResult _MappingChangeAccessView()
        {
           // var a = acc.GetMappingChangeAccess();
            return View();
        }
    }
}