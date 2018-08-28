using Common.Standard.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Data
{
    public class ExerciseTypeRule : IEntity
    {
        [ForeignKey(nameof(ExerciseType))]
        [Key]
        public int ExerciseTypeID { get; set; }
        public ExerciseType ExerciseType { get; set; }

        /// <summary>
        /// Small Value. Usually from 0.0 -> 1.0 indicating how to change Calories from given type of exercise.
        /// </summary>
        [DecimalPrecision(10,5)]
        public decimal CaloriesModifier { get; set; }
    }
}
