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
    public class DalSchemeCatConversion : IdalSchemeCatConversion
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();


        public List<SchemeCatConversionDetail> Get_SchemeCatConversion_AllDetails(SchemeCatConversioSearch e)
        {
            List<SchemeCatConversionDetail> obj = new List<SchemeCatConversionDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_SHMECONVERMAST_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("schemetype", String.IsNullOrEmpty(e.scheme_type) ? null : e.scheme_type));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));

                cmd.Parameters.Add("converse", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SchemeCatConversionDetail dt = new SchemeCatConversionDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.scheme_type = reader["scheme_type"] != DBNull.Value ? reader["scheme_type"].ToString() : "";
                            dt.source = reader["source"] != DBNull.Value ? reader["source"].ToString() : "";
                            dt.mis_sub_category = reader["mis_sub_category"] != DBNull.Value ? reader["mis_sub_category"].ToString() : "";
                            dt.mis_category = reader["mis_category"] != DBNull.Value ? reader["mis_category"].ToString() : "";
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
                    Helper.WriteLog("Dal SchemeCatConversion Data (SchemeCatConversionDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }



        public List<SchemeCatConversionDetail> GetSchemeType()
        {
            List<SchemeCatConversionDetail> obj = new List<SchemeCatConversionDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GET_DISTINCT_SCHEMETYPE";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("converse", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SchemeCatConversionDetail dt = new SchemeCatConversionDetail();
                            dt.scheme_type = reader["scheme_type"] != DBNull.Value ? reader["scheme_type"].ToString() : "";

                            obj.Add(dt);
                        }
                    }


                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal SchemeCatConversion Data (SchemeCatConversionDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }


    }
}