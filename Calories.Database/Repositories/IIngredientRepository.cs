using Calories.Data;
using Common.Standard.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Task<Ingredient> GetIngredient(string name);
        Task<IEnumerable<Ingredient>> GetIngredients(string name);
    }
}
