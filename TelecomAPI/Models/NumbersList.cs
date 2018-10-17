using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TelecomAPI.Exceptions;

namespace TelecomAPI.Models
{
    public class NumbersList : List<Number>
    {
        public NumbersList() : base()
        { }

        public void AddNumber(string number, int customerId)
        {
            if (!Number.ValidateNumber(number))
            {
                throw new InvalidNumberException();
            }

            var newNumber = new Number(number, customerId);

            if (this.Any(p => p.PhoneNumber == number))
            {
                //cannot activate the same number twice
                throw new InvalidNumberException();
            }

            this.Add(newNumber);
        }


    }
}