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

    public class SubbrokerMasterController : Controller
    {

        IdalMapDetagSubarnMaster g = new DalMapDetagSubarnMaster();
        IdalSubbrokerMaster SUBBROKER = new DalSubbrokerMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(SubbrokerMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            //var br = g.GetBranchCode();
            //ViewBag.branchcode = new SelectList(br, "branch_code", "branch_code");

            var br = SUBBROKER.GetBranchCode();
            ViewBag.branchcode = new SelectList(br, "branch_code", "branch_code");

            var a = SUBBROKER.GetSUBBROKERMaster(e);
            return View(a);
        }
        public ActionResult _SubbrokerMasterView(SubbrokerMasterSearch e)
        {
            var a = SUBBROKER.GetSUBBROKERMaster(e);
            return PartialView("_SubbrokerMasterView", a);
        }
    }
}