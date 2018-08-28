using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.ApiModels.Days
{
    public class DaySummaryModel
    {
        public decimal Calories { get; set; }
        public decimal? Weight { get; set; }
        public decimal AllowedIntakeLeft { get; set; }
        public decimal ExerciseCalories { get; set; }
    }
}
