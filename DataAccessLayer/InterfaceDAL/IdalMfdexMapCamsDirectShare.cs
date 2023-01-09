using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalMfdexMapCamsDirectShare
    {
        List<MfdexMapCamsDirectShareDetail> Get_MfdexMapCamsDirectShare_AllDetails(MapSearchActivites e);
        Response Update_DIRECT_SINGLE_CITY_TO_RM_MAPPING_RTL(List<MfdexMapCamsDirectShareDetail> objList);
        Response Bulk_Update_Direct_Single_City(MfdexMapCamsDirectShareDetail objModel);
    }
}