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
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Exercise>> GetExercisesForDayAsync(DateTime date)
        {
            return await Where(e => e.Date.Day == date.Day
            && e.Date.Month == date.Month
            && e.Date.Year == date.Year).ToListAsync();
        }
    }
}
