using System;
using System.Web.Http;
using Vouchers.API.Models;
using Vouchers.API.Repository;

namespace Vouchers.API.Controllers
{
    [RoutePrefix("api/voucher")]
    public class VoucherController : ApiController
    {
        private readonly IVoucherRepository _voucherRepository;
        public VoucherController(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        [HttpGet]
        public Voucher[] Get([FromUri]int count = 0)
        {           
            return _voucherRepository.GetVouchers(count);
        }

        [Route("GetVoucherById")]
        [HttpGet]
        public Voucher GetVoucherById([FromUri]Guid id)
        {
            return _voucherRepository.GetVoucher(id);
        }

        [Route("GetVouchersByName")]
        [HttpGet]
        public Voucher[] GetVouchersByName([FromUri]string name)
        {
            return _voucherRepository.GetVouchers(name);
        }

        [Route("GetVouchersByNameSearch")]
        [HttpGet]
        public Voucher[] GetVouchersByNameSearch([FromUri]string search)
        {
            return _voucherRepository.Search(search);
        }

        [Route("GetCheapestVoucherByProductCode")]
        [HttpGet]
        public Voucher GetCheapestVoucherByProductCode([FromUri]string productCode)
        {
            return _voucherRepository.GetCheapest(productCode);
        }        
    }
}