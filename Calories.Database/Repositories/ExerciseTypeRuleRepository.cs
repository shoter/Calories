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
    public class ExerciseTypeRuleRepository : Repository<ExerciseTypeRule>, IExerciseTypeRuleRepository
    {
        public ExerciseTypeRuleRepository(DbContext context) : base(context)
        {
        }

        public async Task<ExerciseTypeRule> GetRuleForExerciseTypeAsync(int exerciseTypeID)
        {
            return await FirstOrDefaultAsync(e => e.ExerciseTypeID == exerciseTypeID);
        }
    }
}
