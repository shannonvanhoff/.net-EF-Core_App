﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapi.Data.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Token   { get; set; }

        public string Email { get; set; }


    }
}