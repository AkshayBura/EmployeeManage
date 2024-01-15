using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Dto
{
    public record AddPersonalDetailsDto(
       Guid UserId,
       string Address,
       DateOnly DOB,
       string AadhaarNumber,
       int DegreeId,
       int StatusId
     );

    public record GetPersonalDetailsDto(
       Guid Id,
       Guid UserId,
       string Address,
       DateOnly DOB,
       string AadhaarNumber,
       int DegreeId,
       int StatusId
        );

    public record UpdatePersonalDetailsDto(
       string Address,
       DateOnly DOB,
       string AadhaarNumber,
       int DegreeId,
       int StatusId
    );
}
