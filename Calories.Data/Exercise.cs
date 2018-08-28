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
    public class Exercise : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ID { get; set; }
        [ForeignKey(nameof(ExerciseType))]
        public int ExerciseTypeID { get; set; }
        public ExerciseType ExerciseType { get; set; }

        public DateTime Date { get; set; }
        [DecimalPrecision(12,2)]
        public decimal Calories { get; set; }
        [DecimalPrecision(12,2)]
        public decimal CountedCalories { get; set; }
    }
}
