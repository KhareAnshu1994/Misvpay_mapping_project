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

    public class DalMapRiaCode : IdalMapRiaCode
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();

        public List<MapRiaCodeDetails> GetMapRiaCode(MapSearchActivites e)
        {
            List<MapRiaCodeDetails> MAPPINCODE = new List<MapRiaCodeDetails>();
            using (OracleConnection con = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMapping("MISVAY_TBL_RIA_TO_RM_MAPPING_RTL", e.ufc_name)))
            {
                OracleCommand cmd = new OracleCommand("GET_ALL_TBL_RIA_TO_RM_MAPPING_RTL", con);
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
                            MapRiaCodeDetails m = new MapRiaCodeDetails();
                            m.id = Convert.ToInt32(dr["id"]);
                            m.ria = Convert.ToString(dr["RIA"]);
                            m.ufc_code = Convert.ToString(dr["UFC_CODE"]);
                            m.distributor_name = Convert.ToString(dr["distributor_name"]);
                            m.arnno_ref = Convert.ToString(dr["ARN_NO_REF"]);
                            m.allocation = dr["ALLOCATION"] == DBNull.Value ? '\0' : Convert.ToChar(dr["ALLOCATION"]);
                            m.rm_code = Convert.ToString(dr["rm_code"]);
                            m.ufc_name = Convert.ToString(dr["UFC_NAME"]);
                            m.valid_from = dr["VALID_FROM"] == DBNull.Value ? null : (DateTime?)dr["VALID_FROM"];
                            m.city = Convert.ToString(dr["CITY"]);
                            m.rm_ufc_code = Convert.ToString(dr["RM_UFC_CODE"]);
                            m.rm_ufc_name = Convert.ToString(dr["RM_UFC_NAME"]);
                            m.region_code = Convert.ToString(dr["REGION_CODE"]);
                            m.region_name = Convert.ToString(dr["REGION_NAME"]);
                            m.zone = Convert.ToString(dr["ZONE"]);
                            m.sap_ufc_code = Convert.ToString(dr["SAP_UFC_CODE"]);
                            m.sap_region_code = dr["sap_region_code"] != DBNull.Value ? dr["sap_region_code"].ToString() : "";
                            m.sap_zone_code = dr["sap_zone_code"] != DBNull.Value ? dr["sap_zone_code"].ToString() : "";
                            m.channel_code = dr["channel_code"] != DBNull.Value ? dr["channel_code"].ToString() : "";

                            MAPPINCODE.Add(m);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MapRiaCode Data (MapRiaCodeDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                con.Close();
            }
            return MAPPINCODE;
        }

        #region Update RIA TO RM MAPPING RTL
        public Response Update_RIA_TO_RM_MAPPING_RTL(List<MapRiaCodeDetails> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVAY_TBL_RIA_TO_RM_MAPPING_RTL", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new OracleParameter("v_id", objList[i].id));
                        cmd.Parameters.Add(new OracleParameter("v_rm_code", objList[i].rm_code));


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


        #region Bulk Update Rm Code RIA TO RM MAPPING RTL
        public Response Bulk_Update_RIA_TO_RM_MAPPING(MapRiaCodeDetails objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    //for (int i = 0; i < objList.Count; i++)
                    //{
                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_MISVAY_TBL_RIA_TO_RM_MAPPING_RTL", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new OracleParameter("S_rm_code", objModel.Replace_rmcode));
                    cmd.Parameters.Add(new OracleParameter("p_rm_code", objModel.old_rmcode));


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