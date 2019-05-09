using NUnit.Framework;
using System;
using Vouchers.API.Controllers;
using Vouchers.API.Repository;

namespace Vouchers.API.Tests.Controllers
{
    [TestFixture]
    public class VoucherControllerPerformanceTests
    {
        private readonly VoucherController _controller;
        private readonly VoucherRepository _repository;
        private readonly VoucherJsonDataSource _dataSource;
        public VoucherControllerPerformanceTests()
        {
            _dataSource = new VoucherJsonDataSource($"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\Vouchers.API\\data.json");
            _repository = new VoucherRepository(_dataSource);
            _controller = new VoucherController(_repository);
        }
        
        [Test]
        public void Get_ShouldBePerformant()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 1000; i++)
            {
                _controller.Get();
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 15000);
        }

        [Test]
        public void Get_ShouldBePerformantWhenReturningASubset()
        {

            var startTime = DateTime.Now;

            for (var i = 0; i < 100000; i++)
            {
                _controller.Get(1000);
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 5000);
        }

        [Test]
        public void GetCheapestVoucherByProductCode_ShouldBePerformant()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 100; i++)
            {
                _controller.GetCheapestVoucherByProductCode("P007D");
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 15000);
        }
    }
}