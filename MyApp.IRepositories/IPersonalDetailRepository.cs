using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IRepositories
{
    public interface IPersonalDetailRepository: IRepository<PersonalDetails>
    {
        Task<IEnumerable<PersonalDetails>> GetByUserIdAsync(Guid userId);

    }
}
