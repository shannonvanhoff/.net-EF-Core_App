using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapi.Services.Models
{
    public class CustomerDto
    { 
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Description { get; set; }
        //public string FullName { get; set; }
    }
}
