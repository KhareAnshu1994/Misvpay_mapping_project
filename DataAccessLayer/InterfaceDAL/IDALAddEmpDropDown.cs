using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IDALAddEmpDropDown
    {
        List<AddEmployeeDetails> GetEMPRole();
        List<AddEmployeeDetails> GetRegion();
        //List<AddEmployeeDetails> GetZone();
        //List<AddEmployeeDetails> GetLocation();
        //List<AddEmployeeDetails> GetFunctionalRole();
        //List<AddEmployeeDetails> GetCity();
        List<AddEmployeeDetails> GetStatus();
        List<AddEmployeeDetails> GetMovement();
        List<AddEmployeeDetails> GetQuarter();
    }
}