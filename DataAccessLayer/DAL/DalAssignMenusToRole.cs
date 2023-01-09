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
    public class DalAssignMenusToRole : IdalAssignMenusToRole
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();


        public List<AssignMenusToRole> Get_AssignMenusToRole_AllDetails()
        {
            List<AssignMenusToRoleDetail> assignList
                
                = new List<AssignMenusToRoleDetail>();
            List<AssignMenusToRole> moduleList = new List<AssignMenusToRole>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                try
                {
                    cmd.Connection = objConn;
                    cmd.CommandText = "MISVPAY_AssignMenusToRole_GETALL";
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("(MenusToRole ", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AssignMenusToRoleDetail dt = new AssignMenusToRoleDetail();

                            dt.module_name = reader["module_name"] != DBNull.Value ? reader["module_name"].ToString() : "";
                            dt.page_name = reader["page_name"] != DBNull.Value ? reader["page_name"].ToString() : "";
                            dt.table_name = reader["table_name"] != DBNull.Value ? reader["table_name"].ToString() : "";

                            assignList

                                .Add(dt);
                        }
                    }




                    var uniqueModules = assignList
                        
                        .Select(x => x.module_name).Distinct().ToList();


                    foreach (var item in uniqueModules)
                    {
                        AssignMenusToRole newItem = new AssignMenusToRole();
                        newItem.module_name = item;
                        newItem.page_list = assignList
                            
                            .Where(x => x.module_name == item).Select(x => new AssignMenusToRoleDetail() { 
                            
                            module_name = x.module_name,
                            page_name = x.page_name,
                            table_name = x.table_name
                            }).ToList();
                        moduleList.Add(newItem);
                    }




                }

                catch (Exception ex)
                {
                    Helper.WriteLog("Dal AssignMenusToRole Data (AssignMenusToRoleDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    objConn.Close();
                }
            }
            return moduleList;

        }
    }
}