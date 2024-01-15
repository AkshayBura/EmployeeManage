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
    public class EmploymentDetailRepository : Repository<EmploymentDetails>, IEmploymentDetailsRepository
    {
        public EmploymentDetailRepository(EMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<EmploymentDetails>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.Set<EmploymentDetails>().Where(e => e.UserId == userId).ToListAsync();
        }
    }
}
