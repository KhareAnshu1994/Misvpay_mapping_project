using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalExceptionMappingInstitution
    {
        List<ExceptionMappingInstitutionDetail> GetExceptionMappingInstitution(MapSearchActivites e);
        Response UpdateExceptionMapInst(List<ExceptionMappingInstitutionDetail> objList);
        Response Bulk_Update_ExceptionMappingInst(ExceptionMappingInstitutionDetail objModel);
    }
}