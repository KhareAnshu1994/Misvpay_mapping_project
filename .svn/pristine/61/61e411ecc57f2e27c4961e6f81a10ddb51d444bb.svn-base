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
    public class DalAssignRoleToUsers : IdalAssignRoleToUsers
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        public List<AssignRoleToUsersDetail> Get_AssignRoleToUsers_AllDetails()
        {
            List<AssignRoleToUsersDetail> obj = new List<AssignRoleToUsersDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_AssignRoleToUsers_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("assigning", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AssignRoleToUsersDetail dt = new AssignRoleToUsersDetail();
                            dt.Id = reader["Id"] != DBNull.Value ? reader["Id"].ToString() : "";
                            dt.Channel_code = reader["Channel_code"] != DBNull.Value ? reader["Channel_code"].ToString() : "";
                            dt.Employee_Name = reader["Employee_Name"] != DBNull.Value ? reader["Employee_Name"].ToString() : "";
                            dt.Functional_role = reader["Functional_role"] != DBNull.Value ? reader["Functional_role"].ToString() : "";

                            obj.Add(dt);
                        }
                    }
                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal AssignRoleToUsers Data (AssignRoleToUsersDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }
        }


       
    }
}
   

