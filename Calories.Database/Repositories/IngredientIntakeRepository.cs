using Calories.Data;
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
    }
}
