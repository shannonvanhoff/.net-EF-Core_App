using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapi.Data.Entities
{
    public class Helper
    {
        [Key]
        public int HelperId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        public List<HTask> HelperList { get; set; }
        public bool? IsActive { get; set; }
    }
}
