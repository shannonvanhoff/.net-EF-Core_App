using AutoMapper;
using Webapi.Data.Entities;
using Webapi.Services.Models;
namespace Webapi.Profiles
{
    public class AdminLoginProfile : Profile
    {
        public AdminLoginProfile() {

            CreateMap<Admin, AdminLoginDto>();
            CreateMap<AdminLoginDto,Admin>();
        }
    }
}
