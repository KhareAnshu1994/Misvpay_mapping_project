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
    public class DalLogin : IdalLogin
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public object MappingAceesTableDetails { get; private set; }

        public List<LoginDetails> GetEmpLogin(LoginDetails e)
        {

            List<LoginDetails> res = new List<LoginDetails>();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();

                try
                {
                    cmd.Connection = con;
                    cmd.CommandText = "MISVPAY_Login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("emp_id", e.EmpID));
                    cmd.Parameters.Add(new OracleParameter("password", e.Password));
                    cmd.Parameters.Add("chan", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    con.Open();
                    OracleDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        LoginDetails r = new LoginDetails();
                        while (rd.Read())
                        {
                            r.EmpID = Convert.ToString(rd["emp_id"]);
                            // r.Password = Convert.ToString(rd["password"]);
                            r.UserName = Convert.ToString(rd["empname"]);
                            r.Role = Convert.ToString(rd["Emp_role"]);
                            r.Employee_id = Convert.ToString(rd["Emp_id"]);
                            r.Location = Convert.ToString(rd["UFC_CODE"]);
                            r.Region = Convert.ToString(rd["REGION_CODE"]);
                            res.Add(r);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Login Data (LoginDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }

            }

            return res;
        }

        public List<MappingAceesTableDetails> GetMappingAceessEditDetails(MappingAceesEditDetails e)
        {

            List<MappingAceesTableDetails> res = new List<MappingAceesTableDetails>();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();

                try
                {
                    cmd.Connection = con;
                    cmd.CommandText = "GetEditAccessFrom_MappingAccessFor_User";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("v_employee_code", e.employee_code));
                    cmd.Parameters.Add("chan", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    con.Open();
                    OracleDataReader rd = cmd.ExecuteReader();
                    var current_date = System.DateTime.Now;
                    if (rd.HasRows)
                    {
                        List<MappingAceesEditDetails> result = new List<MappingAceesEditDetails>();

                        while (rd.Read())
                        {
                            MappingAceesEditDetails r = new MappingAceesEditDetails();

                            r.ufc_code = Convert.ToString(rd["selected_ufc"]);
                            r.region = Convert.ToString(rd["region"]);
                            r.channel_code = Convert.ToString(rd["channel_code"]);
                            r.employee_code = Convert.ToString(rd["working_emp_code"]);
                            r.alternate_employee_code = Convert.ToString(rd["alternate_emp_code"]);
                            r.mapping_trans_id = Convert.ToInt32(rd["mapping_trans_id"]);
                            r.mapping_access_id = Convert.ToInt32(rd["mapping_id"]);
                            r.mapping_table = Convert.ToString(rd["mapping_tables"]);
                            r.access_start_date = (DateTime?)rd["access_start_date"];
                            r.access_end_date = (DateTime?)rd["access_end_date"];
                            r.complete_status = Convert.ToInt32(rd["stage_id"]) == 2 ? false : true;
                            r.edit_window = (current_date >= r.access_start_date && current_date <= r.access_end_date) ? true : false;
                            result.Add(r);
                        }

                        foreach (var item in result)
                        {
                            var rsExists = res.Where(x => x.mapping_table == item.mapping_table).FirstOrDefault();
                            if (rsExists == null)
                            {
                                MappingAceesTableDetails newObj = new MappingAceesTableDetails();
                                newObj.mapping_table = item.mapping_table;
                                newObj.ufc_details = new List<MappingAceesUFCDetails>();
                                newObj.region_details = new List<MappingAceesRegionDetails>();
                                if (item.channel_code == "INST")
                                {
                                    MappingAceesRegionDetails rgobj = new MappingAceesRegionDetails();
                                    rgobj.region = item.region;
                                    rgobj.alternate_employee_code = item.alternate_employee_code;
                                    rgobj.employee_code = item.employee_code;
                                    rgobj.complete_status = item.complete_status;
                                    rgobj.mapping_access_id = item.mapping_access_id;
                                    rgobj.mapping_trans_id = item.mapping_trans_id;
                                    rgobj.edit_window = item.edit_window;
                                    rgobj.access_start_date = item.access_start_date;
                                    rgobj.access_end_date = item.access_end_date;
                                    newObj.region_details.Add(rgobj);
                                }
                                else
                                {
                                    MappingAceesUFCDetails ufcobj = new MappingAceesUFCDetails();
                                    ufcobj.ufc_code = item.ufc_code;
                                    ufcobj.alternate_employee_code = item.alternate_employee_code;
                                    ufcobj.employee_code = item.employee_code;
                                    ufcobj.complete_status = item.complete_status;
                                    ufcobj.mapping_access_id = item.mapping_access_id;
                                    ufcobj.mapping_trans_id = item.mapping_trans_id;
                                    ufcobj.edit_window = item.edit_window;
                                    ufcobj.access_start_date = item.access_start_date;
                                    ufcobj.access_end_date = item.access_end_date;
                                    newObj.ufc_details.Add(ufcobj);
                                }
                                res.Add(newObj);
                            }
                            else
                            {
                                if (item.channel_code == "INST")
                                {
                                    MappingAceesRegionDetails rgobj = new MappingAceesRegionDetails();
                                    rgobj.region = item.region;
                                    rgobj.alternate_employee_code = item.alternate_employee_code;
                                    rgobj.employee_code = item.employee_code;
                                    rgobj.complete_status = item.complete_status;
                                    rgobj.mapping_access_id = item.mapping_access_id;
                                    rgobj.mapping_trans_id = item.mapping_trans_id;
                                    rgobj.edit_window = item.edit_window; 
                                    rgobj.access_start_date = item.access_start_date;
                                    rgobj.access_end_date = item.access_end_date;
                                    rsExists.region_details.Add(rgobj);
                                }
                                else
                                {
                                    MappingAceesUFCDetails ufcobj = new MappingAceesUFCDetails();
                                    ufcobj.ufc_code = item.ufc_code;
                                    ufcobj.alternate_employee_code = item.alternate_employee_code;
                                    ufcobj.employee_code = item.employee_code;
                                    ufcobj.complete_status = item.complete_status;
                                    ufcobj.mapping_access_id = item.mapping_access_id;
                                    ufcobj.mapping_trans_id = item.mapping_trans_id;
                                    ufcobj.edit_window = item.edit_window;
                                    ufcobj.access_start_date = item.access_start_date;
                                    ufcobj.access_end_date = item.access_end_date;
                                    rsExists.ufc_details.Add(ufcobj);
                                }
                            }
                        }

                        foreach (var item in res)
                        {
                            if (item.ufc_details.Count > 0)
                            {
                                if (item.ufc_details.Where(x => x.complete_status == false).FirstOrDefault() == null)
                                {
                                    item.complete_status = true;
                                }
                            }


                            if (item.region_details.Count > 0)
                            {

                                if (item.region_details.Where(x => x.complete_status == false).FirstOrDefault() == null)
                                {
                                    item.complete_status = true;
                                }
                                else
                                {
                                    item.complete_status = false;
                                }
                            }
                        }

                    }




                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal Master Data (RegionMasterDetails Model) ERROR :" + ex.Message);
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }

            }

            return res;
        }

    }
}