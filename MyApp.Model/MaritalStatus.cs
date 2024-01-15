using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    [Table("MaritalStatus")]
    public class MaritalStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
    }
}
