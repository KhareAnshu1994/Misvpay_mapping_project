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

    public class DalMfdexArnCityUfcWiseSharingMaster : IDalMfdexArnCityUfcWiseSharingMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<MfdexArnCityUfcWiseSharingMasterDetails> GetMfdexCityWiseMaster(MfdexArnCityUfcWiseSharingMasterSearch e)
        {
            List<MfdexArnCityUfcWiseSharingMasterDetails> obj = new List<MfdexArnCityUfcWiseSharingMasterDetails>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "get_mfdexarn_city_ufcwise_mast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("krvcode", e.krv_code));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("aRn ", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MfdexArnCityUfcWiseSharingMasterDetails dt = new MfdexArnCityUfcWiseSharingMasterDetails();
                            dt.krv_code = reader["krv_code"] != DBNull.Value ? reader["krv_code"].ToString() : "";
                            dt.new_city = reader["new_city"] != DBNull.Value ? reader["new_city"].ToString() : "";
                            dt.ufc_code = reader["ufc_code"] != DBNull.Value ? reader["ufc_code"].ToString() : "";
                            dt.city_type = reader["city_type"] != DBNull.Value ? reader["city_type"].ToString() : "";
                            dt.multicity = reader["multicity"] != DBNull.Value ? reader["multicity"].ToString() : "";
                            dt.arn_name = reader["arn_name"] != DBNull.Value ? reader["arn_name"].ToString() : "";
                            dt.arn_channel = reader["arn_channel"] != DBNull.Value ? reader["arn_channel"].ToString() : "";
                            dt.t5b5_status = reader["t5b5_status"] != DBNull.Value ? reader["t5b5_status"].ToString() : "";
                            dt.mfdex_city = reader["mfdex_city"] != DBNull.Value ? reader["mfdex_city"].ToString() : "";
                            dt.schannel = reader["schannel"] != DBNull.Value ? reader["schannel"].ToString() : "";
                            dt.region_code = reader["region_code"] != DBNull.Value ? reader["region_code"].ToString() : "";
                            dt.sap_ufc_code = reader["sap_ufc_code"] != DBNull.Value ? reader["sap_ufc_code"].ToString() : "";
                            dt.zone = reader["zone"] != DBNull.Value ? reader["zone"].ToString() : "";
                            dt.sow_ehs_perc_share = reader["sow_ehs_perc_share"] != DBNull.Value ? reader["sow_ehs_perc_share"].ToString() : "";
                            dt.sow_income_perc_share = reader["sow_income_perc_share"] != DBNull.Value ? reader["sow_income_perc_share"].ToString() : "";
                            dt.sow_lqnmm_perc_share = reader["sow_lqnmm_perc_share"] != DBNull.Value ? reader["sow_lqnmm_perc_share"].ToString() : "";
                            obj.Add(dt);
                        }
                    }
                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MfdexArnCityUfcWiseSharingMaster Data (MfdexArnCityUfcWiseSharingMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }

        public List<MfdexArnCityUfcWiseSharingMasterDetails> GetkrvCode()
        {
            List<MfdexArnCityUfcWiseSharingMasterDetails> obj = new List<MfdexArnCityUfcWiseSharingMasterDetails>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "Get_distinct_krvcode2";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("aRn ", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MfdexArnCityUfcWiseSharingMasterDetails dt = new MfdexArnCityUfcWiseSharingMasterDetails();
                            dt.krv_code = reader["krv_code"] != DBNull.Value ? reader["krv_code"].ToString() : "";

                            obj.Add(dt);
                        }
                    }
                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MfdexArnCityUfcWiseSharingMaster Data (MfdexArnCityUfcWiseSharingMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }


    }
}
