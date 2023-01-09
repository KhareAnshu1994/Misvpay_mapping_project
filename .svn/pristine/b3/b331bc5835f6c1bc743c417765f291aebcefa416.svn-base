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
    public class DalPanMaster : IdalPanMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<PanMasterDetails> GetPANMaster(PanMasterSearch e)
        {
            List<PanMasterDetails> PAN = new List<PanMasterDetails>();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "Get_All_Tbl_PanMaster_Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("arnno", e.pan_no));
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
                            PanMasterDetails a = new PanMasterDetails();
                            a.pan = Convert.ToString(dr["pan"]);
                            a.name = Convert.ToString(dr["NAME"]);
                            a.channel_code = Convert.ToString(dr["CHANNEL_CODE"]);
                            a.location = Convert.ToString(dr["LOCATION"]);
                            a.source = Convert.ToString(dr["SOURCE"]);
                           // a.rm_name = Convert.ToString(dr["RM_NAME"]);
                            a.zone = Convert.ToString(dr["ZONE"]);
                            a.sap_region_code = Convert.ToString(dr["SAP_REGION_CODE"]);
                            a.sap_zone_code = Convert.ToString(dr["SAP_ZONE_CODE"]);
                            a.group_code = Convert.ToString(dr["GROUP_CODE"]);
                            a.group_name = Convert.ToString(dr["GROUP_NAME"]);
                           // a.rh_code = Convert.ToString(dr["RH_CODE"]);
                           // a.client_group = Convert.ToString(dr["CLIENT_GROUP"]);
                            a.region_code = Convert.ToString(dr["REGION_CODE"]);
                            a.valid_from = dr["VALID_FROM"] == DBNull.Value ? null : (DateTime?)dr["VALID_FROM"];
                            a.valid_upto = dr["VALID_UPTO"] == DBNull.Value ? null : (DateTime?)dr["VALID_UPTO"];


                            PAN.Add(a);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;

                }
                con.Close();
            }
            return PAN;
        }

        public List<PanMasterDetails> GetPanNumber()
        {
            List<PanMasterDetails> PAN = new List<PanMasterDetails>();


            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "Get_All_Tbl_PanMaster_Data";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("panno", null));


                cmd.Parameters.Add("Get_All_Data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PanMasterDetails a = new PanMasterDetails();
                            a.pan = Convert.ToString(dr["PAN"]);

                            PAN.Add(a);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;

                }
                con.Close();
            }
            return PAN;
        }



    }
}