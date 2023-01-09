﻿using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalMapPanMapping
    {
        List<MapPanMappingDetail> GetMapPanMapping(MapSearchActivites e);
        Response UpdateMapPanMappingInst(List<MapPanMappingDetail> objList);

        Response Bulk_Update_Map_pan_mapping_inst(MapPanMappingDetail objModel);

    }
}