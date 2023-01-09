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
    public class DalChannelmaster : IdalChannelmaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<ChannelmasterDetail> Get_ChannelMaster_AllDetails(ChannelmasterSearch e)
        {
            List<ChannelmasterDetail> obj = new List<ChannelmasterDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_channelmaster_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("channelccode", e.channel_code));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("chan", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ChannelmasterDetail dt = new ChannelmasterDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.channel_code = reader["channel_code"] != DBNull.Value ? reader["channel_code"].ToString() : "";
                            dt.channel_name = reader["channel_name"] != DBNull.Value ? reader["channel_name"].ToString() : "";
                            dt.chn_sap_code = reader["chn_sap_code"] != DBNull.Value ? reader["chn_sap_code"].ToString() : "";
                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];



                            obj.Add(dt);
                        }
                    }

                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Channelmaster Data (ChannelmasterDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }


        public List<ChannelmasterDetail> GetChannelCode()
        {
            List<ChannelmasterDetail> obj = new List<ChannelmasterDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_channelmaster_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("channelcode", null));

                cmd.Parameters.Add("chan", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ChannelmasterDetail dt = new ChannelmasterDetail();
                            dt.channel_code = reader["channel_code"] != DBNull.Value ? reader["channel_code"].ToString() : "";

                            obj.Add(dt);
                        }
                    }

                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Channelmaster Data (ChannelmasterDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }

    }
}