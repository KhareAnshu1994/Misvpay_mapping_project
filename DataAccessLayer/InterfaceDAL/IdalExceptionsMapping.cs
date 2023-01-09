using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalExceptionsMapping
    {
        List<ExceptionsMappingDetails> GetExceptionsMapping(MapSearchActivites e);
        Response Update_EXCEPTIONS_MAPPING_RTL(List<ExceptionsMappingDetails> objList);
        Response Bulk_Update_EXCEPTIONS_MAPPING_RTL(ExceptionsMappingDetails objModel);
    }
}