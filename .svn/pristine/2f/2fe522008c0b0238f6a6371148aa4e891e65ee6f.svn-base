
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

    public class SchemeCatConversionMasterController : Controller
    {
        // GET: Scheme_Cat_Conversion_Master
        IdalSchemeCatConversion con = new DalSchemeCatConversion();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(SchemeCatConversioSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = con.GetSchemeType();
            ViewBag.schemetype = new SelectList(re, "scheme_type", "scheme_type");

            var add = con.Get_SchemeCatConversion_AllDetails(e);
            return View(add);
        }
        public ActionResult _SchemeCatConversionView(SchemeCatConversioSearch e)
        {
            var add = con.Get_SchemeCatConversion_AllDetails(e);
            return PartialView("_SchemeCatConversionView", add);
        }
    }
}