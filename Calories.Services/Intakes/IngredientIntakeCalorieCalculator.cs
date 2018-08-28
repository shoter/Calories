using Calories.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Services.Intakes
{
    public class IngredientIntakeCalorieCalculator
    {
        public decimal Calculate(decimal weight, decimal calories, SizeTypeEnum sizeType)
        {
            switch(sizeType)
            {
                case SizeTypeEnum.Grams:
                    return weight / 100m * calories;
                case SizeTypeEnum.Pieces:
                    return weight * calories;
            }

            throw new NotImplementedException();
        }
    }
}
