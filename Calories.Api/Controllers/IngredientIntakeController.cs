using Aspnet.Additions.Controllers;
using Calories.Api.ApiModels.IngredientIntakes;
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
                unit.IngredientIntakeRepository.Add(new Data.IngredientIntake()
                {
                    Date = model.Date.Value,
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
        [Route("{day:DateTime}")]
        public async Task<IActionResult> GetIntakeForDay(DateTime day)
        {
            var intakes = await unit.IngredientIntakeRepository
                .GetIntakesForDay(day);

            return Ok(intakes);
        }
    }
}
