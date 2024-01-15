using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    [Table("Domain")]
    public class Domain
    {
        [Key]
        public int DomainId { get; set; }
        public string DomainCode { get; set; }
        public string DomainName { get; set; }
    }
}
