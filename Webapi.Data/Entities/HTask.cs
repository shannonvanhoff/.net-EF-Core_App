using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapi.Data.Entities
{
    public class HTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        //[ForeignKey("HelperId")]
        public int HelperId { get; set; }
        public Helper Helper { get; set; }

        public int CustomerId { get; set; }

        //[ForeignKey("CustomerId")]
        public Customer Customer { get; set; }



    }
}
