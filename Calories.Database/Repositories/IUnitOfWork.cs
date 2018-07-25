using Calories.Data;
using Common.Standard.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public interface IUnitOfWork
    {
        IWeightRepository WeightRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        IIngredientIntakeRepository IngredientIntakeRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
