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
    public class DalVymoDistributorMapping : IdalVymoDistributorMapping
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();
        
        public List<VymoDistributorMappingDetail> Get_VymoDistributorMapping_AllDetails(VymoDistributorMappingSearch e)
        {
            List<VymoDistributorMappingDetail> obj = new List<VymoDistributorMappingDetail>();
            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GETALL_MISVPAY_VYMO_DISTRIBUTOR_MAPPING_RTL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", e.search_text));

                // cmd.Parameters.Add(new OracleParameter("channelccode", e.channel_code));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("get_all_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            VymoDistributorMappingDetail dt = new VymoDistributorMappingDetail();
                            dt.id = Convert.ToInt32(reader["id"]);
                            dt.lead_code = reader["lead_code"] != DBNull.Value ? reader["lead_code"].ToString() : "";
                            dt.assigned_to = reader["assigned_to"] != DBNull.Value ? reader["assigned_to"].ToString() : "";
                            dt.user_id = reader["user_id"] != DBNull.Value ? reader["user_id"].ToString() : "";
                            dt.creation_date = reader["creation_date"] == DBNull.Value ? null : (DateTime?)reader["creation_date"];
                            dt.last_updated_date = reader["last_updated_date"] == DBNull.Value ? null : (DateTime?)reader["last_updated_date"];
                            dt.distributor_name = reader["distributor_name"] != DBNull.Value ? reader["distributor_name"].ToString() : "";
                            dt.email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "";
                            dt.phone = reader["phone"] != DBNull.Value ? (int)Convert.ToInt64(reader["phone"]) : 0;
                            dt.primary_phone_number = reader["primary_phone_number"] != DBNull.Value ? (int)Convert.ToInt64(reader["primary_phone_number"]) : 0;
                            dt.status = reader["status"] == DBNull.Value ? '\0' : Convert.ToChar(reader["status"]);
                            dt.category = reader["category"] != DBNull.Value ? reader["category"].ToString() : "";
                            dt.partner_recruitment_date = reader["partner_recruitment_date"] == DBNull.Value ? null : (DateTime?)reader["partner_recruitment_date"];
                            dt.engagement_frequency = reader["engagement_frequency"] != DBNull.Value ? (int)Convert.ToInt64(reader["engagement_frequency"]) : 0;
                            dt.phone = reader["phone"] != DBNull.Value ? (int)Convert.ToInt64(reader["phone"]) : 0;
                            dt.arn_number = reader["arn_number"] != DBNull.Value ? reader["arn_number"].ToString() : "";
                            dt.sub_arn = reader["sub_arn"] != DBNull.Value ? (int)Convert.ToInt64(reader["sub_arn"]) : 0;
                            dt.sub_arn_name = reader["sub_arn_name"] != DBNull.Value ? reader["sub_arn_name"].ToString() : "";
                            dt.group_name = reader["group_name"] != DBNull.Value ? reader["group_name"].ToString() : "";
                            dt.group_arn = reader["group_arn"] != DBNull.Value ? reader["group_arn"].ToString() : "";
                            dt.commission_category = reader["commission_category"] != DBNull.Value ? reader["commission_category"].ToString() : "";
                            dt.tier = reader["tier"] != DBNull.Value ? reader["tier"].ToString() : "";
                            dt.state = reader["state"] != DBNull.Value ? reader["state"].ToString() : "";
                            dt.city = reader["city"] != DBNull.Value ? reader["city"].ToString() : "";
                            dt.home_location = reader["home_location"] != DBNull.Value ? reader["home_location"].ToString() : "";
                            dt.arn_validity = reader["arn_validity"] == DBNull.Value ? null : (DateTime?)reader["arn_validity"];
                            dt.channel = reader["channel"] != DBNull.Value ? reader["channel"].ToString() : "";
                            dt.distributor_pan = reader["distributor_pan"] != DBNull.Value ? reader["distributor_pan"].ToString() : "";
                            dt.distributor_type = reader["distributor_type"] != DBNull.Value ? reader["distributor_type"].ToString() : "";
                            dt.effective_date = reader["effective_date"] == DBNull.Value ? null : (DateTime?)reader["effective_date"];
                            dt.secondary_contact_number = reader["secondary_contact_number"] != DBNull.Value ? (int)Convert.ToInt64(reader["secondary_contact_number"]) : 0;
                            dt.residential_contact_number = reader["residential_contact_number"] != DBNull.Value ? (int)Convert.ToInt64(reader["residential_contact_number"]) : 0;
                            dt.pincode = reader["pincode"] != DBNull.Value ? (int)Convert.ToInt64(reader["pincode"]) : 0;
                            dt.birth_date = reader["birth_date"] == DBNull.Value ? null : (DateTime?)reader["birth_date"];
                            dt.dist_key = reader["dist_key"] != DBNull.Value ? reader["dist_key"].ToString() : "";
                            dt.mapping_city = reader["mapping_city"] != DBNull.Value ? reader["mapping_city"].ToString() : "";
                            dt.tagged_uti_branch = reader["tagged_uti_branch"] != DBNull.Value ? reader["tagged_uti_branch"].ToString() : "";
                            dt.tagged_uti_branch_code = reader["tagged_uti_branch_code"] != DBNull.Value ? (int)Convert.ToInt64(reader["tagged_uti_branch_code"]) : 0;
                            dt.tagged_misvpay_branch_code = reader["tagged_misvpay_branch_code"] != DBNull.Value ? (int)Convert.ToInt64(reader["tagged_misvpay_branch_code"]) : 0;
                            dt.alternate_address_line_1 = reader["alternate_address_line_1"] != DBNull.Value ? reader["alternate_address_line_1"].ToString() : "";
                            dt.alternate_address_line_2 = reader["alternate_address_line_2"] != DBNull.Value ? reader["alternate_address_line_2"].ToString() : "";
                            dt.alternate_city = reader["alternate_city"] != DBNull.Value ? reader["alternate_city"].ToString() : "";
                            dt.alternate_state = reader["alternate_state"] != DBNull.Value ? reader["alternate_state"].ToString() : "";
                            dt.alternate_pincode = reader["alternate_pincode"] != DBNull.Value ? (int)Convert.ToInt64(reader["alternate_pincode"]) : 0;
                            dt.anniversary_date = reader["anniversary_date"] == DBNull.Value ? null : (DateTime?)reader["anniversary_date"];
                            dt.distributor_arn = reader["distributor_arn"] != DBNull.Value ? reader["distributor_arn"].ToString() : "";
                            dt.alternate_email = reader["alternate_email"] != DBNull.Value ? reader["alternate_email"].ToString() : "";
                            dt.distributor_segment = reader["distributor_segment"] == DBNull.Value ? '\0' : Convert.ToChar(reader["distributor_segment"]);
                            dt.alternate_contact_number = reader["alternate_contact_number"] != DBNull.Value ? (int)Convert.ToInt64(reader["alternate_contact_number"]) : 0;





                            obj.Add(dt);
                        }
                    }

                    cmd.Dispose();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal VymoDistributorMapping Data (VymoDistributorMappingDetail Model) ERROR :" + ex.Message);
                    throw;
                }
                return obj;
            }
        }


        #region Update VYMO DISTRIBUTOR MAPPING RTL
        public Response Update_VYMO_DISTRIBUTOR_MAPPING_RTL(List<VymoDistributorMappingDetail> objList)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    for (int i = 0; i < objList.Count; i++)
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE_MISVPAY_TBL_VYMO_DISTRIBUTOR_MAPPING_RTL", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new OracleParameter("v_id", objList[i].id));
                        cmd.Parameters.Add(new OracleParameter("v_rm_code", objList[i].user_id));


                        cmd.ExecuteNonQuery();

                        if (cmd.ExecuteNonQuery() < 0)


                        {
                            res.status = true;
                            res.message = "Data Updated Successfully";
                        }
                        else
                        {
                            res.status = false;
                            res.message = "Data not Updated";
                        }

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

       
        
        #region Bulk Update Rm Code vymno Distributor Mapping
        public Response Bulk_Update_Vymo_Distributor(VymoDistributorMappingDetail objModel)
        {

            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strconTemp))
            {

                try
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("UPDATE_BULK_RMCODE_MISVPAY_TBL_VYMO_DISTRIBUTOR_MAPPING_RTL", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new OracleParameter("S_rm_code", objModel.New_rmcode));
                    cmd.Parameters.Add(new OracleParameter("p_rm_code", objModel.Old_rmcode));


                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() < 0)
                    {
                        res.status = true;
                        res.message = "RM Code Replaced Successfully";
                    }
                    else
                    {
                        res.status = false;
                        res.message = "RM Code not Replaced Successfully";
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


    }
}