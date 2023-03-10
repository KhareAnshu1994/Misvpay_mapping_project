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
    public class BdaCaMasterController : Controller
    {

        //BdaCaMaster b = new BdaCaMaster(

        // GET: BDA_CA_Master
        IDalBdaCaMaster b = new DalBdaCaMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();


        public ActionResult Index(BdaCaMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = b.GetCrcaCode();
            ViewBag.crcacode = new SelectList(re, "crcacode", "crcacode");

            var a = b.GetBdaCaMaster(e);
            return View(a);

        }
        public ActionResult _BdaCaMasterView(BdaCaMasterSearch e)
        {
            var a = b.GetBdaCaMaster(e);
            return PartialView("_BdaCaMasterView", a);

        }
    }
}