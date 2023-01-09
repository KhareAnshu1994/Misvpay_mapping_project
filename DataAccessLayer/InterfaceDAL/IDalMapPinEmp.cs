using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IDalMapPinEmp
    {
        List<MapPinEmpDetails> GetMapPinEmp(MapSearchActivites e);
        Response Update_PINCODE_TO_RM_MAPPING_RTL(List<MapPinEmpDetails> objList);
        Response Bulk_Update_Pincode_To_RM(MapPinEmpDetails objModel);
    }
}