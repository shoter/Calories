using Calories.Data;
using Common.Standard.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public interface IExerciseTypeRuleRepository : IRepository<ExerciseTypeRule>
    {
        Task<ExerciseTypeRule> GetRuleForExerciseTypeAsync(int exerciseTypeID);


    }
}
