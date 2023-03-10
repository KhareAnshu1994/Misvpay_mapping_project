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
    public class DalTeamSatMap : IdalTeamSatMap
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();


        public List<TeamSatMapDetail> Get_TeamSatMap_AllDetails(MapSearchActivites e)
        {

            List<TeamSatMapDetail> list_data = new List<TeamSatMapDetail>();

            using (OracleConnection objConn = new OracleConnection(CustomHelper.CustomHelper.getConnectionStringForMapping("MISVPAY_TBL_TEAMSATMAP_RTL", e.ufc_name)))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GETALL_MISVPAY_TEAMSATMAP_RTL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("ufcname", e.ufc_name));
                //cmd.Parameters.Add(new OracleParameter("search_text", e.quarter));

                cmd.Parameters.Add("teamsat", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            TeamSatMapDetail dt = new TeamSatMapDetail();
                            dt.id = Convert.ToInt32(reader["id"]);

                            dt.emp_code = reader["emp_code"] != DBNull.Value ? reader["emp_code"].ToString() : "";
                            dt.name = reader["name"] != DBNull.Value ? reader["name"].ToString() : "";
                            dt.band = reader["band"] != DBNull.Value ? reader["band"].ToString() : "";
                            dt.designation = reader["designation"] != DBNull.Value ? reader["designation"].ToString() : "";
                            dt.segment = reader["segment"] != DBNull.Value ? reader["segment"].ToString() : "";

                            dt.function = reader["function"] != DBNull.Value ? reader["function"].ToString() : "";
                            dt.reporting_to = reader["reporting_to"] != DBNull.Value ? reader["reporting_to"].ToString() : "";
                            dt.relationships_handled = reader["relationships_handled"] != DBNull.Value ? reader["relationships_handled"].ToString() : "";
                            dt.reporting_to_emplid = reader["reporting_to_emplid"] != DBNull.Value ? reader["reporting_to_emplid"].ToString() : "";

                            dt.sat_groupcode = reader["sat_groupcode"] != DBNull.Value ? reader["sat_groupcode"].ToString() : "";

                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];

                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal TeamSatMap  Data (TeamSatMapDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();
            }



            return list_data;
        }
    }
}