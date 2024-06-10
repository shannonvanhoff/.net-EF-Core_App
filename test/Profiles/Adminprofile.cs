using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Webapi.Data.Entities;
using Webapi.Services.Models;

namespace Webapi.Profiles
{
    public class Adminprofile: Profile
    {
        public Adminprofile() 
        {
            CreateMap<Admin, AdminDto>();
            CreateMap<AdminDto,Admin>();
        }
    }
}
