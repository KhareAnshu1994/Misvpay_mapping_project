using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class MappingChangesAccessDetail
    {
        public int id { get; set; }
        public string reason_codes { get; set; }
        public string channel_code { get; set; }

        public string region { get; set; }
        public List<string> selected_ufc { get; set; }
        public List<string> selected_region { get; set; }
        public string ufc_name { get; set; }
        public string slcted_ufc { get; set; }

        [DataType(DataType.Date)]
        public DateTime? access_start_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? access_end_date { get; set; }


        [DataType(DataType.Date)]
        public DateTime? kra_valid_from { get; set; }

        [DataType(DataType.Date)]
        public DateTime? vymo_valid_from { get; set; }

        public string employee_code { get; set; }
        public string alternate_employee_code { get; set; }
        public string remark { get; set; }
        public string purpose { get; set; }
        public string created_by { get; set; }
        public string mapping_tables { get; set; }

        [DataType(DataType.Date)]
        public DateTime? effective_date { get; set; }

        public int total_transactions { get; set; }

        public int work_in_transactions { get; set; }

        public int ready_to_move_transactions { get; set; }
        public int moving_data_to_prod_transactions { get; set; }
        public int complete_transactions { get; set; }
        public int final_sub_transactions { get; set; }

        public int stage_id { get; set; }
    }

    public class MappingChangeAccessSearch
    {
        public DateTime? access_start_date { get; set; }
        public DateTime? access_end_date { get; set; }
        public DateTime? kra_valid_from { get; set; }
        public DateTime? vymo_valid_from { get; set; }
        public int stages { get; set; }
    }


    public class Purpose
    {
        public int purpose_id { get; set; }
        public string purpose { get; set; }
    }
    public class StageDetails
    {
        public int stage_id { get; set; }
        public string stage_name { get; set; }
    }
    public class MappingCriteria
    {
        public string table_name { get; set; }
        public string page_name { get; set; }
    }



    public class ActivityCompleteDetails
    {
        public int stage_id { get; set; }
        public int mapping_trans_id { get; set; }
        public int mapping_id { get; set; }
        public string remark { get; set; }

    }

    public class FinalSubmissionDetails
    {
        public int mapping_access_id { get; set; }
        public string ufc_code { get; set; }
        public string region_code { get; set; }
    }


    public class SplitMappingData
    {
        public int id { get; set; }
        public string rm_code { get; set; }
        public string aaum_equity_perc_share { get; set; }
        public string saaum_hybrid_perc_share { get; set; }
        public string aaum_arbitrage_perc_share { get; set; }
        public string aaum_fixed_income_perc_share { get; set; }
        public string aaum_cash_perc_share { get; set; }
        public string map_table_name { get; set; }
        public string arn { get; set; }
    }
}