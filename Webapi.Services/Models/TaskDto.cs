using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapi.Services.Models
{
    public class TaskDto
    {
        public int TaskId { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }

        public int HelperId { get; set; }
        
        public int CustomerId { get; set; }
    }
}
