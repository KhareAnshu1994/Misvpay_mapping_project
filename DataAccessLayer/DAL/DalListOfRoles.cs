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
    public class DalListOfRoles : IdalListOfRoles
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();


        public List<ListOfRolesDetail> GetListOfRoles()
        {
            List<ListOfRolesDetail> lst = new List<ListOfRolesDetail>();

            using (OracleConnection conn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "MISVPAY_listofrole_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("(list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            ListOfRolesDetail r = new ListOfRolesDetail();


                            r.srno = Convert.ToInt32(rd["srno"]);
                            r.code = rd["code"] != DBNull.Value ? rd["code"].ToString() : "";
                            r.name = rd["name"] != DBNull.Value ? rd["name"].ToString() : "";
                            r.is_active = rd["is_active"] != DBNull.Value ? rd["is_active"].ToString() : "";


                            lst.Add(r);
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



            return lst;
        }

        public List<ListOfRolesDetail> Get_Name()
        {
            List<ListOfRolesDetail> lst = new List<ListOfRolesDetail>();

            using (OracleConnection conn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "MISVPAY_listofrole_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("(list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            ListOfRolesDetail r = new ListOfRolesDetail();



                            r.code = rd["code"] != DBNull.Value ? rd["code"].ToString() : "";
                            r.name = rd["name"] != DBNull.Value ? rd["name"].ToString() : "";


                            lst.Add(r);
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



            return lst;
        }
    }
}