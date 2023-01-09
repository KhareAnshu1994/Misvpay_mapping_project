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
    public class DalArnRiaCity : IdalArnRiaCity
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();
        public List<ArnRiaCityDetail> Get_ArnRiaCity_AllDetails(MapSearchActivites e)
        {
            List<ArnRiaCityDetail> obj = new List<ArnRiaCityDetail>();
            using (OracleConnection objConn = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMapping("MISVPAY_TBL_RIA_CITY_MAPPING_RTL", e.ufc_name)))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GETALL_MISVPAY_RIA_CITY_MAPPING_RTL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("ufcname", e.ufc_name));
                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));
                cmd.Parameters.Add("aRn", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ArnRiaCityDetail dt = new ArnRiaCityDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.arnno_ref = reader["arnno_ref"] != DBNull.Value ? reader["arnno_ref"].ToString() : "";
                            dt.ria = reader["ria"] != DBNull.Value ? reader["ria"].ToString() : "";
                            dt.city = reader["city"] != DBNull.Value ? reader["city"].ToString() : "";
                            dt.distributor_name = reader["distributor_name"] != DBNull.Value ? reader["distributor_name"].ToString() : "";

                            dt.rm_code = reader["rm_code"] != DBNull.Value ? reader["rm_code"].ToString() : "";
                            dt.rm_name = reader["rm_name"] != DBNull.Value ? reader["rm_name"].ToString() : "";
                            dt.region_code = reader["region_code"] != DBNull.Value ? reader["region_code"].ToString() : "";
                            dt.region_name = reader["region_name"] != DBNull.Value ? reader["region_name"].ToString() : "";
                            dt.ufc_code = reader["ufc_code"] != DBNull.Value ? reader["ufc_code"].ToString() : "";
                            dt.ufc_name = reader["ufc_name"] != DBNull.Value ? reader["ufc_name"].ToString() : "";
                            dt.zone = reader["zone"] != DBNull.Value ? reader["zone"].ToString() : "";
                            dt.sap_ufc_code = reader["sap_ufc_code"] != DBNull.Value ? reader["sap_ufc_code"].ToString() : "";
                            dt.sap_region_code = reader["sap_region_code"] != DBNull.Value ? reader["sap_region_code"].ToString() : "";
                            dt.sap_zone_code = reader["sap_zone_code"] != DBNull.Value ? reader["sap_zone_code"].ToString() : "";
                            dt.channel_code = reader["channel_code"] != DBNull.Value ? reader["channel_code"].ToString() : "";
                            obj.Add(dt);
                        }
                    }
                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Arn Ria City Data (ArnRiaCityDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }


        #region Update ARN RIA CITY MAPPING RTL
        public Response Update_ARN_RIA_CITY_MAPPING_RTLL(List<ArnRiaCityDetail> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_RIA_CITY_MAPPING_RTL", con);
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



        #region Bulk Update Rm Code ARN RIA City to Rm Mapping
        public Response Bulk_Update_ARN_Ria_City(ArnRiaCityDetail objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_MISVPAY_TBL_RIA_CITY_MAPPING_RTL", con);
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