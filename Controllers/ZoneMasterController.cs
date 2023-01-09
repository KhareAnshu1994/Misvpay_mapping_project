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

    public class ZoneMasterController : Controller
    {
        IDalZoneMaster d = new DalZoneMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        // GET: ZoneMaster
        public ActionResult Index(ZoneMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = d.GetZoneCode();
            ViewBag.ZoneCode = new SelectList(re, "umz_zone_code", "umz_zone_code");

            var a = d.GetZoneMaster(e);
            return View(a);
        }
        public ActionResult _ZoneView(ZoneMasterSearch e)
        {
            var a = d.GetZoneMaster(e);
            return PartialView(a);
        }
    }
}