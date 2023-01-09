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

    public class DalCamsCityUfcMaster : IDalCamsCityUfcMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<CamsCityUfcMasterDetails> GetCAMS_City_UFC(CamsCityUfcMasterSearch e)
        {
            List<CamsCityUfcMasterDetails> lst = new List<CamsCityUfcMasterDetails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "get_all_tbl_cams_city_ufc_mast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("citymfdexplus", e.city_mfdex_plus));


                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            CamsCityUfcMasterDetails r = new CamsCityUfcMasterDetails();

                            //r.id = Convert.ToInt32(rd["id"]);
                            r.city_mfdex_plus = Convert.ToString(rd["city_mfdex_plus"]);
                            r.region = Convert.ToString(rd["region"]);
                            r.amfi_category = Convert.ToString(rd["amfi_category"]);
                            r.group_city = rd["group_city"] != DBNull.Value ? rd["group_city"].ToString() : "";
                            r.mis_city_category = rd["mis_city_category"] != DBNull.Value ? rd["mis_city_category"].ToString() : "";
                            r.valid_from = (DateTime?)rd["valid_from"];
                            r.valid_upto = (DateTime?)rd["valid_upto"];
                            r.t5_b5 = Convert.ToString(rd["t5_b5"]);
                            r.ufc_code = rd["ufc_code"] != DBNull.Value ? rd["ufc_code"].ToString() : "";
                            r.ufc_name = rd["ufc_name"] != DBNull.Value ? rd["ufc_name"].ToString() : "";
                            r.region_code = rd["region_code"] != DBNull.Value ? rd["region_code"].ToString() : "";
                            r.dofa_cat = rd["dofa_cat"] != DBNull.Value ? rd["dofa_cat"].ToString() : "";
                            r.bnd_city = rd["bnd_city"] != DBNull.Value ? rd["bnd_city"].ToString() : "";
                            r.zone = rd["zone"] != DBNull.Value ? rd["zone"].ToString() : "";
                            r.imc_location = rd["imc_location"] != DBNull.Value ? rd["imc_location"].ToString() : "";
                            r.bnd_region = rd["bnd_region"] != DBNull.Value ? rd["bnd_region"].ToString() : "";
                            r.imc_region = rd["imc_region"] != DBNull.Value ? rd["imc_region"].ToString() : "";
                            r.city_group = rd["citygroup"] != DBNull.Value ? rd["citygroup"].ToString() : "";
                            r.ufc_location = rd["ufc_location"] != DBNull.Value ? rd["ufc_location"].ToString() : "";
                            r.group_name = rd["group_name"] != DBNull.Value ? rd["group_name"].ToString() : "";
                            r.dofa_sub_category = rd["dofa_sub_category"] != DBNull.Value ? rd["dofa_sub_category"].ToString() : "";

                            lst.Add(r);
                        }
                    }



                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal CamsCityUfcmaster (CamsCityUfcMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }


            }
            return lst;
        }

        public List<CamsCityUfcMasterDetails> GetCityMfdexPlus()
        {
            List<CamsCityUfcMasterDetails> lst = new List<CamsCityUfcMasterDetails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "get_all_tbl_cams_city_ufc_mast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("citymfdexplus", null));


                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            CamsCityUfcMasterDetails r = new CamsCityUfcMasterDetails();

                            r.city_mfdex_plus = Convert.ToString(rd["city_mfdex_plus"]);

                            lst.Add(r);
                        }
                    }



                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal CamsCityUfcmaster (CamsCityUfcMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }


            }
            return lst;
        }

    }
}

