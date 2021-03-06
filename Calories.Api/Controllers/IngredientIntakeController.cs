﻿using Aspnet.Additions.Controllers;
using Calories.Api.ApiModels.IngredientIntakes;
using Calories.Data.Enums;
using Calories.Database.Repositories;
using Calories.Services.Intakes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientIntakeController : BaseController
    {
        private readonly IUnitOfWork unit;
        public IngredientIntakeController(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewIngredientIntakeModel model)
        {
            if (ModelState.IsValid)
            {
                var calc = new IngredientIntakeCalorieCalculator();
                var ing = await unit.IngredientRepository.FirstAsync(i => i.ID == model.IngredientID);

                unit.IngredientIntakeRepository.Add(new Data.IngredientIntake()
                {
                    Date = model.Date.Value,
                    Calories = calc.Calculate(model.Weight.Value, ing.Calories, (SizeTypeEnum)ing.SizeTypeID),
                    IngredientID = model.IngredientID.Value,
                    Weight = model.Weight.Value
                });

                await unit.SaveChangesAsync();
                return Ok();
            }

            return ValidationFailed();
        }
        [HttpGet("Get")]
        [Route("{pageNumber:int}")]
        public async Task<IActionResult> Pagination(int pageSize = 10, int pageNumber = 0)
        {
            var intakes = await unit.IngredientIntakeRepository
                .Pagination(pageSize, pageNumber);

            return Ok(intakes);
        }

        [HttpGet("Get")]
        [Route("{intakeDay:DateTime}")]
        public async Task<IActionResult> GetIntakeForDay(DateTime intakeDay)
        {
            var intakes = await unit.IngredientIntakeRepository
                .GetIntakesForDay(intakeDay);

            return Ok(intakes);
        }
    }
}
