using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.DAL
{
    public class DALEmployeeDetails : IDALEmployeeDetails
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<EmployeeDetails> GetEmployeeDetails(EmployeeDetailsSearch emp)
        {
            List<EmployeeDetails> EMP = new List<EmployeeDetails>();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("GET_ALL_TBL_EMPLOYEEDETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("EMP_ID", emp.EmployeeId));
                cmd.Parameters.Add(new OracleParameter("Emp_Name", emp.EmployeeName));
                cmd.Parameters.Add(new OracleParameter("CHANNELCODE", emp.ChannelCode));
                cmd.Parameters.Add(new OracleParameter("V_STATUS", emp.Status));
                cmd.Parameters.Add(new OracleParameter("EMP_ROLE", emp.EmployeeRole));
                cmd.Parameters.Add(new OracleParameter("LOCATIONUFC", emp.LocationUfc));



                cmd.Parameters.Add("Get_All_Data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EmployeeDetails a = new EmployeeDetails();
                            a.Id = dr["Id"] == DBNull.Value ? '\0' : Convert.ToInt32(dr["Id"]);
                            a.EmployeeId = Convert.ToString(dr["EMP_ID"]);
                            a.EmployeeName = Convert.ToString(dr["EMPNAME"]);
                            a.ChannelCode = Convert.ToString(dr["CHANNEL_CODE"]);
                            a.EmployeeRole = Convert.ToString(dr["EMP_ROLE"]);
                            a.Region = Convert.ToString(dr["REGION_CODE"]);
                            a.Loaction_Ufc = Convert.ToString(dr["UFC_CODE"]);
                            a.StartDate = (DateTime)dr["START_DATE"];
                         // a.StartDate = dr["START_DATE"] == DBNull.Value ? null : (DateTime?)dr["START_DATE"];
                            a.EndDate = (DateTime)dr["END_DATE"];
                            //     a.EndDate = dr["END_DATE"] == DBNull.Value ? null : (DateTime?)dr["END_DATE"];
                            a.HR_Valid_From = (DateTime)dr["HR_VALID_FROM"];
                            //     a.HR_Valid_From = dr["HR_VALID_FROM"] == DBNull.Value ? null : (DateTime?)dr["HR_VALID_FROM"];
                            a.HR_Valid_Upto = (DateTime)dr["HR_VALID_UPTO"];
                            //      a.HR_Valid_Upto = dr["HR_VALID_UPTO"] == DBNull.Value ? null : (DateTime?)dr["HR_VALID_UPTO"];
                            a.Status = Convert.ToString(dr["STATUS"]);
                            a.FunctionalRole = Convert.ToString(dr["FUNCTIONAL_ROLE"]);

                            EMP.Add(a);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Employee Details Data (EmployeeDetails Model) ERROR :" + ex.Message);

                    throw;
                }
                con.Close();
            }

            return EMP;
        }
        public List<EmployeeDetails> GetEmployeeID()
        {
            List<EmployeeDetails> EMP = new List<EmployeeDetails>();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("Get_All_Tbl_EmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("EMP_ID", null));
                cmd.Parameters.Add(new OracleParameter("Emp_Name", null));
                cmd.Parameters.Add(new OracleParameter("CHANNELCODE", null));
                cmd.Parameters.Add(new OracleParameter("V_STATUS", null));
                cmd.Parameters.Add(new OracleParameter("EMP_ROLE", null)); ;
                cmd.Parameters.Add(new OracleParameter("LOCATIONUFC", null));





                cmd.Parameters.Add("Get_All_Data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EmployeeDetails a = new EmployeeDetails();
                            a.EmployeeId = Convert.ToString(dr["EMP_ID"]);
                            a.EmployeeName = Convert.ToString(dr["EMPNAME"]);


                            EMP.Add(a);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal BnndMapPincodeArn Data (BnndMapPincodeArnDetails Model) ERROR :" + ex.Message);

                    throw;
                }
                con.Close();
            }

            return EMP;
        }

        public List<EmployeeDetails> GetEmployeeDetails_id(EmployeeDetails objEmployeeDetails)
        {
            List<EmployeeDetails> EMP = new List<EmployeeDetails>();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("MISVPAY_EmployeeDetail_Edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("ID", objEmployeeDetails.Id));







                cmd.Parameters.Add("edit", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EmployeeDetails a = new EmployeeDetails();





                            a.Id = Convert.ToInt32(dr["Id"]);
                            a.EmployeeId = dr["EMP_ID"] != DBNull.Value ? dr["EMP_ID"].ToString() : "";
                            a.EmployeeName = dr["EmpName"] != DBNull.Value ? dr["EmpName"].ToString() : "";
                            a.EmailId = dr["Email_Id"] != DBNull.Value ? dr["Email_Id"].ToString() : "";
                            a.Password = dr["Password"] != DBNull.Value ? dr["Password"].ToString() : "";
                            a.ChannelCode = dr["Channel_Code"] != DBNull.Value ? dr["Channel_Code"].ToString() : "";
                            a.EmployeeRole = dr["Emp_Role"] != DBNull.Value ? dr["Emp_Role"].ToString() : "";

                            a.Zone = dr["Zone"] != DBNull.Value ? dr["Zone"].ToString() : "";
                            a.Region = dr["Region_code"] != DBNull.Value ? dr["Region_code"].ToString() : "";
                            a.Loaction_Ufc = dr["UFC_code"] != DBNull.Value ? dr["UFC_code"].ToString() : "";
                            a.FunctionalRole = dr["FUNCTIONAL_ROLE"] != DBNull.Value ? dr["FUNCTIONAL_ROLE"].ToString() : "";
                            //a.City = dr["City"] != DBNull.Value ? dr["City"].ToString() : "";

                            a.StartDate = (DateTime)dr["START_DATE"];

                         //       a.StartDate = dr["START_DATE"] == DBNull.Value ? null : (DateTime?)dr["START_DATE"];
                            a.EndDate = (DateTime)dr["END_DATE"];
                            //   a.EndDate = dr["END_DATE"] == DBNull.Value ? null : (DateTime?)dr["END_DATE"];
                            a.Status = dr["Status"] != DBNull.Value ? dr["Status"].ToString() : "";

                            a.SelectQuarter = dr["Select_Quarter"] != DBNull.Value ? dr["Select_Quarter"].ToString() : "";
                            a.Valid_from = (DateTime)dr["Valid_from"];
                            //    a.Valid_from = dr["Valid_from"] == DBNull.Value ? null : (DateTime?)dr["Valid_from"];
                            a.Valid_Upto = (DateTime)dr["Valid_Upto"];
                            //    a.Valid_Upto = dr["Valid_Upto"] == DBNull.Value ? null : (DateTime?)dr["Valid_Upto"];
                            a.HR_Valid_From = (DateTime)dr["HR_Valid_From"];
                            //     a.HR_Valid_From = dr["HR_Valid_From"] == DBNull.Value ? null : (DateTime?)dr["HR_Valid_From"];
                            a.HR_Valid_Upto = (DateTime)dr["HR_Valid_Upto"];
                            //     a.HR_Valid_Upto = dr["HR_Valid_Upto"] == DBNull.Value ? null : (DateTime?)dr["HR_Valid_Upto"];
                            a.Remark = dr["Remark"] != DBNull.Value ? dr["Remark"].ToString() : "";
                            a.TypeOfMovement = dr["TypeOfMovement"] != DBNull.Value ? dr["TypeOfMovement"].ToString() : "";








                            EMP.Add(a);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal EmployeeDetails Data (EmployeeDetails Model) ERROR :" + ex.Message);





                    throw;
                }
                con.Close();
            }





            return EMP;
        }



    }
}
