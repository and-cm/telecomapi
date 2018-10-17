using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TelecomAPI.Models;

namespace TelecomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        // GET api/numbers
        [HttpGet]
        public ActionResult<List<Number>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/numbers/3
        [HttpGet("{customerId}")]
        public ActionResult<List<Number>> Get(int customerId)
        {
            throw new NotImplementedException();
        }

        // PUT api/numbers/3
        [HttpPut("{customerId}")]
        public void Put(int customerId, [FromBody] string number)
        {
            throw new NotImplementedException();
        }
    }
}
