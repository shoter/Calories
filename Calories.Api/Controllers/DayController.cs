using Aspnet.Additions.Controllers;
using Calories.Api.ApiModels.Days;
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
    public class DayController : BaseController
    {
        private readonly IUnitOfWork unit;

        public DayController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        [HttpGet]
        [Route("{summaryDate:datetime}")]
        public async Task<ActionResult> DaySummary(DateTime summaryDate)
        {
            var intakes = await unit.IngredientIntakeRepository.GetIntakesForDay(summaryDate);
            var exercises = await unit.ExerciseRepository.GetExercisesForDayAsync(summaryDate);

            decimal allowedIntake = 2200m;
            allowedIntake += exercises.Sum(e => e.CountedCalories) - intakes.Sum(i => i.Calories);

            var model = new DaySummaryModel()
            {
                Calories = intakes.Sum(i => i.Calories),
                Weight = (await unit.WeightRepository.GetWeightAtSpecifiedDate(summaryDate))?.Value,
                AllowedIntakeLeft = allowedIntake,
                ExerciseCalories = exercises.Sum(e => e.CountedCalories)

            };

            return Ok(model);
        }
    }
}
