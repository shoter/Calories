using Calories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.ApiModels.Weights
{
    public class WeightsListModel
    {
        public struct WeightEntry
        {
            public long Id;
            public decimal Weight;
            public DateTime Date;
        }

        public List<WeightEntry> Weights { get; set; } = new List<WeightEntry>();

        public WeightsListModel(IEnumerable<Weight> weights)
        {
            foreach (var weight in weights)
                Weights.Add(new WeightEntry()
                {
                    Date = weight.Date,
                    Id = weight.Id,
                    Weight = weight.Value
                });
        }
    }
}
