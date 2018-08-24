using Calories.Data;
using Calories.Database.Models.IngredientIntakes;
using Common.Standard.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public interface IIngredientIntakeRepository : IRepository<IngredientIntake>
    {
        Task<IEnumerable<IngredientIntake>> Pagination(int pageSize = 10, int pageNumber = 0);

        Task<List<IngredientIntakeSummary>> GetIntakesForDay(DateTime day);
    }
}
