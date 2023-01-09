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
    public class DalAddRole : IdalAddRole
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public Response AddRole(AddRole emp)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("insert_addroles", con);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    con.Open();
                    cmd.Parameters.Add(new OracleParameter("r_code", emp.code));
                    cmd.Parameters.Add(new OracleParameter("r_name", emp.name));
                    cmd.Parameters.Add(new OracleParameter("r_is_active", emp.is_active));


                    var a = cmd.ExecuteNonQuery();

                    if (a < 0)
                    {
                        res.status = true;
                        res.message = "Data Inserted Successfully";
                    }
                    else
                    {
                        res.status = false;
                        res.message = "Some error occured in inserting";

                    }

                }

                catch (Exception ex)
                {
                    res.status = false;
                    res.message = "Error in Insert Data " + ex.Message;
                }

                finally
                {
                    cmd.Dispose();
                    con.Close();

                }

            }
            return res;

        }


        public Response Update_permission(AddRole emp)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("UPDATE_Permission_in_AssignMenutoRole", con);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    con.Open();
                    cmd.Parameters.Add(new OracleParameter("v_code", emp.role));
                    cmd.Parameters.Add(new OracleParameter("v_permission", emp.permission));


                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() < 0)
                    {
                        res.status = true;
                        res.message = "Permission Updated Successfully";
                    }
                    else
                    {
                        res.status = false;
                        res.message = "Some error occured in Updating";

                    }

                }

                catch (Exception ex)
                {
                    res.status = false;
                    res.message = "Error in Update" + ex.Message;
                }

                finally
                {
                    cmd.Dispose();
                    con.Close();

                }

            }
            return res;

        }



        public string get_permission(string role_id)
        {
            var permission_data = "";

            using (OracleConnection conn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GET_PERMISSION_IN_ASSIGNMENUTOROLE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("v_role_id", role_id));
                cmd.Parameters.Add("get_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {

                            permission_data = Convert.ToString(rd["permission"]);
                        }
                    }


                }
                catch (Exception ex)
                {
                    Helper.WriteLog("DalListOfRoles Data (ListOfRolesDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                conn.Close();
            }



            return permission_data;
        }
    }
}