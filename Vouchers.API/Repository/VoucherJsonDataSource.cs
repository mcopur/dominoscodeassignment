using Newtonsoft.Json;
using System.IO;
using Vouchers.API.Models;

namespace Vouchers.API.Repository
{
    public class VoucherJsonDataSource:IVoucherDataSource
    {
        private readonly string _fileName;

        public VoucherJsonDataSource(string fileName)
        {
            _fileName = fileName;
        }
        private static Voucher[] _vouchers;

        public Voucher[] Vouchers
        {
            get
            {
                if (_vouchers == null)
                {
                    var text = File.ReadAllText(_fileName);
                    _vouchers = JsonConvert.DeserializeObject<Voucher[]>(text);
                }
                return _vouchers;
            }
        }
    }
}