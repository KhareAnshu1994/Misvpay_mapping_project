﻿
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

    public class SchemeCategoryMasterController : Controller
    {
        // GET: Scheme_Category_Master
        IdalSchemeCategory sch = new DalSchemeCategory();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(SchemeCategorySearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = sch.GetSchemeCode();
            ViewBag.schemecode = new SelectList(re, "scheme_code", "scheme_code");

            var add = sch.Get_SchemeCategory_AllDetails(e);
            return View(add);
        }
        public ActionResult _SchemeCatView(SchemeCategorySearch e)
        {
            var add = sch.Get_SchemeCategory_AllDetails(e);
            return PartialView("_SchemeCatView", add);
        }
    }
}