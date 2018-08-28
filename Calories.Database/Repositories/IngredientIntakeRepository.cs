using Calories.Data;
using Calories.Database.Models.IngredientIntakes;
using Common.Standard.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public class IngredientIntakeRepository : Repository<IngredientIntake>, IIngredientIntakeRepository
    {
        public IngredientIntakeRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<IngredientIntake>> Pagination(int pageSize = 10, int pageNumber = 0)
        {
            return await OrderByDescending(intake => intake.Date)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<IngredientIntakeSummary>> GetIntakesForDay(DateTime day)
        {
            return await OrderByDescending(intake => intake.Date)
                .Where(i =>
                i.Date.Year == day.Year && i.Date.DayOfYear == day.DayOfYear)
                .Select(i => new IngredientIntakeSummary()
                {
                    Calories = i.Calories,
                    Date = i.Date,
                    Weight = i.Weight,
                    Id = i.ID,
                    IngredientId = i.IngredientID,
                    IngredientName = i.Ingredient.Name
                }).ToListAsync();
        }
    }
}
