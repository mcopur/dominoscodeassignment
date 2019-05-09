using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Vouchers.API.Controllers;
using Vouchers.API.Models;
using Vouchers.API.Repository;

namespace Vouchers.API.Tests.Controllers
{
    [TestFixture]
    public class VoucherControllerTests
    {
        private readonly VoucherController _controller;

        private readonly VoucherRepository _repository;

        private readonly IVoucherDataSource _dataSource = Substitute.For<IVoucherDataSource>();

        private readonly List<Voucher> _vouchers = new List<Voucher>();

        public VoucherControllerTests()
        {
            _repository = new VoucherRepository(_dataSource);
            _controller = new VoucherController(_repository);
        }

        [SetUp]
        public void Setup()
        {
            _dataSource.Vouchers.Returns(info => _vouchers.ToArray());
        }

        [Test]
        public void Get_ShouldReturnRequestedNumberOfVouchers()
        {
            for (var i = 0; i < 1000; i++)
            {
                _vouchers.Add(new Voucher
                {
                    Id = new Guid()
                });
            }

            var result = _controller.Get(100);

            Assert.AreEqual(100, result.Length);
        }

        [Test]
        public void Get_ShouldReturnAllVouchersByDefault()
        {
            for (var i = 0; i < 1000; i++)
            {
                _vouchers.Add(new Voucher
                {
                    Id = new Guid()
                });
            }

            var result = _controller.Get();

            Assert.AreEqual(_vouchers.Count, result.Length);
        }

        [Test]
        public void GetVouchersByName_ShouldReturnAllVouchersWithTheGivenName()
        {
            _vouchers.Clear();
            var a1Voucher = new Voucher { Id = new Guid(), Name = "A" };
            var a2Voucher = new Voucher { Id = new Guid(), Name = "A" };
            var b1Voucher = new Voucher { Id = new Guid(), Name = "B" };

            _vouchers.Add(a1Voucher);
            _vouchers.Add(a2Voucher);
            _vouchers.Add(b1Voucher);

            var result = _controller.GetVouchersByName("A");
            Assert.AreEqual(new[] { a1Voucher, a2Voucher }, result);
        }

        [Test]
        public void GetVouchersById_ShouldReturnVoucherWithTheGivenId()
        {
            _vouchers.Clear();
            var a1Voucher = new Voucher { Id = new Guid("63BF890950544292996FDAB38D6A71AA"), Name = "A" };
            var a2Voucher = new Voucher { Id = new Guid("63BF890950544292996FDAB38D6A71BB"), Name = "A" };
            var b1Voucher = new Voucher { Id = new Guid("63BF890950544292996FDAB38D6A71CC"), Name = "B" };

            _vouchers.Add(a1Voucher);
            _vouchers.Add(a2Voucher);
            _vouchers.Add(b1Voucher);

            var result = _controller.GetVoucherById(new Guid("63BF890950544292996FDAB38D6A71BB"));
            Assert.AreEqual(a2Voucher, result);
        }

        [Test]
        public void GetCheapestVoucherByProductCode_ShouldReturnCheapestVoucherWithTheGivenProductCodes()
        {
            _vouchers.Clear();
            var voucher1 = new Voucher { Id = new Guid(), Name = "A", Price=89,ProductCodes="AA,BB" };
            var voucher2 = new Voucher { Id = new Guid(), Name = "B", Price = 28, ProductCodes = "AA,BB" };
            var voucher3 = new Voucher { Id = new Guid(), Name = "C", Price = 13, ProductCodes = "AA,BB" };
            var voucher4 = new Voucher { Id = new Guid(), Name = "D", Price = 55, ProductCodes = "AA,BB,CC" };
            var voucher5 = new Voucher { Id = new Guid(), Name = "E", Price = 25, ProductCodes = "AA,BB" };

            _vouchers.Add(voucher1);
            _vouchers.Add(voucher2);
            _vouchers.Add(voucher3);
            _vouchers.Add(voucher4);
            _vouchers.Add(voucher5);

            var result = _controller.GetCheapestVoucherByProductCode("AA,BB");
            Assert.AreEqual(voucher3, result);
        }

        [Test]
        public void GetVouchersByNameSearch_ShouldReturnAllVouchersWhichMatchTheSearch()
        {
            var a1Voucher = new Voucher { Id = new Guid(), Name = "ABC" };
            var a2Voucher = new Voucher { Id = new Guid(), Name = "ABCD" };
            var b1Voucher = new Voucher { Id = new Guid(), Name = "ACD" };

            _vouchers.Add(a1Voucher);
            _vouchers.Add(a2Voucher);
            _vouchers.Add(b1Voucher);

            var result = _controller.GetVouchersByNameSearch("BC");

            Assert.AreEqual(new[] { a1Voucher, a2Voucher }, result);
        }
    }
}