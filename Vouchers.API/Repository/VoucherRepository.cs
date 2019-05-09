using System;
using System.Linq;
using Vouchers.API.Models;

namespace Vouchers.API.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly IVoucherDataSource _dataSource;
        public VoucherRepository(IVoucherDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public Voucher GetCheapest(string productCode)
        {
            return _dataSource.Vouchers.Where(v => v.ProductCodes == productCode)
                .OrderBy(p => p.Price).FirstOrDefault();
        }

        public Voucher[] GetVouchers(int count = 0)
        {
            if (count == 0)
            {
                return _dataSource.Vouchers.ToArray();
            }

            return _dataSource.Vouchers.Take(count).ToArray();
        }

        public Voucher GetVoucher(Guid productId)
        {
            return _dataSource.Vouchers.SingleOrDefault(voucher => voucher.Id == productId);
        }

        public Voucher[] GetVouchers(string productName)
        {
            return _dataSource.Vouchers.Where(voucher => voucher.Name == productName).ToArray();
        }

        public Voucher[] Search(string productName)
        {
            return _dataSource.Vouchers.Where(voucher => voucher.Name.Contains(productName)).ToArray();
        }
    }
}