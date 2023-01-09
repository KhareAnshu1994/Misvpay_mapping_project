using Mapping_Solution.CustomHelper;
using Mapping_Solution.DataAccessLayer.DAL;
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mapping_Solution.Controllers
{
    [CustomAuthorize]
    public class MappingChangesAccessController : Controller
    {
        IdalMappingChangesAccess change = new DalMappingChangesAccess();
        IdalChannelmaster chnl = new DalChannelmaster();
        IDalRegionMaster reg = new DalRegionMaster();
        IdalUfcMaster UFC = new DalUfcMaster();
        IdalReasonMaster reason = new DalReasonMaster();
        IdalLogin login = new DalLogin();


        // GET: MappingChangesAccess

        public ActionResult Index(UfcMasterSearch e, ReasonMasterSearch objSearch, MappingChangeAccessSearch mapChangeSearch)
        {
            var rea = reason.ReadAllData(objSearch);
            ViewBag.reasoncode = new SelectList(rea, "reason_codes", "reason_code_description");


            var region = reg.GetRegionCode();
            ViewBag.region = new SelectList(region, "umr_region_code", "umr_region_code");

            var mapcriteria = change.GetMappingCriteria();
            ViewBag.MappingCriteria = new SelectList(mapcriteria, "table_name", "page_name");

            var ch = chnl.GetChannelCode();
            ViewBag.channelcode = new SelectList(ch, "channel_code", "channel_code");

            var purp = change.GetPurpose();     // it has seperate table
            ViewBag.Purpose = new SelectList(purp, "purpose_id", "purpose");

            var ufcResult = UFC.GetUFCMaster(e); // It is Coming From Ufc Master
            ViewBag.Ufccode = ufcResult.Select(N => new SelectListItem { Text = N.ufc_name, Value = N.ufc_code });


            var a = change.GetMappingChangesAccess(mapChangeSearch);
            return View(a);
        }

        public ActionResult _MappingChangesAccessView(MappingChangeAccessSearch mapChangeSearch)
        {
            var a = change.GetMappingChangesAccess(mapChangeSearch);
            return PartialView("_MappingChangesAccessView", a);
        }


        public JsonResult InsertChangingAccess(MappingChangesAccessDetail emp)
        {

            emp.created_by = UserManager.User.Employee_id;
            var a = emp.channel_code == "INST" ? change.InsertMappingChangeAccess_INST(emp) : change.InsertMappingChangeAccess(emp);
            return Json(a);
        }

        [HttpPost]
        public JsonResult UpdateActivity(ActivityCompleteDetails objAct)
        {
            var result = change.CompleteTransactionActivity(objAct);
            if (result.status == true)
            {
                MappingAceesEditDetails map = new MappingAceesEditDetails();
                map.employee_code = UserManager.User.Employee_id;
                var mapdetails = login.GetMappingAceessEditDetails(map);
                var useDetails = UserManager.User;
                useDetails.mapping_details_edit = mapdetails;
                string UserDetails = JsonConvert.SerializeObject(useDetails);
                Session["UserDetails"] = UserDetails;
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult FinalSubmit(List<FinalSubmissionDetails> obj)
        {
            var result = change.FinalSubmission(obj);
            return Json(result);
        }


        [HttpPost]
        public JsonResult FinalSubmissionINST(List<FinalSubmissionDetails> obj)
        {
            var result = change.FinalSubmissionINST(obj);
            return Json(result);
        }

        [HttpPost]
        public JsonResult MoveDatatoProduction(List<FinalSubmissionDetails> obj)
        {
            var result = change.MoveDatatoProduction(obj);
            return Json(result);
        }

        IdalMappingChangesAccess map = new DalMappingChangesAccess();
        public ActionResult AddMappingChangeAccessRecord(MappingChangeAccessSearch mapChangeSearch)
        {

            var qt = map.GetStage();
            ViewBag.stage = new SelectList(qt, "stage_id", "stage_name");

            var a = change.GetMappingChangesAccess(mapChangeSearch);


            return View(a);
        }


        public JsonResult GetUFCList(UfcMasterSearch e)
        {

            var ufcResult = UFC.GetUFCMaster(e);

            return Json(ufcResult);
        }

        public JsonResult UpdateSplitData(List<SplitMappingData> e)
        {

            var ufcResult = change.UpdateSplitData(e);

            return Json(ufcResult);
        }

        [HttpPost]
        public JsonResult Save_action(MappingChangesAccessDetail obj)
        {
            var result = change.Save_action(obj);
            return Json(result);
        }

    }
}