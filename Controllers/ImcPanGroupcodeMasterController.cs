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
    public class ImcPanGroupcodeMasterController : Controller
    {
        // GET: ImcPanGroupcodeMaster
        IdalImcPanGroupcodeMaster n = new DalImcPanGroupcodeMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(ImcPanGroupcodeMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = n.GetGroupCode();
            ViewBag.groupcode = new SelectList(re, "groupcode", "groupcode");

            var add = n.Get_ImcPanGroupcode_AllDetails(e);
            return View(add);
        }
        public ActionResult _ImcPanGroupcodeMasterView(ImcPanGroupcodeMasterSearch e)
        {
            var add = n.Get_ImcPanGroupcode_AllDetails(e);
            return PartialView("_ImcPanGroupcodeMasterView", add);
        }
    }
}