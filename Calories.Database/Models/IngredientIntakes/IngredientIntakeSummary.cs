using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Models.IngredientIntakes
{
    public class IngredientIntakeSummary
    {
        public long Id { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public decimal Calories { get; set; }
    }
}
