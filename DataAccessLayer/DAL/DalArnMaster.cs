
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
    public class DalArnMaster : IdalArnMaster
    {

        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<ArnMasterDetails> GetARNMaster(ArnMasterSearch e)
        {
            List<ArnMasterDetails> ARN = new List<ArnMasterDetails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "Get_All_ArnMaster_Data";// "get_ARNMaster_data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("krvcode", e.krv_code));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("Get_All_Data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ArnMasterDetails a = new ArnMasterDetails();
                            a.krv_code = Convert.ToString(dr["KRV_CODE"]);
                            a.channel_code = Convert.ToString(dr["CHANNEL_CODE"]);
                            a.new_br_code = Convert.ToString(dr["NEW_BR_CODE"]);
                            a.region_code = Convert.ToString(dr["REGION_CODE"]);
                            a.name = Convert.ToString(dr["NAME"]);
                            //a.dist = Convert.ToString(dr["DIST"]);
                            a.multicity_flag = Convert.ToString(dr["multicity_flag"]);
                            a.categoty = Convert.ToString(dr["CATEGORY"]);
                            //a.group_cd = Convert.ToString(dr["GROUP_CD"]);
                            //a.rm_code = Convert.ToString(dr["RMCODE"]);
                            a.zone = Convert.ToString(dr["ZONE"]);
                            a.arn_group_name = Convert.ToString(dr["ARN_GROUP_NAME"]);
                            a.sub_channel = Convert.ToString(dr["SUB_CHANNEL"]);
                            //a.arn_type = Convert.ToString(dr["ARN_TYPE"]);
                            a.valid_from = dr["VALID_FROM"] == DBNull.Value ? null : (DateTime?)dr["VALID_FROM"];
                            a.valid_upto = dr["VALID_UPTO"] == DBNull.Value ? null : (DateTime?)dr["VALID_UPTO"];
                            a.creation_date = dr["CREATION_DT"] == DBNull.Value ? null : (DateTime?)dr["CREATION_DT"];
                            a.lstupddt = dr["LST_UPDDT"] == DBNull.Value ? null : (DateTime?)dr["LST_UPDDT"];
                            a.active_flag = Convert.ToString(dr["ACTIVE_FLAG"]);
                            a.owner_type = Convert.ToString(dr["OWNER_TYPE"]);
                            a.sap_ufc_code = Convert.ToString(dr["SAP_UFC_CODE"]);
                            a.prm_code = Convert.ToString(dr["PRM_CODE"]);
                            a.channel_group = Convert.ToString(dr["CHANNEL_GROUP"]);
                            a.sap_region_code = Convert.ToString(dr["SAP_REGION_CODE"]);
                            a.sap_zone_code = Convert.ToString(dr["SAP_ZONE_CODE"]);


                            ARN.Add(a);
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                con.Close();
            }
            return ARN;
        }

        public List<ArnMasterDetails> GetKRVCode()
        {
            List<ArnMasterDetails> krv = new List<ArnMasterDetails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                //con.ConnectionString = strcon;
                cmd.Connection = con;
                cmd.CommandText = "get_distinct_krvcode";// "get_ARNMaster_data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("get_krv", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ArnMasterDetails a = new ArnMasterDetails();
                            a.krv_code = Convert.ToString(dr["KRV_CODE"]);



                            krv.Add(a);
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                con.Close();
            }
            return krv;
        }

    }
}





