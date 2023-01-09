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
    public class ArnMasterController : Controller
    {
        // GET: ARN_Master
        IdalArnMaster ARN = new DalArnMaster();

        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(ArnMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");


            var re = ARN.GetKRVCode();
            ViewBag.krv = new SelectList(re, "krv_code", "krv_code");

            var a = ARN.GetARNMaster(e);

            return View(a);
        }
        public ActionResult _ArnView(ArnMasterSearch e)
        {

            var a = ARN.GetARNMaster(e);
            return PartialView("_ArnView",a);
        }
    }
}