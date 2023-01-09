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
    public class DalUser : IdalUser
    {

        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();


        public List<UserDetail> Get_User_AllDetails(UserDetailSearch e)
        {
            List<UserDetail> obj = new List<UserDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_USERMASTER_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("empid", e.emp_id));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("user", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserDetail dt = new UserDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.emp_id = reader["emp_id"] != DBNull.Value ? reader["emp_id"].ToString() : "";
                            dt.empname = reader["empname"] != DBNull.Value ? reader["empname"].ToString() : "";
                            dt.emp_role = reader["emp_role"] != DBNull.Value ? reader["emp_role"].ToString() : "";
                            dt.channel_code = reader["channel_code"] != DBNull.Value ? reader["channel_code"].ToString() : "";
                            dt.ufc_code = reader["ufc_code"] != DBNull.Value ? reader["ufc_code"].ToString() : "";
                            dt.start_date = reader["start_date"] == DBNull.Value ? null : (DateTime?)reader["start_date"];
                            dt.end_date = reader["end_date"] == DBNull.Value ? null : (DateTime?)reader["end_date"];
                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];
                            dt.status = reader["status"] != DBNull.Value ? reader["status"].ToString() : "";
                            dt.remark = reader["remark"] != DBNull.Value ? reader["remark"].ToString() : "";
                          /*  dt.dv_flag = reader["dv_flag"] != DBNull.Value ? reader["dv_flag"].ToString() : "";*/
                            dt.misvpay_code = reader["misvpay_code"] != DBNull.Value ? reader["misvpay_code"].ToString() : "";
                            dt.func_role = reader["func_role"] != DBNull.Value ? reader["func_role"].ToString() : "";

                          /*  dt.last_updated_date = reader["last_updated_date"] == DBNull.Value ? null : (DateTime?)reader["last_updated_date"];
                            dt.last_updated_user = reader["last_updated_user"] != DBNull.Value ? reader["last_updated_user"].ToString() : "";*/
                            dt.region_code = reader["region_code"] != DBNull.Value ? reader["region_code"].ToString() : "";
                          /*  dt.mail = reader["mail"] != DBNull.Value ? reader["mail"].ToString() : "";*/
                            dt.zone = reader["zone"] != DBNull.Value ? reader["zone"].ToString() : "";

                            dt.reporting_role = reader["reporting_role"] != DBNull.Value ? reader["reporting_role"].ToString() : "";
                            dt.power_user_code = reader["power_user_code"] != DBNull.Value ? reader["power_user_code"].ToString() : "";
                            dt.access_from = reader["access_from"] == DBNull.Value ? null : (DateTime?)reader["access_from"];
                            dt.access_upto = reader["access_upto"] == DBNull.Value ? null : (DateTime?)reader["access_upto"];
                            /*dt.city = reader["city"] != DBNull.Value ? reader["city"].ToString() : "";*/
                            dt.sap_ufc_code = reader["sap_ufc_code"] != DBNull.Value ? reader["sap_ufc_code"].ToString() : "";
                            dt.sap_region_code = reader["sap_region_code"] != DBNull.Value ? reader["sap_region_code"].ToString() : "";
                            dt.sap_zone_code = reader["sap_zone_code"] != DBNull.Value ? reader["sap_zone_code"].ToString() : "";


                            obj.Add(dt);
                        }
                    }


                    cmd.Dispose();
                    objConn.Close();
                }

                catch (Exception ex)
                {
                    Helper.WriteLog("Dal UserMaster Data (UserDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }


        public List<UserDetail> GetEmpId()
        {
            List<UserDetail> obj = new List<UserDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_USERMASTER_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("empid", null));


                cmd.Parameters.Add("user", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserDetail dt = new UserDetail();
                            dt.emp_id = Convert.ToString(reader["emp_id"]);

                            obj.Add(dt);
                        }
                    }


                    cmd.Dispose();
                    objConn.Close();
                }

                catch (Exception ex)
                {
                    Helper.WriteLog("Dal UserMaster Data (UserDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }



    }
}