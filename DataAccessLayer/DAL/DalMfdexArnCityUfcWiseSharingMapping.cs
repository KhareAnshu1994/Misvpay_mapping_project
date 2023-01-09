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

    public class DalMfdexArnCityUfcWiseSharingMapping : IDalMfdexArnCityUfcWiseSharingMapping
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<MfdexArnCityUfcWiseSharingDetails> GetMfdexArnCityUfcWiseSharing(MapSearchActivites e)
        {
            List<MfdexArnCityUfcWiseSharingDetails> obj = new List<MfdexArnCityUfcWiseSharingDetails>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GETALL_MFDEXCITY_UFCWISE_SHARING_MAPPING_RTL";//get_mfdex_city_ufcwise_mapping
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));

                cmd.Parameters.Add("ria", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MfdexArnCityUfcWiseSharingDetails dt = new MfdexArnCityUfcWiseSharingDetails();
                            dt.city_type = Convert.ToString(reader["city_type"]);
                            dt.krv_code = reader["krv_code"] != DBNull.Value ? reader["krv_code"].ToString() : "";
                            dt.multicity = reader["multicity"] != DBNull.Value ? reader["multicity"].ToString() : "";
                            dt.category = reader["category"] != DBNull.Value ? reader["category"].ToString() : "";
                            dt.arn_channel = reader["arn_channel"] != DBNull.Value ? reader["arn_channel"].ToString() : "";
                            dt.t5b5_status = reader["t5b5_status"] != DBNull.Value ? reader["t5b5_status"].ToString() : "";
                            dt.mfdex_city = reader["mfdex_city"] != DBNull.Value ? reader["mfdex_city"].ToString() : "";
                            dt.new_city = reader["new_city"] != DBNull.Value ? reader["new_city"].ToString() : "";
                            dt.schannel = reader["schannel"] != DBNull.Value ? reader["schannel"].ToString() : "";
                            dt.ufc_code = reader["ufc_code"] != DBNull.Value ? reader["ufc_code"].ToString() : "";
                            dt.region_code = reader["region_code"] != DBNull.Value ? reader["region_code"].ToString() : "";
                            dt.zone = reader["zone"] != DBNull.Value ? reader["zone"].ToString() : "";
                            dt.sow_ehs_perc_share = reader["sow_ehs_perc_share"] != DBNull.Value ? reader["sow_ehs_perc_share"].ToString() : "";
                            dt.sow_income_perc_share = reader["sow_income_perc_share"] != DBNull.Value ? reader["sow_income_perc_share"].ToString() : "";
                            dt.sow_lqnmm_perc_share = reader["sow_lqnmm_perc_share"] != DBNull.Value ? reader["sow_lqnmm_perc_share"].ToString() : "";
                            dt.ufc_name = reader["ufc_name"] != DBNull.Value ? reader["ufc_name"].ToString() : "";
                            dt.region_name = reader["region_name"] != DBNull.Value ? reader["region_name"].ToString() : "";
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
                    Helper.WriteLog("Dal MfdexArnCityUfcWiseSharingMapping Data (MfdexArnCityUfcWiseSharingDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }
        }
    }
}
