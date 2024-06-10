using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Data.Entities;
using Webapi.Services.Models;

namespace Webapi.Services.Services.AdminService
{
    public class IAdminService
    {
        AdminDto Register(Admin admin);

        Admin GetUserByUserNameAsync(string userName);

    }
}
