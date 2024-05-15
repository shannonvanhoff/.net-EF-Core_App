using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Services.Models;

namespace Webapi.Services.Services.Helperservice
{
    public interface IHelperService
    {
        List<HelperDto> GetAllHelpers(bool? IsActive);
        HelperDto GetHelperById(int id);
        HelperDto AddHelper(HelperDto HelperDto);
        HelperDto UpdateHelper(int id, HelperDto HelperDto);
        bool DeleteHelperById(int id);
    }
}
