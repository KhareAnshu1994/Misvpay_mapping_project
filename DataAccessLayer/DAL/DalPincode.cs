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
    public class DalPincode : IdalPincode

    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<PincodeMasterDetail> ReadAllData(PincodeMasterSearch e)
        {

            List<PincodeMasterDetail> list_data = new List<PincodeMasterDetail>();

            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_PINCODEMASTER_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("pincode", e.pincode));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("pRc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            PincodeMasterDetail dt = new PincodeMasterDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.pincode = Convert.ToInt32(reader["pincode"]);
                            dt.ufc_code = reader["ufc_code"] != DBNull.Value ? reader["ufc_code"].ToString() : "";
                            dt.dist_cd = reader["dist_cd"] != DBNull.Value ? reader["dist_cd"].ToString() : "";
                            dt.dist_name = reader["dist_name"] != DBNull.Value ? reader["dist_name"].ToString() : "";
                            dt.city_as_per_cams = reader["city_as_per_cams"] != DBNull.Value ? reader["city_as_per_cams"].ToString() : "";
                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];
                            dt.city_as_per_amfi = reader["city_as_per_amfi"] != DBNull.Value ? reader["city_as_per_amfi"].ToString() : "";
                         /*   dt.district = reader["district"] != DBNull.Value ? reader["district"].ToString() : "";*/


                            dt.t30b30 = reader["t30b30"] != DBNull.Value ? reader["t30b30"].ToString() : "";
                            dt.t5b5 = reader["t5b5"] != DBNull.Value ? reader["t5b5"].ToString() : "";
                            dt.t15b15 = reader["t15b15"] != DBNull.Value ? reader["t15b15"].ToString() : "";

                            dt.t8b8 = reader["t8b8"] != DBNull.Value ? reader["t8b8"].ToString() : "";

                            dt.dofa_pin_category = reader["dofa_pin_category"] != DBNull.Value ? reader["dofa_pin_category"].ToString() : "";

                            dt.ufc_location = reader["ufc_location"] != DBNull.Value ? reader["ufc_location"].ToString() : "";

                            dt.sap_ufc_code = reader["sap_ufc_code"] != DBNull.Value ? reader["sap_ufc_code"].ToString() : "";
                            dt.sap_region_code = reader["sap_region_code"] != DBNull.Value ? reader["sap_region_code"].ToString() : "";
                            dt.sap_zone_code = reader["sap_zone_code"] != DBNull.Value ? reader["sap_zone_code"].ToString() : "";
                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Pincode Data (PincodeMasterDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();
            }



            return list_data;
        }


        public List<PincodeMasterDetail> GetPinCode()
        {
            var i = 0;

            List<PincodeMasterDetail> list_data = new List<PincodeMasterDetail>();

            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_PINCODEMASTER_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("pincode", i));


                cmd.Parameters.Add("pRc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            PincodeMasterDetail dt = new PincodeMasterDetail();
                            dt.pincode = Convert.ToInt32(reader["pincode"]);

                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Pincode Data (PincodeMasterDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();
            }



            return list_data;
        }

    }
}