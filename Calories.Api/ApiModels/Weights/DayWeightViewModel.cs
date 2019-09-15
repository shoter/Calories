using Calories.Database.Models.Weights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.ApiModels.Weights
{
    public class DayWeightViewModel
    {
        public decimal Value { get; set; }
        public decimal Average { get; set; }
        public string DateTime { get; set; }

        public DayWeightViewModel(DayWeight dw)
        {
            Value = dw.Weight;
            DateTime = dw.DayPoint.ToDateTime().ToShortDateString();
        }
    }
}
