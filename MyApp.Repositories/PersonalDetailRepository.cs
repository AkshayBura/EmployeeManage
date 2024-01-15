using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.IRepositories;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repositories
{
    public class PersonalDetailRepository : Repository<PersonalDetails>, IPersonalDetailRepository
    {
        public PersonalDetailRepository(EMDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<PersonalDetails>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.Set<PersonalDetails>().Where(e => e.UserId == userId).ToListAsync();
        }
    }
}
