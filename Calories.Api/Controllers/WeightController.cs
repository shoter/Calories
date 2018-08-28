using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspnet.Additions.Controllers;
using Aspnet.Additions.Models.Errors;
using Calories.Api.ApiModels.Weights;
using Calories.Data;
using Calories.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calories.Api.Controllers
{
    [Route("api/[controller]")]
    public class WeightController : BaseController
    {
        private readonly IUnitOfWork unit;
        public WeightController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        [HttpGet]
        [Route("{pageNumber:int}")]
        public async Task<IActionResult> Get(int pageSize = 10, int pageNumber = 0)
        {
            IEnumerable<Weight> weights = await unit.WeightRepository.GetPagedValues(pageSize, pageNumber);

            var vm = new WeightsListModel(weights);

            return Json(vm);
        }

        [HttpGet("{date:DateTime}")]
        public async Task<IActionResult> Get(DateTime date)
        {
            Weight weight = await unit.WeightRepository.GetWeightAtSpecifiedDate(date);

            return Ok(weight?.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewWeightApiModel data)
        {
            if (ModelState.IsValid)
            {
                unit.WeightRepository.Add(new Data.Weight()
                {
                    Date = data.Date.Value.ToUniversalTime(),
                    Value = data.Weight.Value
                });

                await unit.SaveChangesAsync();
                return Ok();
            }

            return ValidationFailed();
        }

        [HttpGet]
        [Route("HasWeightToday")]
        public async Task<IActionResult> HasWeightToday()
        {
            if (await unit.WeightRepository.HasWeightAtDay(DateTime.Now))
                return Ok(true);
            return Ok(false);
        }


    }
}
