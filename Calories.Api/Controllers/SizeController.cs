using Calories.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calories.Api.Controllers
{
    [Route("api/[controller]")]
    public class SizeController : ControllerBase
    {
        IUnitOfWork unit;
        public SizeController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        [HttpGet]
        [Route("SizeType")]
        public async Task<IActionResult> GetSizeTypes()
        {
            var sizeTypes = (await unit.SizeTypeRepository.ToListAsync())
                .Select(t => new
                {
                    ID = t.ID,
                    Name = t.Name
                });

            return Ok(sizeTypes);
        }

        [HttpGet]
        [Route("SizeType/{sizeTypeID:int}")]
        public async Task<IActionResult> GetSizeType(int sizeTypeID)
        {
            return Ok(await
                unit.SizeTypeRepository.FirstAsync(st => st.ID == sizeTypeID));
        }
    }
}
