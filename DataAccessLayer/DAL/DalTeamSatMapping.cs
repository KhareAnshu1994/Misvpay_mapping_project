﻿using Mapping_Solution.DataAccessLayer.InterfaceDAL;
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
    public class DalTeamSatMapping : IdalTeamSatMapping
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<TeamSatMappingDetail> Get_TeamSatMapping_AllDetails(MapSearchActivites e)
        {

            List<TeamSatMappingDetail> list_data = new List<TeamSatMappingDetail>();

            using (OracleConnection objConn = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMapping("MISVPAY_TBL_TEAMSATMAPPING_RTL", e.ufc_name)))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GETALL_MISVPAY_TEAMSATMAPPING_RTL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("ufcname", e.ufc_name));
                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));

                cmd.Parameters.Add("sat", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            TeamSatMappingDetail dt = new TeamSatMappingDetail();
                            dt.id = Convert.ToInt32(reader["id"]);

                            dt.arn_code = reader["arn_code"] != DBNull.Value ? reader["arn_code"].ToString() : "";
                            dt.distributors_name = reader["distributors_name"] != DBNull.Value ? reader["distributors_name"].ToString() : "";
                            dt.multicity_am = reader["multicity_am"] != DBNull.Value ? reader["multicity_am"].ToString() : "";
                            dt.channel = reader["channel"] != DBNull.Value ? reader["channel"].ToString() : "";
                            dt.family_arn_code = reader["family_arn_code"] != DBNull.Value ? reader["family_arn_code"].ToString() : "";

                            dt.family_arn_name = reader["family_arn_name"] != DBNull.Value ? reader["family_arn_name"].ToString() : "";
                            dt.group_type = reader["group_type"] != DBNull.Value ? reader["group_type"].ToString() : "";
                            dt.mfd_group = reader["mfd_group"] != DBNull.Value ? reader["mfd_group"].ToString() : "";
                            dt.segment = reader["segment"] != DBNull.Value ? reader["segment"].ToString() : "";

                            dt.strategic_team_rm_1 = reader["strategic_team_rm_1"] != DBNull.Value ? reader["strategic_team_rm_1"].ToString() : "";
                            dt.employee_code_rm_1 = reader["employee_code_rm_1"] != DBNull.Value ? reader["employee_code_rm_1"].ToString() : "";
                            dt.strategic_team_rm_2 = reader["strategic_team_rm_2"] != DBNull.Value ? reader["strategic_team_rm_2"].ToString() : "";
                            dt.employee_code_rm_2 = reader["employee_code_rm_2"] != DBNull.Value ? reader["employee_code_rm_2"].ToString() : "";
                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];
                            dt.arn_channel = reader["arn_channel"] != DBNull.Value ? reader["arn_channel"].ToString() : "";

                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal TeamSatMapping Data (TeamSatMappingDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();
            }



            return list_data;
        }
    }
}