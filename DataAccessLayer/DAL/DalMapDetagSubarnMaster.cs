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
    public class DalMapDetagSubarnMaster : IdalMapDetagSubarnMaster
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();

        public List<MapDetagSubarnMasterDetail> Get_MapDetagSubarnMaster_AllDetails(MapDetagSubarnMasterSearch e)
        {
            //ResponseData<T> ObjRes = new ResponseData<T>();
            List<MapDetagSubarnMasterDetail> list_data = new List<MapDetagSubarnMasterDetail>();

            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_mapdetagsubartnmast_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", String.IsNullOrEmpty(e.search_text) ? null : e.search_text));
                cmd.Parameters.Add(new OracleParameter("arnno", e.arn_no));
                //cmd.Parameters.Add(new OracleParameter("quarter", e.quarter));


                cmd.Parameters.Add("detag", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            MapDetagSubarnMasterDetail dt = new MapDetagSubarnMasterDetail();

                            dt.arn_no = reader["arn_no"] != DBNull.Value ? reader["arn_no"].ToString() : "";
                            dt.branch_code = reader["branch_code"] != DBNull.Value ? reader["branch_code"].ToString() : "";
                            dt.arn_name = reader["arn_name"] != DBNull.Value ? reader["arn_name"].ToString() : "";
                            dt.valid_from = reader["valid_from"] == DBNull.Value ? null : (DateTime?)reader["valid_from"];
                            dt.valid_upto = reader["valid_upto"] == DBNull.Value ? null : (DateTime?)reader["valid_upto"];

                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MapDetagSubarnMaster Data (MapDetagSubarnMasterDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();
            }



            return list_data;
        }

        public List<MapDetagSubarnMasterDetail> GetArnNumber()
        {
            //ResponseData<T> ObjRes = new ResponseData<T>();
            List<MapDetagSubarnMasterDetail> list_data = new List<MapDetagSubarnMasterDetail>();

            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_mapdetagsubartnmast_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("kracode", null));


                cmd.Parameters.Add("detag", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            MapDetagSubarnMasterDetail dt = new MapDetagSubarnMasterDetail();
                            dt.id = Convert.ToInt32(reader["id"]);

                            dt.arn_no = reader["arn_no"] != DBNull.Value ? reader["arn_no"].ToString() : "";


                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MapDetagSubarnMaster Data (MapDetagSubarnMasterDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();
            }



            return list_data;
        }


        public List<MapDetagSubarnMasterDetail> GetBranchCode()
        {
            List<MapDetagSubarnMasterDetail> list_data = new List<MapDetagSubarnMasterDetail>();

            using (OracleConnection objConn = new OracleConnection(strcon))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "MISVPAY_mapdetagsubartnmast_GETALL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("search_text", null));
                cmd.Parameters.Add(new OracleParameter("kracode", null));

                cmd.Parameters.Add("detag", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {


                        while (reader.Read())
                        {
                            MapDetagSubarnMasterDetail dt = new MapDetagSubarnMasterDetail();

                            dt.branch_code = reader["branch_code"] != DBNull.Value ? reader["branch_code"].ToString() : "";

                            list_data.Add(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.WriteLog("Dal MapDetagSubarnMaster Data (MapDetagSubarnMasterDetail Model) ERROR :" + ex.Message);
                    throw;

                }
                objConn.Close();
            }



            return list_data;
        }

    }
}