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
    public class DalSchemeCategory : IdalSchemeCategory
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<SchemeCategoryDetail> Get_SchemeCategory_AllDetails(SchemeCategorySearch e)
        {
            List<SchemeCategoryDetail> obj = new List<SchemeCategoryDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_SCHEMECATMASTER_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("schemecode", e.scheme_code));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("category", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SchemeCategoryDetail dt = new SchemeCategoryDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.scheme_code = reader["scheme_code"] != DBNull.Value ? (int)Convert.ToInt64(reader["scheme_code"]) : 0;
                           
                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];
                            dt.scheme_name = reader["scheme_name"] != DBNull.Value ? reader["scheme_name"].ToString() : "";
                            dt.sub_fund_code = reader["sub_fund_code"] != DBNull.Value ? reader["sub_fund_code"].ToString() : "";
                            dt.karvy_scheme_code = reader["karvy_scheme_code"] != DBNull.Value ? reader["karvy_scheme_code"].ToString() : "";
                            dt.plan = reader["plan"] != DBNull.Value ? reader["plan"].ToString() : "";
                            dt.new_sebi_scheme_type = reader["new_sebi_scheme_type"] != DBNull.Value ? reader["new_sebi_scheme_type"].ToString() : "";
                            dt.new_sebi_category = reader["new_sebi_category"] != DBNull.Value ? reader["new_sebi_category"].ToString() : "";
                            dt.new_sebi_sub_category = reader["new_sebi_sub_category"] != DBNull.Value ? reader["new_sebi_sub_category"].ToString() : "";
                            dt.cams_category = reader["cams_category"] != DBNull.Value ? reader["cams_category"].ToString() : "";
                            dt.amfi_category = reader["amfi_category"] != DBNull.Value ? reader["amfi_category"].ToString() : "";
                            dt.mis_category = reader["mis_category"] != DBNull.Value ? reader["mis_category"].ToString() : "";
                            dt.mis_sub_category = reader["mis_sub_category"] != DBNull.Value ? reader["mis_sub_category"].ToString() : "";

                            obj.Add(dt);
                        }
                    }


                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal SchemeCategory Data (SchemeCategoryDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }


        public List<SchemeCategoryDetail> GetSchemeCode()
        {

            List<SchemeCategoryDetail> obj = new List<SchemeCategoryDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GET_DISTINCT_SCHEMCODE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("get_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SchemeCategoryDetail dt = new SchemeCategoryDetail();
                          /*  dt.scheme_code = Convert.ToInt32(reader["scheme_code"]);*/
                            dt.scheme_code = reader["scheme_code"] != DBNull.Value ? (int)Convert.ToInt64(reader["scheme_code"]) : 0;
                            obj.Add(dt);
                        }
                    }


                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal SchemeCategory Data (SchemeCategoryDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }
    }
}