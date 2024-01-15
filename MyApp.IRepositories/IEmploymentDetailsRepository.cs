using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IRepositories
{
    public interface IEmploymentDetailsRepository: IRepository<EmploymentDetails>
    {
        Task<IEnumerable<EmploymentDetails>> GetByUserIdAsync(Guid userId);
    }
}
