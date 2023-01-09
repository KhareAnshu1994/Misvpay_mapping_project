using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalAddRole
    {
        Response AddRole(AddRole emp);
        Response Update_permission(AddRole emp);
        string get_permission(string role_id);
    }
}