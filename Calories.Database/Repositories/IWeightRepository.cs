using Calories.Data;
using Calories.Database.Models.Weights;
using Common.Standard.Dates;
using Common.Standard.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public interface IWeightRepository : IRepository<Weight>
    {
        Task<IEnumerable<Weight>> GetPagedValues(int pageSize = 10, int pageNumber = 0);
        Task<Weight> GetWeightAtSpecifiedDate(DateTime date);

        Task<bool> HasWeightAtDay(DateTime date);

        Task<List<DayWeight>> GetWeightBetween(DayPoint startDate, DayPoint endDate);
    }
}
