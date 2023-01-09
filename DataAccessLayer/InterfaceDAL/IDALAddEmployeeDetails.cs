using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IDALAddEmployeeDetails
    {
        Response InsertEMP(AddEmployeeDetails emp);
        //object Resume(AddEmployeeDetails e);
        //object Resume();
    }
}
