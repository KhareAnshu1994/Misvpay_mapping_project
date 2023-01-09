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
    public class DalMapArnInstitution : IdalMapArnInstitution
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();


        public List<MapArnInstitutionDetail> GetMapArnInstitution(MapSearchActivites e)
        {
            List<MapArnInstitutionDetail> obj = new List<MapArnInstitutionDetail>();

            using (OracleConnection con = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMappingInst("MISVPAY_TBL_MAP_ARN_INST", e.region_code)))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "GETALL_MISVPAY_MAP_ARN_INST";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("v_region_code", e.region_code));

                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));

                cmd.Parameters.Add("mapiarn", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                try
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MapArnInstitutionDetail dt = new MapArnInstitutionDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.krv_code = reader["krv_code"] != DBNull.Value ? reader["krv_code"].ToString() : "";
                            dt.name = reader["name"] != DBNull.Value ? reader["name"].ToString() : "";
                            dt.channel_code = reader["channel_code"] != DBNull.Value ? reader["channel_code"].ToString() : "";
                            dt.rm_code = reader["rm_code"] != DBNull.Value ? reader["rm_code"].ToString() : "";
                            dt.rm_name = reader["rm_name"] != DBNull.Value ? reader["rm_name"].ToString() : "";
                            dt.category = reader["category"] != DBNull.Value ? reader["category"].ToString() : "";
                            dt.sub_channel = reader["sub_channel"] != DBNull.Value ? reader["sub_channel"].ToString() : "";

                            dt.region_code = reader["region_code"] != DBNull.Value ? reader["region_code"].ToString() : "";
                            dt.region_name = reader["region_name"] != DBNull.Value ? reader["region_name"].ToString() : "";
                            dt.zone = reader["zone"] != DBNull.Value ? reader["zone"].ToString() : "";
                            dt.sap_ufc_code = reader["sap_ufc_code"] != DBNull.Value ? reader["sap_ufc_code"].ToString() : "";
                            dt.sap_region_code = reader["sap_region_code"] != DBNull.Value ? reader["sap_region_code"].ToString() : "";
                            dt.sap_zone_code = reader["sap_zone_code"] != DBNull.Value ? reader["sap_zone_code"].ToString() : "";



                            obj.Add(dt);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MapArnInstitution Data (MapArnInstitutionDetail Model) ERROR :" + ex.Message);
                    throw;
                }

                cmd.Dispose();
                con.Close();

                return obj;
            }
        }


        #region Update MAP ARN INST Mapping
        public Response UpdateMapArnInst(List<MapArnInstitutionDetail> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_MAP_ARN_INST", con);
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


        #region Bulk Update Rm Code Map ARN Inst Mapping
        public Response Bulk_Update_MapArn_Inst(MapArnInstitutionDetail objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_MISVPAY_TBL_MAP_ARN_INST", con);
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