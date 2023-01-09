using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalBnndMapSubarnPin
    {
        List<BnndMapSubarnPinDetail> Get_BnndMapSubarnPin_AllDetails(MapSearchActivites e);
        Response Update_ARN_SUB_ARN_PIN_TO_RM_MAPPING_RTL(List<BnndMapSubarnPinDetail> objList);
        Response Bulk_Update_Arn_SubarnPin(BnndMapSubarnPinDetail objModel);
    }
}