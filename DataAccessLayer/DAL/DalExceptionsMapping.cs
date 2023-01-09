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
    public class DalExceptionsMapping : IdalExceptionsMapping
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();

        public List<ExceptionsMappingDetails> GetExceptionsMapping(MapSearchActivites e)
        {
            List<ExceptionsMappingDetails> res = new List<ExceptionsMappingDetails>();

            using (OracleConnection con = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMapping("MISVPAY_TBL_EXCEPTIONSMAPPING_RTL", e.ufc_name)))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "GET_ALL_TBL_EXCEPTIONSMAPPING_DATA_RTL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("ufcname", e.ufc_name));
                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));

                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ExceptionsMappingDetails exc = new ExceptionsMappingDetails();
                            exc.id = Convert.ToInt32(dr["id"]);
                            exc.exception_id = dr["EXCEPTION_ID"] != DBNull.Value ? dr["EXCEPTION_ID"].ToString() : "";
                            exc.rm_code = dr["rm_code"] != DBNull.Value ? dr["rm_code"].ToString() : "";
                            exc.rm_name = dr["rm_name"] != DBNull.Value ? dr["rm_name"].ToString() : "";
                            exc.case_type = dr["CASE_TYPE"] != DBNull.Value ? '\0' : Convert.ToChar(dr["CASE_TYPE"]);
                            exc.region = dr["region_code"] != DBNull.Value ? dr["region_code"].ToString() : "";
                            exc.region_name = dr["region_name"] != DBNull.Value ? dr["region_name"].ToString() : "";
                            exc.ufc_code = dr["ufc_code"] != DBNull.Value ? dr["ufc_code"].ToString() : "";
                            exc.ufc_name = dr["ufc_name"] != DBNull.Value ? dr["ufc_name"].ToString() : "";
                            exc.zone = dr["zone"] != DBNull.Value ? dr["zone"].ToString() : "";
                            exc.sap_ufc_code = dr["sap_ufc_code"] != DBNull.Value ? dr["sap_ufc_code"].ToString() : "";
                            exc.sap_region_code = dr["sap_region_code"] != DBNull.Value ? dr["sap_region_code"].ToString() : "";
                            exc.sap_zone_code = dr["sap_zone_code"] != DBNull.Value ? dr["sap_zone_code"].ToString() : "";
                            exc.channel_code = dr["channel_code"] != DBNull.Value ? dr["channel_code"].ToString() : "";
                            exc.aum_perc = dr["aum_perc"] == DBNull.Value ? '\0' : Convert.ToInt32(dr["aum_perc"]);

                            res.Add(exc);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Exception Mapping Data (ExceptionsMappingDetails Model) ERROR" + ex.Message);

                    throw;
                }

                cmd.Dispose();
                con.Close();

                return res;
            }
        }


        #region Update EXCEPTIONS MAPPING RTL
        public Response Update_EXCEPTIONS_MAPPING_RTL(List<ExceptionsMappingDetails> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_EXCEPTIONSMAPPING_RTL", con);
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


        #region Bulk Update Rm Code EXCEPTIONS MAPPING RTL
        public Response Bulk_Update_EXCEPTIONS_MAPPING_RTL(ExceptionsMappingDetails objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    //for (int i = 0; i < objList.Count; i++)
                    //{
                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_MISVPAY_TBL_EXCEPTIONSMAPPING_RTL", con);
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