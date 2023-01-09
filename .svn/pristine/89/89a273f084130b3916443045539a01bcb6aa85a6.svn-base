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
    public class DalMappingChangesAccess : IdalMappingChangesAccess
    {

        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();
        public List<MappingChangesAccessDetail> GetMappingChangesAccess(MappingChangeAccessSearch objsearch)
        {
            List<MappingChangesAccessDetail> obj = new List<MappingChangesAccessDetail>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "MISVPAY_MAPPINGCHANGEACCESS_GETALL";

                cmd.Parameters.Add(new OracleParameter("v_reason_codes", objsearch.stages));
                cmd.Parameters.Add(new OracleParameter("v_reason_codes", objsearch.access_start_date));
                cmd.Parameters.Add(new OracleParameter("v_reason_codes", objsearch.access_end_date));
                cmd.Parameters.Add(new OracleParameter("v_reason_codes", objsearch.kra_valid_from));
                cmd.Parameters.Add(new OracleParameter("v_reason_codes", objsearch.vymo_valid_from));

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("mapchange", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                try
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MappingChangesAccessDetail dt = new MappingChangesAccessDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.reason_codes = reader["reason_codes"] != DBNull.Value ? reader["reason_codes"].ToString() : "";
                            dt.channel_code = reader["channel_code"] != DBNull.Value ? reader["channel_code"].ToString() : "";
                            dt.region = reader["region"] != DBNull.Value ? reader["region"].ToString() : "";
                            dt.slcted_ufc = reader["selected_ufc"] != DBNull.Value ? reader["selected_ufc"].ToString() : "";
                            dt.ufc_name = reader["ufc_name"] != DBNull.Value ? reader["ufc_name"].ToString() : "";

                            dt.access_start_date = reader["access_start_date"] == DBNull.Value ? null : (DateTime?)reader["access_start_date"];
                            dt.access_end_date = reader["access_end_date"] == DBNull.Value ? null : (DateTime?)reader["access_end_date"];
                            dt.kra_valid_from = reader["kra_valid_from"] == DBNull.Value ? null : (DateTime?)reader["kra_valid_from"];
                            dt.vymo_valid_from = reader["vymo_valid_from"] == DBNull.Value ? null : (DateTime?)reader["vymo_valid_from"];
                            dt.employee_code = reader["employee_code"] != DBNull.Value ? reader["employee_code"].ToString() : "";
                            dt.alternate_employee_code = reader["alternate_employee_code"] != DBNull.Value ? reader["alternate_employee_code"].ToString() : "";
                            dt.remark = reader["remark"] != DBNull.Value ? reader["remark"].ToString() : "";
                            dt.total_transactions = Convert.ToInt32(reader["total_transactions"]);
                            dt.work_in_transactions = Convert.ToInt32(reader["work_in_transactions"]);
                            dt.final_sub_transactions = Convert.ToInt32(reader["final_sub_transactions"]);
                            dt.ready_to_move_transactions = Convert.ToInt32(reader["ready_to_move_transactions"]);
                            dt.complete_transactions = Convert.ToInt32(reader["complete_transactions"]);
                            dt.moving_data_to_prod_transactions = Convert.ToInt32(reader["moving_data_to_prod_transactions"]);


                            obj.Add(dt);
                        }
                    }


                    foreach(var item in obj)
                    {

                        if(item.total_transactions == item.work_in_transactions)
                        {
                            item.stage_id = 2;
                        }
                        else if (item.total_transactions == item.ready_to_move_transactions)
                        {
                            item.stage_id = 4;
                        }
                        else if (item.total_transactions == item.complete_transactions)
                        {
                            item.stage_id = 6;
                        }
                        else if (item.total_transactions == item.moving_data_to_prod_transactions)
                        {
                            item.stage_id = 5;
                        }
                        else if (item.total_transactions == item.final_sub_transactions)
                        {
                            item.stage_id = 3;
                        }
                        else if (item.final_sub_transactions>0)
                        {
                            item.stage_id = 2;
                        }
                        else
                        {
                            item.stage_id = 1;

                        }

                    }

                    if (objsearch.stages > 0)
                    {
                        obj = obj.Where(x => x.stage_id == objsearch.stages).ToList();
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MappingChangesAccess Data (MappingChangesAccessDetail Model) ERROR :" + ex.Message);
                    throw;
                }

                cmd.Dispose();
                con.Close();

                return obj.OrderByDescending(x=>x.id).ToList();
            }

        }



        #region Inserting in Mapping Change Access RTL
        public Response InsertMappingChangeAccess(MappingChangesAccessDetail emp)
        {
            Response res = new Response();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                try
                {
                    con.Open();
                    for (int i = 0; i < emp.selected_ufc.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("insert_mappingchangeaccess_rtl", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        var slct_ufc = emp.selected_ufc[i].ToString().Split('|');

                        var spilitufc = slct_ufc.ToArray();

                        cmd.Parameters.Add(new OracleParameter("v_reason_codes", emp.reason_codes));
                        cmd.Parameters.Add(new OracleParameter("v_channel_code", emp.channel_code));
                        //cmd.Parameters.Add(new OracleParameter("v_region", emp.region));
                        cmd.Parameters.Add(new OracleParameter("v_selected_ufc", spilitufc[0])); // Selected Ufc
                        cmd.Parameters.Add(new OracleParameter("v_ufc_name", spilitufc[1]));
                        cmd.Parameters.Add(new OracleParameter("v_access_start_date", emp.access_start_date));
                        cmd.Parameters.Add(new OracleParameter("v_access_end_date", emp.access_end_date));
                        cmd.Parameters.Add(new OracleParameter("v_kra_valid_from", emp.kra_valid_from));
                        cmd.Parameters.Add(new OracleParameter("v_vymo_valid_from", emp.vymo_valid_from));
                        cmd.Parameters.Add(new OracleParameter("v_remark", emp.remark));
                        cmd.Parameters.Add(new OracleParameter("v_effective_date", emp.effective_date));
                        cmd.Parameters.Add(new OracleParameter("v_purpose", emp.purpose));
                        cmd.Parameters.Add(new OracleParameter("v_created_date", DateTime.Now));
                        cmd.Parameters.Add(new OracleParameter("v_created_by", emp.created_by));
                        cmd.Parameters.Add(new OracleParameter("v_complete_not_complete", null));
                        cmd.Parameters.Add(new OracleParameter("v_production_commidate", null));
                        cmd.Parameters.Add(new OracleParameter("v_mapping_tbl", emp.mapping_tables));



                        cmd.ExecuteNonQuery();

                    }



                    res.status = true;
                    res.message = "Data Inserted Successfully";
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.message = "Error in Insert Data " + ex.Message;
                }
                finally
                {

                    //cmd.Dispose();
                    con.Close();
                }

            }
            return res;

        }
        #endregion;

        #region Inserting in Mapping Change Access INST
        public Response InsertMappingChangeAccess_INST(MappingChangesAccessDetail emp)
        {
            Response res = new Response();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                try
                {
                    con.Open();
                    for (int i = 0; i < emp.selected_region.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("insert_mappingchangeaccess_inst", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        var slct_region = emp.selected_region[i];



                        cmd.Parameters.Add(new OracleParameter("v_reason_codes", emp.reason_codes));
                        cmd.Parameters.Add(new OracleParameter("v_channel_code", emp.channel_code));
                        //cmd.Parameters.Add(new OracleParameter("v_selected_region", spilitregion[0])); // Selected Ufc
                        //cmd.Parameters.Add(new OracleParameter("v_ufc_name", spilitregion[1]));
                        cmd.Parameters.Add(new OracleParameter("v_access_start_date", emp.access_start_date));
                        cmd.Parameters.Add(new OracleParameter("v_access_end_date", emp.access_end_date));
                        cmd.Parameters.Add(new OracleParameter("v_kra_valid_from", emp.kra_valid_from));
                        cmd.Parameters.Add(new OracleParameter("v_vymo_valid_from", emp.vymo_valid_from));
                        cmd.Parameters.Add(new OracleParameter("v_remark", emp.remark));
                        cmd.Parameters.Add(new OracleParameter("v_effective_date", emp.effective_date));
                        cmd.Parameters.Add(new OracleParameter("v_purpose", emp.purpose));
                        cmd.Parameters.Add(new OracleParameter("v_created_date", DateTime.Now));
                        cmd.Parameters.Add(new OracleParameter("v_created_by", emp.created_by));
                        cmd.Parameters.Add(new OracleParameter("v_complete_not_complete", null));
                        cmd.Parameters.Add(new OracleParameter("v_production_commidate", null));
                        cmd.Parameters.Add(new OracleParameter("v_mapping_tbl", emp.mapping_tables));
                        cmd.Parameters.Add(new OracleParameter("v_region", slct_region));



                        cmd.ExecuteNonQuery();

                    }



                    res.status = true;
                    res.message = "Data Inserted Successfully";
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.message = "Error in Insert Data " + ex.Message;
                }
                finally
                {

                    //cmd.Dispose();
                    con.Close();
                }

            }
            return res;

        }
        #endregion;



        public List<Purpose> GetPurpose()
        {
            List<Purpose> obj = new List<Purpose>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "get_purpose";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("get", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                try
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Purpose dt = new Purpose();
                            dt.purpose_id = Convert.ToInt32(reader["Id"]);
                            dt.purpose = Convert.ToString(reader["purpose"]);


                            obj.Add(dt);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MappingChangesAccess Data (MappingChangesAccessDetail Model) ERROR :" + ex.Message);
                    throw;
                }

                cmd.Dispose();
                con.Close();

                return obj;
            }

        }


        public List<MappingCriteria> GetMappingCriteria()
        {
            List<MappingCriteria> objMappingCr = new List<MappingCriteria>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "GET_MAPPING_TABLE_NAME";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("get", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                try
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MappingCriteria dt = new MappingCriteria();
                            dt.page_name = Convert.ToString(reader["page_name"]);
                            dt.table_name = Convert.ToString(reader["table_name"]);


                            objMappingCr.Add(dt);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MappingChangesAccess Data (MappingChangesAccessDetail Model) ERROR :" + ex.Message);
                    throw;
                }

                cmd.Dispose();
                con.Close();

                return objMappingCr;
            }

        }



        public List<StageDetails> GetStage()
        {
            List<StageDetails> objStage = new List<StageDetails>();

            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "GET_ALL_STAGE_MASTER";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("get", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                try
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            StageDetails dt = new StageDetails();
                            dt.stage_id = Convert.ToInt32(reader["stage_id"]);
                            dt.stage_name = Convert.ToString(reader["stage_name"]);


                            objStage.Add(dt);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MappingChangesAccess Data (MappingChangesAccessDetail Model) ERROR :" + ex.Message);
                    throw;
                }

                cmd.Dispose();
                con.Close();

                return objStage;
            }

        }

        #region Update Remark In Mapping Change Access Transaction

        public Response CompleteTransactionActivity(ActivityCompleteDetails objAct)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {

                try
                {
                    con.Open();


                    OracleCommand cmd = new OracleCommand("UPDATE_REMARK_ACTIVITY_COMPLETE_IN_MAP_TRANS", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new OracleParameter("mapping_trans_id", objAct.mapping_trans_id));
                    cmd.Parameters.Add(new OracleParameter("V_MAPPING_ID", objAct.mapping_id));
                    cmd.Parameters.Add(new OracleParameter("V_Remark", objAct.remark));


                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() < 0)
                    {
                        res.status = true;
                        res.message = "Remark Activity Completed Successfully";
                    }
                    else
                    {
                        res.status = false;
                        res.message = "Remark Activity Not Completed Successfully";
                    }

                }

                catch (Exception ex)
                {
                    res.message = "Error in Update Data " + ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
            return res;

        }

        #endregion;



        #region Update Stage Id for Final Submission

        public Response FinalSubmission(List<FinalSubmissionDetails> obj)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < obj.Count; i++)
                    {

                        OracleCommand cmd = new OracleCommand("UPDATE_STAGE_ID_FOR_FINAL_SUBMISSION", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new OracleParameter("v_mapping_access_id", obj[i].mapping_access_id));
                        cmd.Parameters.Add(new OracleParameter("v_ufc_code", obj[i].ufc_code));


                        cmd.ExecuteNonQuery();
                    }


                }

                catch (Exception ex)
                {
                    res.message = "Error in Update Data " + ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
            return res;

        }



        public Response FinalSubmissionINST(List<FinalSubmissionDetails> obj)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < obj.Count; i++)
                    {

                        OracleCommand cmd = new OracleCommand("UPDATE_STAGE_ID_FOR_FINAL_SUBMISSION_INST", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new OracleParameter("v_mapping_access_id", obj[i].mapping_access_id));
                        cmd.Parameters.Add(new OracleParameter("v_region_code", obj[i].region_code));


                        cmd.ExecuteNonQuery();
                    }


                }

                catch (Exception ex)
                {
                    res.message = "Error in Update Data " + ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
            return res;

        }

        #endregion;


        #region Update Stage Id Move Data to Production

        public Response MoveDatatoProduction(List<FinalSubmissionDetails> obj)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < obj.Count; i++)
                    {

                        OracleCommand cmd = new OracleCommand("UPDATE_STAGE_ID_FOR_MOVE_TO_PRODUCTION", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new OracleParameter("v_mapping_access_id", obj[i].mapping_access_id));

                        cmd.ExecuteNonQuery();
                    }


                }

                catch (Exception ex)
                {
                    res.message = "Error in Update Data " + ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
            return res;

        }

        #endregion;

        #region Update split data

        public Response UpdateSplitData(List<SplitMappingData> obj)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < obj.Count; i++)
                    {
                        var split_rm_code = obj[i].rm_code.Split('|');

                        var arr_rm_code = split_rm_code.ToArray();


                        OracleCommand cmd = new OracleCommand("UPDATE_SPLIT_DATA_FOR_MAPPING", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new OracleParameter("v_map_table_name", obj[i].map_table_name));
                        cmd.Parameters.Add(new OracleParameter("v_id", obj[i].id));
                        cmd.Parameters.Add(new OracleParameter("v_rm_code", arr_rm_code[0]));
                        cmd.Parameters.Add(new OracleParameter("v_rm_name", arr_rm_code[1]));
                        cmd.Parameters.Add(new OracleParameter("v_aaum_arbitrage_perc_share", obj[i].aaum_arbitrage_perc_share));
                        cmd.Parameters.Add(new OracleParameter("v_aaum_cash_perc_share", obj[i].aaum_cash_perc_share));
                        cmd.Parameters.Add(new OracleParameter("v_aaum_equity_perc_share", obj[i].aaum_equity_perc_share));
                        cmd.Parameters.Add(new OracleParameter("v_aaum_fixed_income_perc_share", obj[i].aaum_fixed_income_perc_share));
                        cmd.Parameters.Add(new OracleParameter("v_saaum_hybrid_perc_share", obj[i].saaum_hybrid_perc_share));
                        cmd.Parameters.Add(new OracleParameter("v_arn", obj[i].arn));
                        cmd.ExecuteNonQuery();
                    }


                }

                catch (Exception ex)
                {
                    res.message = "Error in Update Data " + ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
            return res;

        }

        #endregion;


        #region Update Access Start Date, End Date, Alternate Emp Code
        public Response Save_action(MappingChangesAccessDetail objModel)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {

                try
                {
                    con.Open();

                    //for (int i = 0; i < objList.Count; i++)
                    //{
                    OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_MAPPINGCHANGEACCESS", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new OracleParameter("v_id", objModel.id));
                    cmd.Parameters.Add(new OracleParameter("v_access_start_date", objModel.access_start_date));
                    cmd.Parameters.Add(new OracleParameter("v_access_end_date", objModel.access_end_date));
                    cmd.Parameters.Add(new OracleParameter("v_alternate_emp_code", objModel.alternate_employee_code));



                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() < 0)
                    {
                        res.status = true;
                        res.message = "Data Saved Successfully";
                    }
                    else
                    {
                        res.status = false;
                        res.message = "Data not Saved";
                    }


                }
                catch (Exception ex)
                {
                    res.message = "Error in Saving Data " + ex.Message;
                }
                finally
                {
                    con.Close();

                }
            }
            return res;

        }

        #endregion;
    }
}