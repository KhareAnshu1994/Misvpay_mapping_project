using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalUfcMaster
    {
        List<UfcMasterDetails> GetUFCMaster(UfcMasterSearch e);

        List<UfcMasterDetails> GetSapUfcCode();
    }
}