﻿using Calories.Data;
using Common.Standard.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DbContext context) : base(context)
        {
        }

        public async Task<Ingredient> GetIngredient(string name)
        {
            return await FirstAsync(i => i.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients(string name)
        {
            name = name.ToLower().Trim();

            return await Where(ing => ing.Name.ToLower().Contains(name))
                .OrderBy(ing => ing.Name)
                .Take(10)
                .ToListAsync();

        }
    }
}
