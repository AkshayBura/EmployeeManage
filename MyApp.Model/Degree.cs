using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    [Table("Degree")]
    public class Degree
    {
        [Key]
        public int DegreeId { get; set; }
        public string DegreeCode { get; set; }
        public string DegreeName { get; set;}
    }
}
