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
    public class DalAddReasonMaster : IdalAddReasonMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public Response AddReasonMaster(AddReasonMaster emp)
        {
            Response res = new Response();
            using (OracleConnection con = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand("insert_reasonmasters", con);
                //OracleCommand cmd = new OracleCommand("Insert into aaddemp_details values(@e_id,@E_Name,@Email,@Pass,@ch_code,@Emp_role)", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                try
                {
                    con.Open();
                    cmd.Parameters.Add(new OracleParameter("v_reason_codes", emp.reason_codes));
                    cmd.Parameters.Add(new OracleParameter("v_reason_code_description", emp.reason_code_description));
                 //   cmd.Parameters.Add(new OracleParameter("v_is_active", emp.is_active));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    res.status = true;
                    res.message = "Data Inserted Successfully";
                }
                catch (Exception ex)
                {
                    res.status = false;
                    res.message = "Error in Insert Data " + ex.Message;
                } 
            }
            return res;

        
        
        
        
        
        
        }
    }
}