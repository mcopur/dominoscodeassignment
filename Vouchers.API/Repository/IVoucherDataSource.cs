using Vouchers.API.Models;

namespace Vouchers.API.Repository
{
    public interface IVoucherDataSource
    {
        Voucher[] Vouchers { get;}
    }

}