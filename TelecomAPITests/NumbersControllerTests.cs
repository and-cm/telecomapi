using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelecomAPI.Controllers;
using TelecomAPI.Models;
using TelecomAPI.Exceptions;

namespace TelecomAPITests
{
    [TestClass]
    public class NumbersControllerTests
    {
        NumbersController _controller;

        public NumbersControllerTests()
        {
            _controller = new NumbersController();
        }

        [TestMethod]
        public void GetAllNumbers()
        {
            var result = _controller.Get();

            Assert.IsTrue(result.Value.Count > -1);
        }

        [TestMethod]
        public void GetAllNumbers_Additions()
        {
            //arrange
            _controller.Put(0, "01234567890");
            _controller.Put(0, "12345678901");
            _controller.Put(0, "23456789012");

            var result = _controller.Get();
            Assert.IsTrue(result.Value.Count == 3);
        }

        [TestMethod]
        public void GetAllNumbersForValidCustomer()
        {
            int validCustomerId = 0;
            _controller.Put(validCustomerId, "01234567890");

            var result = _controller.Get(validCustomerId);
            Assert.IsTrue(result.Value.Count > -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCustomerException))]
        public void GetAllNumbersForInvalidCustomer()
        {
            int invalidCustomerId = 1000;
            _controller.Put(0, "01234567890");

            var result = _controller.Get(invalidCustomerId);
        }

        [TestMethod]
        public void ActivateValidNumber()
        {
            string validNumber = "01234567890";
            _controller.Put(0, validNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void ActivateInvalidNumber_TooLong()
        {
            string invalidNumber = "01234567890000";
            _controller.Put(0, invalidNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void ActivateInvalidNumber_TooShort()
        {
            string invalidNumber = "0123456";
            _controller.Put(0, invalidNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void ActivateInvalidNumber_NotNumber()
        {
            string invalidNumber = "01234aaa890";
            _controller.Put(0, invalidNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void ActivateInvalidNumber_EmptyNumber()
        {
            string invalidNumber = "";
            _controller.Put(0, invalidNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void ActivateInvalidNumber_MissingNumber()
        {
            string invalidNumber = null;
            _controller.Put(0, invalidNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberException))]
        public void ActivateInvalidNumber_DuplicateNumber()
        {
            string invalidNumber = "00000000000";
            _controller.Put(0, invalidNumber);
            _controller.Put(1, invalidNumber);
        }

    }
}
