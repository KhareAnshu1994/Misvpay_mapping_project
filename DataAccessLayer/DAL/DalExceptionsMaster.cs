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
    public class DalExceptionsMaster : IdalExceptionsMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<ExceptionsMasterDetails> GetExceptionsMaster(ExceptionsMasterSearch e)
        {
            List<ExceptionsMasterDetails> EXCEPTIONS = new List<ExceptionsMasterDetails>();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("get_all_tbl_exception_master", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));
                cmd.Parameters.Add(new OracleParameter("caseid", e.case_id));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ExceptionsMasterDetails exc = new ExceptionsMasterDetails();
                            exc.remarks = Convert.ToString(dr["remarks"]);
                            exc.case_id = Convert.ToString(dr["case_id"]);
                            exc.case_name = Convert.ToString(dr["case_name"]);
                            exc.attribute = Convert.ToString(dr["attribute"]);
                            exc.p_seq = dr["p_seq"] != DBNull.Value ? dr["p_seq"].ToString() : "";
                            exc.exception_attribute = Convert.ToString(dr["exception_attribute"]);
                            exc.srno = Convert.ToInt32(dr["srno"]);
                            exc.valid_from = dr["valid_from"] == DBNull.Value ? null : (DateTime?)dr["valid_from"];
                            exc.valid_upto = dr["valid_upto"] == DBNull.Value ? null : (DateTime?)dr["valid_upto"];

                            //exc.case_no = Convert.ToString(dr["case_no"]);
                            exc.case_type = dr["case_type"] != DBNull.Value ? dr["case_type"].ToString() : "";
                            exc.applicability = Convert.ToString(dr["applicability"]);
                            //exc.flag_retrospective = dr["flag_retrospective"] != DBNull.Value ? dr["flag_retrospective"].ToString() : "";
                            //exc.lstupdt = dr["lstupdt"] == DBNull.Value ? null : (DateTime?)dr["lstupdt"];

                            EXCEPTIONS.Add(exc);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Exception Data (ExceptionsDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                con.Close();
            }
            return EXCEPTIONS;
        }

        public List<ExceptionsMasterDetails> GetCaseId()
        {
            List<ExceptionsMasterDetails> EXCEPTIONS = new List<ExceptionsMasterDetails>();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("Get_distinct_caseid", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    OracleDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ExceptionsMasterDetails e = new ExceptionsMasterDetails();
                            e.case_id = Convert.ToString(dr["case_id"]);


                            EXCEPTIONS.Add(e);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Exception Data (ExceptionsDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                con.Close();
            }
            return EXCEPTIONS;
        }

    }
}