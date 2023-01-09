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

    public class DalKraMaster : IDalKraMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        #region GetKraMaster or KraMasterSearching

        public List<KraMasterDetails> GetKraMaster(KraMasterSearch e)
        {
            List<KraMasterDetails> lst = new List<KraMasterDetails>();

            using (OracleConnection conn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "get_kra_master";  //get_kra_mast
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("kracode", e.kra_code));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("get", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    conn.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            KraMasterDetails r = new KraMasterDetails();


                            r.bscyear = Convert.ToInt32(rd["bscyear"]);
                            r.channel = Convert.ToString(rd["channel"]);
                            r.emp_role = Convert.ToString(rd["emp_role"]);
                            r.kra_code = Convert.ToInt32(rd["kra_code"]);
                            r.kra_description = Convert.ToString(rd["kra_description"]);
                            r.kra_type = Convert.ToString(rd["kra_type"]);
                            r.wtgs = Convert.ToInt32(rd["wtgs"]);
                            r.kra_freq = Convert.ToChar(rd["kra_freq"]);
                            lst.Add(r);
                        }
                    }


                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Kra Master Data (KraMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                conn.Close();
            }



            return lst;
        }

        #endregion


        #region GetKraCode In Dropdown
        public List<KraMasterDetails> GetKraCode()
        {
            List<KraMasterDetails> lst = new List<KraMasterDetails>();

            using (OracleConnection conn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "get_distinct_kracode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("get_kra", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            KraMasterDetails r = new KraMasterDetails();



                            r.kra_code = Convert.ToInt32(rd["kra_code"]);

                            lst.Add(r);
                        }
                    }


                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Kra Master Data (KraMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                conn.Close();
            }



            return lst;
        }

        #endregion

    }
}
