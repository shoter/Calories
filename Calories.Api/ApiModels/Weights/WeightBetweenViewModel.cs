using Calories.Database.Models.Weights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.ApiModels.Weights
{
    public class WeightBetweenViewModel
    {
        public List<DayWeightViewModel> Weights { get; set; }

        public WeightBetweenViewModel(IEnumerable<DayWeight> weights)
        {
            Weights = weights
                .Select(w => new DayWeightViewModel(w))
                .ToList();
        }
    }
}
