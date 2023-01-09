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

    public class DalBdaCaMaster : IDalBdaCaMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<BdaCaMasterDeatails> GetBdaCaMaster(BdaCaMasterSearch e)
        {
            List<BdaCaMasterDeatails> lst = new List<BdaCaMasterDeatails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "get_all_tbl_bda_ca_mast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("citymfdexplus", e.crcacode));
                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));


                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            BdaCaMasterDeatails r = new BdaCaMasterDeatails();

                            r.crcacode = Convert.ToString(rd["crcacode"]);
                            r.region = Convert.ToString(rd["region"]);
                            r.ufc = Convert.ToString(rd["ufc"]);
                            r.ufc_code = Convert.ToString(rd["ufc_code"]);
                            r.dist_code = Convert.ToString(rd["dist_code"]);
                            r.crcode = Convert.ToString(rd["crcode"]);
                            r.district_name = Convert.ToString(rd["district_name"]);
                            r.cacode = Convert.ToString(rd["cacode"]);
                            r.ufc_hq = rd["ufc_hq"] != DBNull.Value ? rd["ufc_hq"].ToString() : "";
                            r.name_cr = rd["name_cr"] != DBNull.Value ? rd["name_cr"].ToString() : "";
                            r.status = rd["status"] != DBNull.Value ? rd["status"].ToString() : "";
                            r.date_of_app = (DateTime?)rd["date_of_app"];
                            r.address1 = rd["address1"] != DBNull.Value ? rd["address1"].ToString() : "";
                            r.address2 = rd["address2"] != DBNull.Value ? rd["address2"].ToString() : "";
                            r.address3 = rd["address3"] != DBNull.Value ? rd["address3"].ToString() : "";
                            r.address4 = rd["address4"] != DBNull.Value ? rd["address4"].ToString() : "";
                            r.phone_no = rd["phoneno"] != DBNull.Value ? rd["phoneno"].ToString() : "";
                            r.mobile_no = rd["mobileno"] != DBNull.Value ? rd["mobileno"].ToString() : "";
                            r.email = Convert.ToString(rd["email"]);
                            r.date_of_birth = (DateTime?)rd["date_of_birth"];
                            r.draweebank_brcode = rd["draweebank_brcode"] != DBNull.Value ? rd["draweebank_brcode"].ToString() : "";
                            r.acno_altbranchcode = rd["acno_altbranchcode"] != DBNull.Value ? rd["acno_altbranchcode"].ToString() : "";
                            r.valid_from = (DateTime?)rd["valid_from"];
                            r.valid_upto = (DateTime?)rd["valid_upto"];
                            r.paybel_loc = rd["paybel_loc"] != DBNull.Value ? rd["paybel_loc"].ToString() : "";
                            r.branch_name = rd["branch_name"] != DBNull.Value ? rd["branch_name"].ToString() : "";
                            r.ifsc_code = rd["ifsc_code"] != DBNull.Value ? rd["ifsc_code"].ToString() : "";
                            r.status_dosm = rd["status_dosm"] != DBNull.Value ? rd["status_dosm"].ToString() : "";
                            r.fixed_pay = Convert.ToInt32(rd["fixed_pay"]);
                            r.zone = rd["zone"] != DBNull.Value ? rd["zone"].ToString() : "";
                            r.sap_ufc_code = rd["status_dosm"] != DBNull.Value ? rd["sap_ufc_code"].ToString() : "";
                            r.sap_region_code = rd["sap_region_code"] != DBNull.Value ? rd["sap_region_code"].ToString() : "";
                            r.sap_zone_code = rd["sap_zone_code"] != DBNull.Value ? rd["sap_zone_code"].ToString() : "";
                            r.arn_number = rd["arn_number"] != DBNull.Value ? rd["arn_number"].ToString() : "";
                            r.arn_validity = (DateTime?)rd["arn_validity"];
                            r.gst_number = rd["gst_number"] != DBNull.Value ? rd["gst_number"].ToString() : "";
                            r.pan_no = rd["pan_no"] != DBNull.Value ? rd["pan_no"].ToString() : "";
                            r.gst_valid = Convert.ToString(rd["gst_valid"]);
                            r.maharashtra = Convert.ToString(rd["maharashtra"]);
                            r.rbp = Convert.ToInt32(rd["rbp"]);
                            r.etsp = Convert.ToInt32(rd["etsp"]);
                            r.uti_infra_fund = Convert.ToInt32(rd["uti_infra_fund"]);
                            r.bdaca_uti_email = rd["bdaca_uti_email"] != DBNull.Value ? rd["bdaca_uti_email"].ToString() : "";



                            lst.Add(r);
                        }
                    }



                }
                catch (Exception ex)
                {

                    Helper.WriteLog("Dal BdaCa Master Data (BdaCaMasterDeatails Model) ERROR :" + ex.Message);
                    throw;
                }


            }
            return lst;
        }


        public List<BdaCaMasterDeatails> GetCrcaCode()
        {
            List<BdaCaMasterDeatails> lst = new List<BdaCaMasterDeatails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "get_all_tbl_bda_ca_mast";
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
                            BdaCaMasterDeatails r = new BdaCaMasterDeatails();

                            r.crcacode = Convert.ToString(rd["crcacode"]);


                            lst.Add(r);
                        }
                    }



                }
                catch (Exception ex)
                {

                    Helper.WriteLog("Dal BdaCa Master Data (BdaCaMasterDeatails Model) ERROR :" + ex.Message);
                    throw;
                }


            }
            return lst;
        }

    }
}
