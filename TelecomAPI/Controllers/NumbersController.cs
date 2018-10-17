using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TelecomAPI.Models;
using TelecomAPI.Exceptions;

namespace TelecomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        NumbersList Numbers = new NumbersList();

        // GET api/numbers
        [HttpGet]
        public ActionResult<List<Number>> Get()
        {
            return Numbers;
        }

        // GET api/numbers/3
        [HttpGet("{customerId}")]
        public ActionResult<List<Number>> Get(int customerId)
        {
            var output = Numbers.FindAll(p => p.CustomerId == customerId);
            if (output.Count == 0)
            {
                //Customer IDs are invalid when they do not exist in our list
                throw new InvalidCustomerException();
            }
            else
            {
                return output;
            }
        }

        // PUT api/numbers/3
        [HttpPut("{customerId}")]
        public void Put(int customerId, [FromBody] string number)
        {
            //For now we can assume that all new customer IDs are valid
            Numbers.AddNumber(number, customerId);
        }
    }
}
