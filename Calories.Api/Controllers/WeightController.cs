using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspnet.Additions.Models.Errors;
using Calories.Api.ApiModels.Weights;
using Calories.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calories.Api.Controllers
{
    [Route("api/[controller]")]
    public class WeightController : Controller
    {
        private readonly IUnitOfWork unit;
        public WeightController(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public async Task<IActionResult> Post([FromBody]NewWeightApiModel weight)
        {
            if (ModelState.IsValid)
            {
                unit.WeightRepository.Add(new Data.Weight()
                {
                    Date = weight.Date.Value.ToUniversalTime(),
                    Value = weight.Weight.Value
                });

                await unit.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(new ValidationResultModel(ModelState));
        }


    }
}
