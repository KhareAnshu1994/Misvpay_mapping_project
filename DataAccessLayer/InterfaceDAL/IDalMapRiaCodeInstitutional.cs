using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IDalMapRiaCodeInstitutional
    {
        List<MapRiaCodeInstitutionalDetails> GetMapRiaCodeInstitutional(MapSearchActivites e);
        Response UpdateMapRiaCodeInst(List<MapRiaCodeInstitutionalDetails> objList);
        Response Bulk_Update_Ria_Code_Mapping_Inst(MapRiaCodeInstitutionalDetails objModel);
    }
}