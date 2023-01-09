using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalMapRiaCode
    {
        List<MapRiaCodeDetails> GetMapRiaCode(MapSearchActivites e);

        Response Update_RIA_TO_RM_MAPPING_RTL(List<MapRiaCodeDetails> objList);
        Response Bulk_Update_RIA_TO_RM_MAPPING(MapRiaCodeDetails objModel);

    }
}