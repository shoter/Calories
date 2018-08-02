using Calories.Data;
using Common.Standard.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public class WeightRepository : Repository<Weight>, IWeightRepository
    {
        public WeightRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Weight>> GetPagedValues(int pageSize = 10, int pageNumber = 0)
        {
            return await OrderByDescending(w => w.Date)
                   .Skip(pageNumber * pageSize)
                   .Take(pageSize)
                   .ToListAsync();
        }
    }
}
