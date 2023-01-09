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
    public class DalVirtualRmMaster : IDalVirtualRmMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<VirtualRmMasterDetails> GetVirtualMasterDetails(VirtualRmMasterSearch e)
        {
            List<VirtualRmMasterDetails> obj = new List<VirtualRmMasterDetails>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "get_all_tbl_virtual_rm_mast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("v_channel_code", e.channel_code));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            VirtualRmMasterDetails dt = new VirtualRmMasterDetails();
                            dt.channel_code = Convert.ToString(reader["channel_code"]);
                            dt.virtual_rmcode_str = reader["virtual_rmcode_str"] != DBNull.Value ? reader["virtual_rmcode_str"].ToString() : "";
                            dt.ufc_code = reader["ufc_code"] != DBNull.Value ? reader["ufc_code"].ToString() : "";
                            dt.sap_ufc_code = reader["sap_ufc_code"] != DBNull.Value ? reader["sap_ufc_code"].ToString() : "";
                            dt.ufc_name = reader["ufc_name"] != DBNull.Value ? reader["ufc_name"].ToString() : "";
                            obj.Add(dt);
                        }
                    }
                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal VirtualRmMaster Data (VirtualRmMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }

        }


    }
}