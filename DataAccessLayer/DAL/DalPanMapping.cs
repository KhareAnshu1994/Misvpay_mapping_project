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
    public class DalPanMapping : IdalPanMapping
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();


        public List<PanMappingDetails> GetPANMapping(MapSearchActivites e)
        {
            List<PanMappingDetails> PANMAPPING = new List<PanMappingDetails>();
            using (OracleConnection con = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMapping("MISVPAY_TBL_PANMAPPING_RTL", e.ufc_name)))
            {
                OracleCommand cmd = new OracleCommand("GET_ALL_TBL_PANMAPPING_DATA_RTL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("ufcname", e.ufc_name));
                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));

                cmd.Parameters.Add("Get_All_Data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PanMappingDetails p = new PanMappingDetails();
                            p.id = Convert.ToInt32(dr["id"]);
                            p.pan = Convert.ToString(dr["PAN"]);
                            p.client_name = Convert.ToString(dr["client_name"]);
                            p.rm_code = Convert.ToString(dr["RM_CODE"]);
                            p.rm_name = Convert.ToString(dr["RM_NAME"]);
                            p.rh_code = Convert.ToString(dr["RH_CODE"]);
                            p.valid_from = dr["VALID_FROM"] == DBNull.Value ? null : (DateTime?)dr["VALID_FROM"];
                            p.group_name = dr["GROUP_NAME"] != DBNull.Value ? dr["GROUP_NAME"].ToString() : "";
                            p.source = Convert.ToString(dr["SOURCE"]);
                            p.creation_date = dr["CREATION_DATE"] == DBNull.Value ? null : (DateTime?)dr["CREATION_DATE"];
                            p.group_code = Convert.ToString(dr["GROUP_CODE"]);
                            p.region_code = Convert.ToString(dr["GROUP_CODE"]);
                            p.region_name = Convert.ToString(dr["REGION_CODE"]);
                            p.location = Convert.ToString(dr["LOCATION"]);
                            p.ufc_name = Convert.ToString(dr["UFC_NAME"]);
                            p.zone = Convert.ToString(dr["ZONE"]);
                            p.sap_ufc_code = Convert.ToString(dr["SAP_UFC_CODE"]);
                            p.sap_region_code = dr["sap_region_code"] != DBNull.Value ? dr["sap_region_code"].ToString() : "";
                            p.sap_zone_code = dr["sap_zone_code"] != DBNull.Value ? dr["sap_zone_code"].ToString() : "";
                            p.channel_code = dr["channel_code"] != DBNull.Value ? dr["channel_code"].ToString() : "";
                            p.aum_perc = dr["aum_perc"] == DBNull.Value ? '\0' : Convert.ToInt32(dr["aum_perc"]);

                            PANMAPPING.Add(p);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal PanMapping Data (PanMappingDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                con.Close();
            }
            return PANMAPPING;
        }

        #region Update PAN MAPPING RTL
        public Response Update_PAN_MAPPING_RTL(List<PanMappingDetails> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_PANMAPPING_RTL", con);
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

        #region Bulk Update Rm Code PAN MAPPING RTL
        public Response Bulk_Update_PAN_MAPPING_RTL(PanMappingDetails objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    //for (int i = 0; i < objList.Count; i++)
                    //{
                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_MISVPAY_TBL_PANMAPPING_RTL", con);
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

                    //}
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