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

    public class ReasonMasterController : Controller
    {
        // GET: ReasonMaster
        IdalReasonMaster reason = new DalReasonMaster();
        public ActionResult Index(ReasonMasterSearch e)
        {
            var a = reason.ReadAllData(e);
            return View(a);
        }
        public ActionResult _ReasonMasterView(ReasonMasterSearch e)
        {
            var a = reason.ReadAllData(e);
            return PartialView("_ReasonMasterView",a);
        }
    }
}