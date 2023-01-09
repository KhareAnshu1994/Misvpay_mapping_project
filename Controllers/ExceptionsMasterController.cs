﻿using Mapping_Solution.CustomHelper;
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
    public class ExceptionsMasterController : Controller
    {
        // GET: Exceptions
        IdalExceptionsMaster EXCEPTIONSM = new DalExceptionsMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(ExceptionsMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = EXCEPTIONSM.GetCaseId();
            ViewBag.caseid = new SelectList(re, "case_id", "case_id");

            var a = EXCEPTIONSM.GetExceptionsMaster(e);
            return View(a);
        }

        public ActionResult _ExceptionsMasterView(ExceptionsMasterSearch e)
        {
            var a = EXCEPTIONSM.GetExceptionsMaster(e);
            return PartialView("_ExceptionsMasterView", a);
        }
    }
}