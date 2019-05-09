using System;
using Vouchers.API.Models;

namespace Vouchers.API.Repository
{
    public interface IVoucherRepository
    {
        Voucher[] GetVouchers(int count=0);
        Voucher GetVoucher(Guid productId);
        Voucher[] GetVouchers(string productName);
        Voucher[] Search(string productName);
        Voucher GetCheapest(string productCode);
    }
}