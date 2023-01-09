using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Mapping_Solution.CustomHelper
{
    public class CustomHelper
    {
        static string strcon = ConfigurationManager.ConnectionStrings["Oracle"].ToString();
        static string strconTemp = ConfigurationManager.ConnectionStrings["OracleTEMP"].ToString();

        public static string getConnectionStringForMapping(string mapping_table, string ufc_code) 
        {
            try
            {
                var tableExixts = UserManager.User.mapping_details_edit.Where(x => x.mapping_table == mapping_table && (x.ufc_details!=null? x.ufc_details.Where(y=>y.ufc_code == ufc_code).FirstOrDefault()!=null : false)).FirstOrDefault();
                if (tableExixts == null)
                {
                    return strcon;

                }
                else
                {
                    return strconTemp;
                }
            }
            catch(Exception ex)
            {
                return strcon;
            }

        }

        public static string getConnectionStringForMappingInst(string mapping_table, string region_code)
        {
            try
            {
                var tableExixts = UserManager.User.mapping_details_edit.Where(x => x.mapping_table == mapping_table && (x.region_details != null ? x.region_details.Where(y => y.region == region_code).FirstOrDefault() != null : false)).FirstOrDefault();
                if (tableExixts == null)
                {
                    return strcon;

                }
                else
                {
                    return strconTemp;
                }
            }
            catch (Exception ex)
            {
                return strcon;
            }

        }
    }
}