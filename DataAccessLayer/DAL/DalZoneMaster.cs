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
    public class DalZoneMaster : IDalZoneMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<ZoneMasterDetails> GetZoneMaster(ZoneMasterSearch e)
        {
            List<ZoneMasterDetails> res = new List<ZoneMasterDetails>();



            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "get_all_zone_master";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("zonecode", e.umz_zone_code));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));

                cmd.Parameters.Add("get_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    con.Open();
                    OracleDataReader rd = cmd.ExecuteReader();




                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            ZoneMasterDetails r = new ZoneMasterDetails();
                            r.umz_zone_code = Convert.ToString(rd["umz_zone_code"]);
                            r.umz_zone_description = Convert.ToString(rd["umz_zone_description"]);
                            r.umz_zone_channel = Convert.ToString(rd["umz_zone_channel"]);
                            r.umz_order_no = Convert.ToInt32(rd["umz_order_no"]);
                            r.umz_valid_from = rd["umz_valid_from"] == DBNull.Value ? null : (DateTime?)rd["umz_valid_from"];
                            r.umz_valid_upto = rd["umz_valid_upto"] == DBNull.Value ? null : (DateTime?)rd["umz_valid_upto"];
                            //r.umz_creation_date = rd["umz_creation_date"] == DBNull.Value ? null : (DateTime?)rd["umz_creation_date"];
                            //r.umz_valid_upto = Convert.ToDateTime(rd["umz_valid_upto"]);
                            //r.umz_creation_date = Convert.ToDateTime(rd["umz_creation_date"]);
                            //r.umz_created_by = Convert.ToString(rd["umz_created_by"]);
                            //r.umz_modification_date = rd["umz_modification_date"] == DBNull.Value ? null : (DateTime?)rd["umr_modification_date"];
                            //r.umz_modified_by = rd["umz_modified_by"] != DBNull.Value ? rd["umz_modified_by"].ToString() : "";
                            //r.umz_upd_type = Convert.ToChar(rd["umz_upd_type"]);



                            res.Add(r);
                        }
                    }
                }



                catch (Exception ex)
                {
                    Helper.WriteLog("Dal ZoneMaster Data (ZoneMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();

                }

                return res;
            }

        }





        public List<ZoneMasterDetails> GetZoneCode()
        {
            List<ZoneMasterDetails> res = new List<ZoneMasterDetails>();



            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "get_all_zone_master";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("zonecode", null));




                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;




                try
                {
                    con.Open();
                    OracleDataReader rd = cmd.ExecuteReader();




                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            ZoneMasterDetails r = new ZoneMasterDetails();
                            r.umz_zone_code = Convert.ToString(rd["umz_zone_code"]);



                            res.Add(r);
                        }
                    }
                }



                catch (Exception ex)
                {
                    Helper.WriteLog("Dal ZoneMaster Data (ZoneMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();

                }

                return res;
            }

        }

    }
}














