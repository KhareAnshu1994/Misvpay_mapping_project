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

    public class RiaMasterController : Controller
    {
        // GET: Ria_Master
        IdalRia ria = new DalRia();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(RiaMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = ria.GetRiaCode();
            ViewBag.riacode = new SelectList(re, "riacode", "riacode");

            var add = ria.Get_Ria_AllDetails(e);
            return View(add);
        }
        public ActionResult _RiaView(RiaMasterSearch e)
        {
            var add = ria.Get_Ria_AllDetails(e);
            return PartialView("_RiaView", add);
        }
    }
}