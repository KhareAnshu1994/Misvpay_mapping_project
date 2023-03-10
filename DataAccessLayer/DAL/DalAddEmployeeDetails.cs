using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.Models;
using Oracle.ManagedDataAccess.Client;

namespace Mapping_Solution.DataAccessLayer.DAL
{
    public class DalAddEmployeeDetails /* : IDALAddEmployeeDetails*/
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public Response InsertEMP(AddEmployeeDetails emp)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("Insert_USERMASTER_OR_AddEmp_Data", con);
                cmd.CommandType = CommandType.StoredProcedure;

                var a = DateTime.Now.ToString("d");
                try
                {
                    con.Open();
                    cmd.Parameters.Add(new OracleParameter("e_id", emp.EmployeeId));
                    cmd.Parameters.Add(new OracleParameter("E_Name", emp.EmployeeName));
                    cmd.Parameters.Add(new OracleParameter("Email", emp.EmailId));
                    cmd.Parameters.Add(new OracleParameter("Pass", emp.Password));
                    cmd.Parameters.Add(new OracleParameter("ch_code", emp.ChannelCode));
                    cmd.Parameters.Add(new OracleParameter("Emp_role", emp.EmployeeRole));
                    //cmd.Parameters.Add(new OracleParameter("CRM_rep", emp.CRMReportingRole));
                    //cmd.Parameters.Add(new OracleParameter("CRM_power", emp.CRMPoweruser));
                    cmd.Parameters.Add(new OracleParameter("zone", emp.Zone));
                    cmd.Parameters.Add(new OracleParameter("region", emp.Region));
                    cmd.Parameters.Add(new OracleParameter("ufc_code", emp.Loaction_Ufc));
                    cmd.Parameters.Add(new OracleParameter("functional", emp.FunctionalRole));
                    //cmd.Parameters.Add(new OracleParameter("city", emp.City));
                    cmd.Parameters.Add(new OracleParameter("start_date", emp.StartDate));
                    cmd.Parameters.Add(new OracleParameter("end_date", emp.EndDate));
                    cmd.Parameters.Add(new OracleParameter("status", emp.Status));
                    cmd.Parameters.Add(new OracleParameter("typeofmovement", emp.TypeOfMovement));
                    //cmd.Parameters.Add(new OracleParameter("petty_cash_claim", emp.PettyCashClaim));
                    cmd.Parameters.Add(new OracleParameter("select_qurter", emp.SelectQuarter));
                    cmd.Parameters.Add(new OracleParameter("valid_from", DateTime.Now));
                    //cmd.Parameters.Add(new OracleParameter("valid_upto", emp.Valid_Upto));
                    cmd.Parameters.Add(new OracleParameter("hr_valid_from", emp.HR_Valid_From));
                    cmd.Parameters.Add(new OracleParameter("hr_valid_upto", emp.HR_Valid_Upto));
                    cmd.Parameters.Add(new OracleParameter("remark", emp.Remark));
                    cmd.Parameters.Add(new OracleParameter("FILE_UPLOAD", emp.Upload));
                    cmd.Parameters.Add("out_param", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        res.message = "Email Id or Employee id already exists";
                    }
                    else
                    {
                        res.status = true;
                        res.message = "Data Inserted Successfully";
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.message = "Error in Insert Data " + ex.Message;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();

                }
            }
            return res;
        }









        //public void upload(httppostedfilebase uploadfile)
        //{
        //    try
        //    {
        //        if (uploadfile.contentlength > 0)
        //        {
        //            string filename = path.getfilename(uploadfile.filename);
        //            string folderpath = path.combine(server.mappath("~/uploadfile"), filename);
        //            uploadfile.saveas(folderpath);
        //        }
        //        viewbag.message = "file uploaded successfully";

        //    }
        //    catch
        //    {
        //        viewbag.message = "file not upload";

        //    }
        //}
    }
}





