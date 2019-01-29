using Calories.Data;
using Calories.Database.Models.Weights;
using Common.Standard.Dates;
using Common.Standard.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Database.Repositories
{
    public class WeightRepository : Repository<Weight>, IWeightRepository
    {
        public WeightRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Weight>> GetPagedValues(int pageSize = 10, int pageNumber = 0)
        {
            return await OrderByDescending(w => w.Date)
                   .Skip(pageNumber * pageSize)
                   .Take(pageSize)
                   .ToListAsync();
        }

        public async Task<Weight> GetWeightAtSpecifiedDate(DateTime date)
        {
            return await Where(w =>
            w.Date.Year == date.Year && w.Date.Month == date.Month && w.Date.Day == date.Day)
            .FirstOrDefaultAsync();
        }

        public async Task<List<DayWeight>> GetWeightBetween(DayPoint startDate, DayPoint endDate)
        {
           var list = await Where(w =>

           (w.Date.Year == startDate.Year && w.Date.Year < endDate.Year && w.Date.DayOfYear >= startDate.Day) ||
           (w.Date.Year == startDate.Year && w.Date.Year == endDate.Year && w.Date.DayOfYear >= startDate.Day && w.Date.DayOfYear <= endDate.Day) ||
           (w.Date.Year > startDate.Year && w.Date.Year < endDate.Year) ||
           (w.Date.Year == endDate.Year && w.Date.Year > startDate.Year && w.Date.Day <= endDate.Day))
            .Select(w => new DayWeight()
            {
                DayPoint = new DayPoint()
                {
                   Day = w.Date.DayOfYear,
                   Year = w.Date.Year
                },
                Weight = w.Value
            }).ToListAsync();

            if (list.Any() == false)
                return list;

            list = list.OrderBy(w => w.DayPoint).ToList();

            DayWeight last = list[0];

            DayRange dayRange = new DayRange(startDate, endDate);

            dayRange.ForEach(d =>
            {
                var weight = list.FirstOrDefault(w => w.DayPoint == d);
                if(weight != null)
                {
                    last = weight;
                }
                else
                {
                    list.Add(new DayWeight()
                    {
                        Weight = last.Weight,
                        DayPoint = d
                    });
                }
            });

            return list;
        }

        public async Task<bool> HasWeightAtDay(DateTime date)
        {
            var day = date.Day;

            return await AnyAsync(w =>
            w.Date.Year == date.Year &&
            w.Date.DayOfYear == date.DayOfYear);
        }
    }
}
