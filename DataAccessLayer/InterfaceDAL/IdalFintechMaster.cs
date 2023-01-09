﻿using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalFintechMaster

    {
        List<FintechMasterDetails> GetFINTECHMaster(FintechMasterSearch e);

        List<FintechMasterDetails> GetArnRiaCode();
    }
}