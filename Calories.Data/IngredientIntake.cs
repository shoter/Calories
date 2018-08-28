using Common.Standard.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Calories.Data
{
    public class IngredientIntake : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [ForeignKey(nameof(Ingredient))]
        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }
        public DateTime Date { get; set; }
        [DecimalPrecision(8,2)]
        public decimal Weight { get; set; }
        [DecimalPrecision(9,3)]
        public decimal Calories { get; set; }
    }
}
