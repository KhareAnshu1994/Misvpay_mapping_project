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
    public class DalMappingChangeAccess : IdalMappingChangeAccess
    {
       
            static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();


            public List<MappingChangeAccessDetail> GetMappingChangeAccess()
            {
                List<MappingChangeAccessDetail> lst = new List<MappingChangeAccessDetail>();

                using (OracleConnection conn = new OracleConnection(strcon))
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "MISVPAY_mappingchangeaccess_GETALL";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("mapchange", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    try
                    {
                        conn.Open();
                        OracleDataReader rd = cmd.ExecuteReader();

                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                            MappingChangeAccessDetail r = new MappingChangeAccessDetail();


                                r.reason_codes = rd["reason_codes"] != DBNull.Value ? rd["reason_codes"].ToString() : "";
                                r.channel_code = rd["channel_code"] != DBNull.Value ? rd["channel_code"].ToString() : "";
                                r.region = rd["region"] != DBNull.Value ? rd["region"].ToString() : "";
                                r.selected_ufc = rd["selected_ufc"] != DBNull.Value ? rd["selected_ufc"].ToString() : "";
                                r.ufc_name = rd["ufc_name"] != DBNull.Value ? rd["ufc_name"].ToString() : "";
                                r.access_start_date = rd["access_start_date"] == DBNull.Value ? null : (DateTime?)rd["access_start_date"];
                                r.access_end_date = rd["access_end_date"] == DBNull.Value ? null : (DateTime?)rd["access_end_date"];
                                r.kra_valid_from = rd["kra_valid_from"] == DBNull.Value ? null : (DateTime?)rd["kra_valid_from"];
                                r.vymo_valid_from = rd["vymo_valid_from"] == DBNull.Value ? null : (DateTime?)rd["vymo_valid_from"];

                                r.employee_code = rd["employee_code"] != DBNull.Value ? rd["employee_code"].ToString() : "";
                                r.alternate_employee_code = rd["alternate_employee_code"] != DBNull.Value ? rd["alternate_employee_code"].ToString() : "";
                                r.remark = rd["remark"] != DBNull.Value ? rd["remark"].ToString() : "";

                            lst.Add(r);
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        Helper.WriteLog("DalMappingChangeAccess Data (MappingChangeAccessDetail Model) ERROR :" + ex.Message);
                        throw;
                    }
                    conn.Close();
                }



                return lst;
            }
        }
}