using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Data.Migrations;
using Webapi.Services.Models;
using Webapi;
using AppContext = Webapi.Data.Migrations.AppContext;
using Webapi.Services.Helpers;
using AutoMapper;
using Webapi.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;


namespace Webapi.Services.Services.AdminService
{
    public class AdminService :IAdminService
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public AdminService(AppContext context, IMapper mapper)
        {
            _context = context;
            
            _mapper = mapper;
        }



        public async Task<bool> Register(Admin adminobj)
        {
            if (adminobj == null)
            {
                throw new ArgumentNullException();
            }

            var admin = await admin.
            

          
        }

       
        public string CreateJwt(Admin admin)
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("veryverysceret.....");
                var identity = new ClaimsIdentity(new Claim[]
                {

                new Claim(ClaimTypes.Name,$"{admin.UserName}")
                });

                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = DateTime.Now.AddSeconds(10),
                    SigningCredentials = credentials
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                return jwtTokenHandler.WriteToken(token);
            }


        public async Task<Admin> GetUserByUserNameAsync(string userName)
        {
            var username = _context.Admins.FirstOrDefault(c => c.UserName == userName);

        }
    }
  

    public class userNameNotfoundException: Exception { 
        public userNameNotfoundException(): base("use not found"){}
    }

    public class inavalidargumentException: Exception {
        public inavalidargumentException(string message): base(message) { }
    }

    public async Task<User> GetByUserNameAsync(Admin adminObj)
    {
        var admin = 
        
        if (user == null)
        {
            throw new userNameNotfoundException();

        }

        if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
        {
            throw new ArgumentException("Password is incorrect", nameof(userObj.Password));

        }

        user.Token = CreateJWT(user);


        return user;
    }

}

