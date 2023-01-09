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
    public class DalRia : IdalRia
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<RiaDetail> Get_Ria_AllDetails(RiaMasterSearch e)
        {
            List<RiaDetail> obj = new List<RiaDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_RIAMASTER_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("ria_code", e.riacode));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("ria", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            RiaDetail dt = new RiaDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.riacode = reader["riacode"] != DBNull.Value ? reader["riacode"].ToString() : "";
                            dt.arn_code = reader["arn_code"] != DBNull.Value ? reader["arn_code"].ToString() : "";
                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];
                            dt.channel_code = reader["channel_code"] != DBNull.Value ? reader["channel_code"].ToString() : "";
                            dt.multicity = reader["multicity"] == DBNull.Value ? '\0' : Convert.ToChar(reader["multicity"]);
                            dt.ria_name = reader["ria_name"] != DBNull.Value ? reader["ria_name"].ToString() : "";
                            dt.arn_name = reader["arn_name"] != DBNull.Value ? reader["arn_name"].ToString() : "";

                            obj.Add(dt);
                        }
                    }


                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Ria Data (RiaDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }
        }

        public List<RiaDetail> GetRiaCode()
        {
            List<RiaDetail> obj = new List<RiaDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_RIAMASTER_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("ria_code", null));


                cmd.Parameters.Add("ria", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            RiaDetail dt = new RiaDetail();
                            dt.riacode = reader["riacode"] != DBNull.Value ? reader["riacode"].ToString() : "";

                            obj.Add(dt);
                        }
                    }


                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Ria Data (RiaDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }
        }


    }
}