using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalBnndMapPincodeArn
    {
        List<BnndMapPincodeArnDetails> GetBnndMapPincodeArn(MapSearchActivites e);
        Response Update_ARN_PINCODE_TO_RM_MAPPING_RTL(List<BnndMapPincodeArnDetails> objList);
        Response Bulk_Update_ARN_Pincode(BnndMapPincodeArnDetails objModel);

    }
}