using Calories.Database;
using Calories.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Calories.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CaloriesContextFactory().CreateDbContext(new string[0]);
            var unit = new UnitOfWork(context);

            var repo = unit.WeightRepository;

            string str=  System.Console.ReadLine();
            decimal weight = decimal.Parse(str);

            repo.Add(new Data.Weight()
            {
                Date = DateTime.Now,
                Value = weight
            });

            var task = unit.SaveChangesAsync();

            Task.WaitAll(task);
        }
    }
}
