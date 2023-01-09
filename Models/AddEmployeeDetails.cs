using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class AddEmployeeDetails
    {
        public int status_id { get; set; }
        public int movement_id { get; set; }
        public int quarter_id { get; set; }
        public int listofrole_srno { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ChannelCode { get; set; }
    //    public string ChannelName { get; set; }
        public string EmployeeRole { get; set; }
        public string CRMReportingRole { get; set; }
        public string CRMPoweruser { get; set; }
        public string Zone { get; set; }
        public string Region { get; set; }
        public string Region_code { get; set; }
        public string Loaction_Ufc { get; set; }
        public string FunctionalRole { get; set; }
        public string City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string PettyCashClaim { get; set; }
        public string SelectQuarter { get; set; }
        public DateTime? Valid_from { get; set; }
        public DateTime? Valid_Upto { get; set; }
        public DateTime? HR_Valid_From { get; set; }
        public DateTime? HR_Valid_Upto { get; set; }
        public string Remark { get; set; }
        public string TypeOfMovement { get; set; }
        public string Upload { get; set; }

    }
    public class UploadFileViewModel
    {
        public string FileName { get; set; }
        public HttpPostedFileBase Document { get; set; }
    }


}