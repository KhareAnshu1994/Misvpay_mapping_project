using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalMapArnInstitution
    {
        List<MapArnInstitutionDetail> GetMapArnInstitution(MapSearchActivites e);
        Response UpdateMapArnInst(List<MapArnInstitutionDetail> objList);

        Response Bulk_Update_MapArn_Inst(MapArnInstitutionDetail objModel);
    }
}