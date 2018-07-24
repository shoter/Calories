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
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [DecimalPrecision(10, 2)]
        public decimal Calories { get; set; }
        [DecimalPrecision(10, 2)]
        public decimal? Proteins { get; set; }
        [DecimalPrecision(10, 2)]
        public decimal? Fat { get; set; }
        [DecimalPrecision(10, 2)]
        public decimal? Carbonhydrates { get; set; }
        [DecimalPrecision(10, 2)]
        public decimal? Roughage { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Magnes { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Potas { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Calcium { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Phosphor { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Iron { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Zinc { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Copper { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Mangan { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Sodium { get; set; }
        [DecimalPrecision(14, 8)]
        public decimal? Jod { get; set; }
    }
}
