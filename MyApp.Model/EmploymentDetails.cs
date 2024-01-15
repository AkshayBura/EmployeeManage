using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    [Table("EmploymentDetails")]
    public class EmploymentDetails
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string JobRole { get; set; }
        [ForeignKey("Domain")]
        public int DomainId { get; set; }
        public virtual Domain Domain { get; set; }
        public string SkillsDeveloped { get; set; }
        public DateOnly JoiningDate { get; set; }
        public DateOnly TerminationDate { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
