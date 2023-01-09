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
    public class DalImcPanGroupcodeMaster : IdalImcPanGroupcodeMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<ImcPanGroupcodeMasterDetail> Get_ImcPanGroupcode_AllDetails(ImcPanGroupcodeMasterSearch e)
        {
            //ResponseData<T> ObjRes = new ResponseData<T>();
            List<ImcPanGroupcodeMasterDetail> list_data = new List<ImcPanGroupcodeMasterDetail>();

            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_imcpangroupcodemast_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("groupcode", e.groupcode));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("imc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            ImcPanGroupcodeMasterDetail dt = new ImcPanGroupcodeMasterDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.groupcode = reader["groupcode"] != DBNull.Value ? reader["groupcode"].ToString() : "";
                            dt.pan_no = reader["pan_no"] != DBNull.Value ? reader["pan_no"].ToString() : "";
                            dt.type = reader["type"] != DBNull.Value ? reader["type"].ToString() : "";
                            dt.region_code = reader["region_code"] != DBNull.Value ? reader["region_code"].ToString() : "";
                            dt.name = reader["name"] != DBNull.Value ? reader["name"].ToString() : "";
                            dt.clientgroup = reader["clientgroup"] != DBNull.Value ? reader["clientgroup"].ToString() : "";
                            dt.group_no = Convert.ToInt32(reader["group_no"]);

                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];
                            dt.creationdt = reader["creationdt"] == DBNull.Value ? null : (DateTime?)reader["creationdt"];
                            dt.lstupddt = reader["lstupddt"] == DBNull.Value ? null : (DateTime?)reader["lstupddt"];

                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal ImcPanGroupcodeMaster Data (ImcPanGroupcodeMasterDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();



                return list_data;
            }
        }

        public List<ImcPanGroupcodeMasterDetail> GetGroupCode()
        {
            //ResponseData<T> ObjRes = new ResponseData<T>();
            List<ImcPanGroupcodeMasterDetail> list_data = new List<ImcPanGroupcodeMasterDetail>();

            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_imcpangroupcodemast_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("groupcode", null));
                cmd.Parameters.Add(new OracleParameter("quarter", null));


                cmd.Parameters.Add("imc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            ImcPanGroupcodeMasterDetail dt = new ImcPanGroupcodeMasterDetail();
                            dt.groupcode = reader["groupcode"] != DBNull.Value ? reader["groupcode"].ToString() : "";


                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal ImcPanGroupcodeMaster Data (ImcPanGroupcodeMasterDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();



                return list_data;
            }
        }

    }
}