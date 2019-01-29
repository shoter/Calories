using Common.Standard.Dates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Models.Weights
{
    public class DayWeight
    {
        public decimal Weight { get; set; }
        public DayPoint DayPoint { get; set; }
    }
}
