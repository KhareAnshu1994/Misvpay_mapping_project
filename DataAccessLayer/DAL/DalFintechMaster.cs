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
    public class DalFintechMaster : IdalFintechMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<FintechMasterDetails> GetFINTECHMaster(FintechMasterSearch e)
        {
            List<FintechMasterDetails> FINTECH = new List<FintechMasterDetails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "Get_All_Tbl_FintechMaster_Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("arnriacode", e.arn_ria_code));
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
                            FintechMasterDetails f = new FintechMasterDetails();
                            f.arn_ria_code = Convert.ToString(dr["ARN_RIA_CODE"]);
                            f.multicity_flag_am = Convert.ToString(dr["MULTICITY_FLAG_AM"]);
                            f.channel = Convert.ToString(dr["CHANNEL"]);
                            f.family_arn_code = Convert.ToString(dr["FAMILY_ARN_CODE"]);
                            f.family_arn_name = Convert.ToString(dr["FAMILY_ARN_NAME"]);
                            f.group_type = Convert.ToString(dr["GROUP_TYPE"]);
                            f.mfd_group = Convert.ToString(dr["MFD_GROUP"]);
                            f.arn_type = Convert.ToString(dr["ARN_TYPE"]);
                            f.strategic_team_rm = Convert.ToString(dr["STRATEGIC_TEAM_RM"]);
                            f.fintech_type = Convert.ToString(dr["FINTECH_TYPE"]);
                            f.fintech_rm_code = Convert.ToString(dr["FINTECH_RM_CODE"]);
                            f.valid_from = dr["VALID_FROM"] == DBNull.Value ? null : (DateTime?)dr["VALID_FROM"];
                            f.valid_upto = dr["VALID_UPTO"] == DBNull.Value ? null : (DateTime?)dr["VALID_UPTO"];

                            FINTECH.Add(f);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                con.Close();
            }

            return FINTECH;
        }

        public List<FintechMasterDetails> GetArnRiaCode()
        {
            List<FintechMasterDetails> FINTECH = new List<FintechMasterDetails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "Get_All_Tbl_FintechMaster_Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("arnriacode", null));


                cmd.Parameters.Add("Get_All_Data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            FintechMasterDetails f = new FintechMasterDetails();
                            f.arn_ria_code = Convert.ToString(dr["ARN_RIA_CODE"]);


                            FINTECH.Add(f);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                con.Close();
            }

            return FINTECH;
        }


    }
}