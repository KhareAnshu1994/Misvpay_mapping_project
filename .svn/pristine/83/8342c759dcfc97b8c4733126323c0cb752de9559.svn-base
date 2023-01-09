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

    public class DalMfdexMapNewcityDirect : IDalMfdexMapNewcityDirect
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();


        public List<MfdexMapNewcityDirectDetails> GetMfdexMapNewcityDirect(MapSearchActivites e)
        {
            List<MfdexMapNewcityDirectDetails> lst = new List<MfdexMapNewcityDirectDetails>();

            using (OracleConnection conn = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMapping("MISVPAY_TBL_DIRECT_GROUP_OF_CITIES_TO_RMMAPPING_RTL", e.ufc_name)))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GETALL_DIRECT_GROUPOF_CITIES_TO_RMMAPPING_RTL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("ufcname", e.ufc_name));
                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));

                cmd.Parameters.Add("Get_All_Data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            MfdexMapNewcityDirectDetails r = new MfdexMapNewcityDirectDetails();
                            r.id = Convert.ToInt32(rd["id"]);
                            r.arn = rd["arn"] != DBNull.Value ? rd["arn"].ToString() : "";
                            r.new_city = rd["new_city"] != DBNull.Value ? rd["new_city"].ToString() : "";
                            r.rm_code = rd["rm_code"] != DBNull.Value ? rd["rm_code"].ToString() : "";
                            r.rm_name = rd["rm_name"] != DBNull.Value ? rd["rm_name"].ToString() : "";
                            r.region_code = rd["region_code"] != DBNull.Value ? rd["region_code"].ToString() : "";
                            r.region_name = rd["region_name"] != DBNull.Value ? rd["region_name"].ToString() : "";
                            r.ufc_code = rd["ufc_code"] != DBNull.Value ? rd["ufc_code"].ToString() : "";
                            r.ufc_name = rd["ufc_name"] != DBNull.Value ? rd["ufc_name"].ToString() : "";
                            r.sap_ufc_code = rd["sap_ufc_code"] != DBNull.Value ? rd["sap_ufc_code"].ToString() : "";
                            r.sap_region_code = rd["sap_region_code"] != DBNull.Value ? rd["sap_region_code"].ToString() : "";
                            r.sap_zone_code = rd["sap_zone_code"] != DBNull.Value ? rd["sap_zone_code"].ToString() : "";
                            r.channel_code = rd["channel_code"] != DBNull.Value ? rd["channel_code"].ToString() : "";
                            r.aaum_equity_perc_share = rd["aaum_equity_perc_share"] != DBNull.Value ? rd["aaum_equity_perc_share"].ToString() : "";
                            r.saaum_hybrid_perc_share = rd["saaum_hybrid_perc_share"] != DBNull.Value ? rd["saaum_hybrid_perc_share"].ToString() : "";
                            r.aaum_arbitrage_perc_share = rd["aaum_arbitrage_perc_share"] != DBNull.Value ? rd["aaum_arbitrage_perc_share"].ToString() : "";
                            r.aaum_fixed_income_perc_share = rd["aaum_fixed_income_perc_share"] != DBNull.Value ? rd["aaum_fixed_income_perc_share"].ToString() : "";
                            r.aaum_cash_perc_share = rd["aaum_cash_perc_share"] != DBNull.Value ? rd["aaum_cash_perc_share"].ToString() : "";


                            //r.sow_ehs_perc_share = Convert.ToInt32(rd["sow_ehs_perc_share"]);
                            //r.sow_income_perc_share = Convert.ToInt32(rd["sow_income_perc_share"]);
                            //r.sow_lqnmm_perc_share = Convert.ToInt32(rd["sow_lqnmm_perc_share"]);
                            lst.Add(r);
                        }
                    }


                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MfdexMapNewcityDirect Data (MfdexMapNewcityDirectDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                conn.Close();
            }



            return lst.OrderBy(x => x.arn).ToList();
        }


        #region Update DIRECT GROUP OF CITIES TO RMMAPPING RTL
        public Response Update_DIRECT_GROUP_OF_CITIES_TO_RMMAPPING_RTL(List<MfdexMapNewcityDirectDetails> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_DIRECT_GROUP_OF_CITIES_TO_RMMAPPING_RTL", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        var split_rm_code = objList[i].rm_code.Split('|');

                        var arr_rm_code = split_rm_code.ToArray();



                        cmd.Parameters.Add(new OracleParameter("v_id", objList[i].id));
                        cmd.Parameters.Add(new OracleParameter("v_rm_code", arr_rm_code[0]));
                        cmd.Parameters.Add(new OracleParameter("v_rm_code", arr_rm_code[1]));


                        cmd.ExecuteNonQuery();

                        if (cmd.ExecuteNonQuery() < 0)
                        {
                            res.status = true;
                            res.message = "Data Updated Successfully";
                        }
                        else
                        {
                            res.status = false;
                            res.message = "Data not Updated";
                        }

                    }
                }
                catch (Exception ex)
                {
                    res.message = "Error in Update Data " + ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
            return res;

        }

        #endregion;


        #region Bulk Update Rm Code Direct Group of City to Rm Mapping
        public Response Bulk_Update_DirectGroup_of_City(MfdexMapNewcityDirectDetails objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_misvpay_tbl_direct_group_of_cities_to_rmmapping_rtl", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    var split_new_rm = objModel.New_rmcode.Split('|');

                    var new_rm = split_new_rm.ToArray();

                    var split_old_rm = objModel.Old_rmcode.Split('|');
                    var old_rm = split_old_rm.ToArray();

                    cmd.Parameters.Add(new OracleParameter("S_rm_code", new_rm[0]));
                    cmd.Parameters.Add(new OracleParameter("p_rm_code", old_rm[0]));
                    cmd.Parameters.Add(new OracleParameter("S_rm_name", new_rm[1]));

                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() < 0)
                    {
                        res.status = true;
                        res.message = "RM Code Replaced Successfully";
                    }
                    else
                    {
                        res.status = false;
                        res.message = "RM Code not Replaced Successfully";
                    }

                }
                catch (Exception ex)
                {
                    res.message = "Error in Update Data " + ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
            return res;

        }

        #endregion;

    }
}