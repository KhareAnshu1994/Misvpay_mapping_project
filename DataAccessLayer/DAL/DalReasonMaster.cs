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
    public class DalReasonMaster : IdalReasonMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<ReasonMasterDetail> ReadAllData(ReasonMasterSearch e)
        {

            List<ReasonMasterDetail> list_data = new List<ReasonMasterDetail>();

            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_ReasonMasters_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                //  cmd.Parameters.Add(new OracleParameter("pincode", e.pincode));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("reasonmast", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            ReasonMasterDetail dt = new ReasonMasterDetail();

                            dt.reason_codes = reader["reason_codes"] != DBNull.Value ? reader["reason_codes"].ToString() : "";
                            dt.reason_code_description = reader["reason_code_description"] != DBNull.Value ? reader["reason_code_description"].ToString() : "";



                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal ReasonMaster Data (ReasonMasterDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();
            }



            return list_data;
        }

    }
}