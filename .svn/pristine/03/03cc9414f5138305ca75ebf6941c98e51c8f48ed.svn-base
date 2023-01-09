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
    public class DalMapDsit : IDalMapDsit
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();

        public List<MapDsitDetails> GetMapDsitInst(MapSearchActivites e)
        {
            List<MapDsitDetails> lst = new List<MapDsitDetails>();

            using (OracleConnection conn = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMappingInst("MISVPAY_TBL_MAP_DSIT_INST", e.region_code)))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GET_ALL_TBL_MAP_DSIT_INST";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("v_region_code", e.region_code));

                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));

                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            MapDsitDetails r = new MapDsitDetails();

                            r.id = Convert.ToInt32(rd["id"]);
                            r.arn_number = rd["arn_number"] != DBNull.Value ? rd["arn_number"].ToString() : "";
                            r.arn_name = rd["arn_name"] != DBNull.Value ? rd["arn_name"].ToString() : "";
                            r.ufc_area_code = rd["ufc_area_code"] != DBNull.Value ? rd["ufc_area_code"].ToString() : "";
                            r.ufc_area_name = rd["ufc_area_name"] != DBNull.Value ? rd["ufc_area_name"].ToString() : "";
                            r.rm_code = rd["rm_code"] != DBNull.Value ? rd["rm_code"].ToString() : "";
                            r.rm_name = rd["rm_name"] != DBNull.Value ? rd["rm_name"].ToString() : "";

                            r.region_code = rd["region_code"] != DBNull.Value ? rd["region_code"].ToString() : "";
                            r.region_name = rd["region_name"] != DBNull.Value ? rd["region_name"].ToString() : "";
                            r.zone = rd["zone"] != DBNull.Value ? rd["zone"].ToString() : "";
                            r.sap_ufc_code = rd["sap_ufc_code"] != DBNull.Value ? rd["sap_ufc_code"].ToString() : "";
                            r.sap_region_code = rd["sap_region_code"] != DBNull.Value ? rd["sap_region_code"].ToString() : "";
                            r.sap_zone_code = rd["sap_zone_code"] != DBNull.Value ? rd["sap_zone_code"].ToString() : "";
                            r.channel_code = rd["channel_code"] != DBNull.Value ? rd["channel_code"].ToString() : "";

                            lst.Add(r);
                        }
                    }


                }
                catch (Exception ex)
                {
                    Helper.WriteLog("DalMapDsit Data (MapDsitDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                conn.Close();
            }



            return lst;
        }


        #region Update MAP DSIT INST Mapping
        public Response UpdateMapDsit(List<MapDsitDetails> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_MAP_DSIT_INST", con);
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

        #region Bulk Update Rm Code MAP DSIT Mapping INST 
        public Response Bulk_Update_MAP_DSIT_Mapping_INST(MapDsitDetails objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_MISVPAY_TBL_MAP_DSIT_INST", con);
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
