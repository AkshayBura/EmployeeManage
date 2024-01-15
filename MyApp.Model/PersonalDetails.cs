using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    [Table("PersonalDetails")]
    public class PersonalDetails
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string Address { get; set; }
        public DateOnly DOB { get; set; }
        public string AadhaarNumber { get; set; }

        [ForeignKey("Degree")]
        public int DegreeId { get; set; }
        public virtual Degree Degree { get; set; }

        [ForeignKey("MaritalStatus")]
        public int StatusId { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
    }
}
