using Aspnet.Additions.Controllers;
using Calories.Api.ApiModels.Exercises;
using Calories.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExerciseController : BaseController
    {
        private readonly IUnitOfWork unit;

        public ExerciseController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewExerciseModel ex)
        {
            decimal caloriesCounted = ex.Calories;
            var rule = await unit.ExerciseTypeRuleRepository.GetRuleForExerciseTypeAsync(ex.ExerciseTypeID);
            if (rule != null)
                caloriesCounted *= rule.CaloriesModifier;

            unit.ExerciseRepository.Add(new Data.Exercise()
            {
                Calories = ex.Calories,
                CountedCalories = caloriesCounted,
                Date = ex.Date,
                ExerciseTypeID = ex.ExerciseTypeID
            });

            await unit.SaveChangesAsync();

            return Ok();
        }

        [Route("Types/")]
        [HttpGet]
        public async Task<IActionResult> GetAllTypes()
        {
            var types = (await unit.ExerciseTypeRepository.ToListAsync())
                .Select(t => new
                {
                    ID = t.ID,
                    Name = t.Name
                });

            return Ok(types);
        }

        [HttpPost]
        [Route("Rules/{exerciseTypeID:int}")]
        public async Task<IActionResult> UpSetRule(int exerciseTypeID, decimal modifier)
        {
            var rule = await unit.ExerciseTypeRuleRepository.GetRuleForExerciseTypeAsync(exerciseTypeID);
            if(rule != null)
            {
                rule.CaloriesModifier = modifier;
            }
            else
            {
                unit.ExerciseTypeRuleRepository.Add(new Data.ExerciseTypeRule()
                {
                    CaloriesModifier = modifier,
                    ExerciseTypeID = exerciseTypeID
                });
            }

            await unit.SaveChangesAsync();
            return Ok();
        }


    }
}
