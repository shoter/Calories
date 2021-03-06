﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calories.Data;
using Common.Standard.EntityFramework.Repositories;

namespace Calories.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CaloriesContext context;
        public IWeightRepository WeightRepository { get; private set;  }

        public IIngredientRepository IngredientRepository { get; private set; } 

        public IIngredientIntakeRepository IngredientIntakeRepository { get; private set; }

        public IExerciseRepository ExerciseRepository { get; private set; }
        public IExerciseTypeRepository ExerciseTypeRepository { get; set; }
        public IExerciseTypeRuleRepository ExerciseTypeRuleRepository { get; private set; }
        public ISizeTypeRepository SizeTypeRepository { get; private set; }

        public UnitOfWork(CaloriesContext context)
        {
            WeightRepository = new WeightRepository(context);
            IngredientRepository = new IngredientRepository(context);
            IngredientIntakeRepository = new IngredientIntakeRepository(context);
            ExerciseRepository = new ExerciseRepository(context);
            ExerciseTypeRuleRepository = new ExerciseTypeRuleRepository(context);
            ExerciseTypeRepository = new ExerciseTypeRepository(context);
            SizeTypeRepository = new SizeTypeRepository(context);
            this.context = context;

        }

        async public Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
