using MyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Dto
{
    public record AddEmploymentDetailsDto(
       string CompanyName,
       string JobRole,
       int DomainId,
       string SkillsDeveloped,
       DateOnly JoiningDate,
       DateOnly TerminationDate,
       Guid UserId
        );

    public record GetEmploymentDetailsDto(
       Guid Id,
       string CompanyName,
       string JobRole,
       int DomainId,
       string SkillsDeveloped,
       DateOnly JoiningDate,
       DateOnly TerminationDate,
       Guid UserId
        );

    public record UpdateEmploymentDetailsDto(
       string CompanyName,
       string JobRole,
       int DomainId,
       string SkillsDeveloped,
       DateOnly JoiningDate,
       DateOnly TerminationDate,
       Guid UserId
    );
}
