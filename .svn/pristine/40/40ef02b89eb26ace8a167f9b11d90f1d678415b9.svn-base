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
    public class DalCrcaExclusion : IdalCrcaExclusion
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<CrcaExclusionDetail> Get_CrcaExclusion_AllDetails(CrcaExclusionSearch e)
        {
            List<CrcaExclusionDetail> obj = new List<CrcaExclusionDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_CRCAEXCLUSMAST_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("v_acno", e.acno));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("crca", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CrcaExclusionDetail dt = new CrcaExclusionDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.acno = reader["acno"] != DBNull.Value ? reader["acno"].ToString() : "";
                            dt.pan = reader["pan"] != DBNull.Value ? reader["pan"].ToString() : "";
                            dt.crcacode = reader["crcacode"] != DBNull.Value ? reader["crcacode"].ToString() : "";
                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];
                            dt.cacode = reader["cacode"] != DBNull.Value ? reader["cacode"].ToString() : "";
                            dt.arnno = reader["arnno"] != DBNull.Value ? reader["arnno"].ToString() : "";
                            dt.status = reader["status"] != DBNull.Value ? reader["status"].ToString() : "";
                            dt.scheme_code = reader["scheme_code"] != DBNull.Value ? reader["scheme_code"].ToString() : "";
                            obj.Add(dt);
                        }
                    }

                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal CrcaExclusion Data (CrcaExclusionDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }


        public List<CrcaExclusionDetail> GetAcno()
        {
            List<CrcaExclusionDetail> obj = new List<CrcaExclusionDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_CRCAEXCLUSMAST_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("v_acno", null));

                cmd.Parameters.Add("crca", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CrcaExclusionDetail dt = new CrcaExclusionDetail();
                            dt.acno = reader["acno"] != DBNull.Value ? reader["acno"].ToString() : "";

                            obj.Add(dt);
                        }
                    }

                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal CrcaExclusion Data (CrcaExclusionDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }

    }
}