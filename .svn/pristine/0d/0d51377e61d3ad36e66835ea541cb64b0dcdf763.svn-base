
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.DataAccessLayer.DAL;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mapping_Solution.Models;
using Mapping_Solution.CustomHelper;

namespace Mapping_Solution.Controllers
{
    [CustomAuthorize]
    public class CrcaExclusionMasterController : Controller
    {
        // GET: Crca_Exclusion_Master
        IdalCrcaExclusion crca = new DalCrcaExclusion();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();


        public ActionResult Index(CrcaExclusionSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = crca.GetAcno();
            ViewBag.acno = new SelectList(re, "acno", "acno");

            var add = crca.Get_CrcaExclusion_AllDetails(e);
            return View(add);
        }
        public ActionResult _CrcaExclusionView(CrcaExclusionSearch e)
        {
            var add = crca.Get_CrcaExclusion_AllDetails(e);
            return PartialView("_CrcaExclusionView", add);
        }
    }
}