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
    }
}