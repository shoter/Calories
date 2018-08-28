using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.ApiModels.Ingredients
{
    public class NewIngredientModel
    {
        public string Name { get; set; }
        [Required]
        public decimal? Calories { get; set; }
        [Required]
        public int? SizeTypeID { get; set; }

        public decimal? Proteins { get; set; }
        public decimal? Fat { get; set; }
        public decimal? Carbonhydrates { get; set; }
        public decimal? Roughage { get; set; }
        public decimal? Magnes { get; set; }
        public decimal? Potas { get; set; }
        public decimal? Calcium { get; set; }
        public decimal? Phosphor { get; set; }
        public decimal? Iron { get; set; }
        public decimal? Zinc { get; set; }
        public decimal? Copper { get; set; }
        public decimal? Mangan { get; set; }
        public decimal? Sodium { get; set; }
        public decimal? Jod { get; set; }

    }
}
