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

            decimal sum = 0m;

            int first, count;

            first = count = 0;

            const int maxCount = 14;

            for(int i = 0;i < this.Weights.Count; ++ i)
            {
                var w = Weights[i];

                sum += w.Value;
                count++;

                if(count >= maxCount)
                {
                    sum -= Weights[first].Value;
                    count--;
                    first++;
                }

                w.Average = sum / count;
            }


        }
    }
}
