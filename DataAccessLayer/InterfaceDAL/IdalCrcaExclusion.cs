using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalCrcaExclusion
    {
        List<CrcaExclusionDetail> Get_CrcaExclusion_AllDetails(CrcaExclusionSearch e);

        List<CrcaExclusionDetail> GetAcno();
    }
}