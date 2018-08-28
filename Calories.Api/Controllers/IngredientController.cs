using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspnet.Additions.Controllers;
using Calories.Api.ApiModels.Ingredients;
using Calories.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calories.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientController : BaseController
    {
        private readonly IUnitOfWork unit;

        public IngredientController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string ingredientName)
        {
            IEnumerable<Data.Ingredient> ingredient = await unit.IngredientRepository
                .GetIngredients(ingredientName);

            return Ok(ingredient);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var ingredients = await unit.IngredientRepository
                .OrderBy(ing => ing.Name)
                .ToListAsync();

            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewIngredientModel ingredient)
        {
            if (ModelState.IsValid)
            {
                unit.IngredientRepository.Add(new Data.Ingredient()
                {
                    SizeTypeID = ingredient.SizeTypeID.Value,
                    Calcium = ingredient.Calcium,
                    Calories = ingredient.Calories.Value,
                    Carbonhydrates = ingredient.Carbonhydrates,
                    Copper = ingredient.Copper,
                    Fat = ingredient.Fat,
                    Iron = ingredient.Iron,
                    Jod = ingredient.Jod,
                    Magnes = ingredient.Magnes,
                    Mangan = ingredient.Mangan,
                    Name = ingredient.Name,
                    Phosphor = ingredient.Phosphor,
                    Potas = ingredient.Potas,
                    Proteins = ingredient.Proteins,
                    Roughage = ingredient.Roughage,
                    Sodium = ingredient.Sodium,
                    Zinc = ingredient.Zinc
                });

                await unit.SaveChangesAsync();
                return Ok();
            }
            return ValidationFailed(); 
        }
    }
}
