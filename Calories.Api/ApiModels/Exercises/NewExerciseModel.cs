using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.ApiModels.Exercises
{
    public class NewExerciseModel
    {
        public DateTime Date { get; set; }
        public decimal Calories { get; set; }
        public int ExerciseTypeID { get; set; }
    }
}
