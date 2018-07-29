using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.ApiModels.Weights
{
    public class NewWeightApiModel
    {
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public decimal? Weight { get; set; }
    }
}
