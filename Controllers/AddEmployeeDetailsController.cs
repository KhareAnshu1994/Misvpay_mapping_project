﻿using Mapping_Solution.CustomHelper;
using Mapping_Solution.DataAccessLayer.DAL;
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Mapping_Solution.Controllers
{
    [CustomAuthorize]
    public class AddEmployeeDetailsController : Controller
    {
        // GET: AddEmployeeDetails



        IDalRegionMaster reg = new DalRegionMaster();
        IdalChannelmaster chnl = new DalChannelmaster();
        IDalZoneMaster z = new DalZoneMaster();
        IdalUfcMaster UFC = new DalUfcMaster();
        IdalListOfRoles r = new DalListOfRoles();
        IDalCamsCityUfcMaster d = new DalCamsCityUfcMaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(UfcMasterSearch e)
        {

            var ch = chnl.GetChannelCode();
            ViewBag.channel = new SelectList(ch, "channel_code", "channel_code");

            var empRole = r.GetListOfRoles();// It is coming from list of role
            ViewBag.EmpRole = new SelectList(empRole, "code", "name");

            var region = reg.GetRegionCode();
            ViewBag.region = new SelectList(region, "umr_region_code", "umr_region_name");

            //var re = drop.GetRegion();
            //ViewBag.region = new SelectList(re, "Region_code", "Region");

            var zo = z.GetZoneCode();
            ViewBag.Zone = new SelectList(zo, "umz_zone_code", "umz_zone_code");

            var ufc = UFC.GetUFCMaster(e); // It is Coming From Ufc Master
            ViewBag.Location = new SelectList(ufc, "ufc_code", "ufc_name");

            var res = r.GetListOfRoles();// It is coming from list of role
            ViewBag.Rolename = new SelectList(res, "srno", "name");

            //var city = d.GetCityMfdexPlus(); // It's coming from Cams City Ufc Master
            //ViewBag.City = new SelectList(city, "city_mfdex_plus", "city_mfdex_plus");

            var st = drop.GetStatus();
            ViewBag.Status = new SelectList(st, "status_id", "Status");

            var mo = drop.GetMovement();
            ViewBag.Movement = new SelectList(mo, "movement_id", "TypeOfMovement");

            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "quarter_id", "SelectQuarter");

            //var ch = chnl.GetChannelCode();
            //ViewBag.channel = new SelectList(ch, "channel_code", "channel_code");

            //var region = reg.GetRegionCode();
            //ViewBag.region = new SelectList(region, "umr_region_code", "umr_region_name");

            //var zo = z.GetZoneCode();
            //ViewBag.Zone = new SelectList(zo, "umz_zone_code", "umz_zone_code");

            //var ufc = UFC.GetUFCMaster(e); // It is Coming From Ufc Master
            //ViewBag.Location = new SelectList(ufc, "ufc_code", "ufc_name");


            //var res = r.Get_Name();// It is coming from list of role
            //ViewBag.Rolename = new SelectList(res, "code", "name");


            //var city = d.GetCityMfdexPlus(); // It's coming from Cams City Ufc Master
            //ViewBag.City = new SelectList(city, "city_mfdex_plus", "city_mfdex_plus");


            //var rl = drop.GetEMPRole();// It is coming from list of role
            //ViewBag.role = new SelectList(rl, "EmployeeRole", "EmployeeRole");

            //var st = drop.GetStatus();
            //ViewBag.Status = new SelectList(st, "Status", "Status");

            //var mo = drop.GetMovement();
            //ViewBag.Movement = new SelectList(mo, "TypeOfMovement", "TypeOfMovement");

            //var qt = drop.GetQuarter();
            //ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            return View();
        }

        [HttpPost]
        public JsonResult create(AddEmployeeDetails e)
        {
            DalAddEmployeeDetails add = new DalAddEmployeeDetails();
            return Json(add.InsertEMP(e));
        }

        [HttpPost]
        public JsonResult Upload()
        {
            var attatchment = "";
            var fname="";
            bool status = false;
            DalAddEmployeeDetails add = new DalAddEmployeeDetails();
            HttpFileCollectionBase files = Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
               // string fname;
                fname = file.FileName;
                fname = Path.Combine(Server.MapPath("~/UploadFile/"), fname); // Get the complete folder path and store the file inside it.  
                file.SaveAs(fname);
                status = true;
            }
            attatchment = String.Join(("~/UploadFile/"), fname);
            if (status == true)
            {
                ViewBag.message = "File uploaded successfully";
            }
            else
            {
                ViewBag.message = "File not uploaded successfully";
            }
            return Json(ViewBag.message);
        }


    }
}