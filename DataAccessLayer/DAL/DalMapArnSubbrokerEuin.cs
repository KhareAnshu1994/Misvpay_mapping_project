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

    public class DalMapArnSubbrokerEuin : IDalMapArnSubbrokerEuin
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();

        public List<MapArnSubbrokerEuinDetails> GetMapArnSubbrokerEuin(MapSearchActivites e)
        {
            List<MapArnSubbrokerEuinDetails> res = new List<MapArnSubbrokerEuinDetails>();

            using (OracleConnection con = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMapping("MISVPAY_TBL_ARNEUIN_SUB_ARN_BRANCH_CODE_MAPPING_RTL", e.ufc_name)))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "GETALL_ARNEUIN_SUB_ARN_BRANCH_CODE_MAPPING_RTL";//get_all_map_arn_subbroker_euin
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("ufcname", e.ufc_name));
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
                            MapArnSubbrokerEuinDetails r = new MapArnSubbrokerEuinDetails();
                            r.id = Convert.ToInt32(rd["id"]);
                            r.arn = Convert.ToString(rd["arn"]);
                            r.distributor_name = Convert.ToString(rd["distributor_name"]);
                            r.subbroker_euin = Convert.ToString(rd["subbroker_euin"]);
                            r.rm_code = Convert.ToString(rd["rm_code"]);
                            r.rm_name = Convert.ToString(rd["rm_name"]);
                            r.valid_from = rd["valid_from"] == DBNull.Value ? null : (DateTime?)rd["valid_from"];
                            r.ufc_code = rd["ufc_code"] != DBNull.Value ? rd["ufc_code"].ToString() : "";
                            r.ufc_name = rd["ufc_name"] != DBNull.Value ? rd["ufc_name"].ToString() : "";
                            r.region_code = rd["region_code"] != DBNull.Value ? rd["region_code"].ToString() : "";
                            r.region_name = rd["region_name"] != DBNull.Value ? rd["region_name"].ToString() : "";
                            r.zone = rd["zone"] != DBNull.Value ? rd["zone"].ToString() : "";
                            r.sap_ufc_code = rd["sap_ufc_code"] != DBNull.Value ? rd["sap_ufc_code"].ToString() : "";
                            r.sap_region_code = rd["sap_region_code"] != DBNull.Value ? rd["sap_region_code"].ToString() : "";
                            r.sap_zone_code = rd["sap_zone_code"] != DBNull.Value ? rd["sap_zone_code"].ToString() : "";
                            r.channel_code = rd["channel_code"] != DBNull.Value ? rd["channel_code"].ToString() : "";


                            res.Add(r);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MapArnSubbrokerEuin Data (MapArnSubbrokerEuinDetails Model) ERROR :" + ex.Message);
                    throw;
                }

                cmd.Dispose();
                con.Close();

                return res;
            }
        }

        #region Update ARNEUIN SUB ARN BRANCH CODE MAPPING RTL
        public Response Update_ARNEUIN_SUB_ARN_BRANCH_CODE_MAPPING_RTL(List<MapArnSubbrokerEuinDetails> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_ARNEUIN_SUB_ARN_BRANCH_CODE_MAPPING_RTL", con);
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


        #region Bulk Update Rm Code ARNEUIN SUB ARN BRANCH CODE MAPPING RTL
        public Response Bulk_Update_ARNEUIN_SUB_ARN_BRANCH_CODE(MapArnSubbrokerEuinDetails objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    //for (int i = 0; i < objList.Count; i++)
                    //{
                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_MISVPAY_TBL_ARNEUIN_SUB_ARN_BRANCH_CODE_MAPPING_RTL", con);
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
