using System;
using System.ComponentModel.DataAnnotations;
using TelecomAPI.Exceptions;

namespace TelecomAPI.Models
{
    public class Number
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int CustomerId { get; set; }

        public Number(string number, int customerId)
        {
            if (!ValidateNumber(number))
            {
                throw new InvalidNumberException();
            }

            PhoneNumber = number;
            CustomerId = customerId;
        }

        public static bool ValidateNumber(string number)
        {
            if (number == null)
            {
                return false;
            }
            if (number.Length != 11)
            {
                return false;
            }
            if (!IsDigitsOnly(number))
            {
                return false;
            }
            //otherwise...
            return true;
        }

        private static bool IsDigitsOnly(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}