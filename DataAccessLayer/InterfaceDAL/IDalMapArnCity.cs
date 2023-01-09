using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{

    public interface IDalMapArnCity
    {
        List<MapArnCityDetails> GetMapArnCity(MapSearchActivites e);
        Response UpdateMapArnCity(List<MapArnCityDetails> objModel);
        Response Bulk_Update_ARN_CITY_TO_RM_MAPPING_RTL(MapArnCityDetails objModel);
    }
}
