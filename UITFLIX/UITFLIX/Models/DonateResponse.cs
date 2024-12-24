using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITFLIX.Models
{
    public class DonateResponse
    {
        public string code { get; set; }
        public string desc { get; set; }
        public DonateData data { get; set; }
    }
    public class DonateData
    {
        public int acpId { get; set; }
        public string accountName { get; set; }
        public string qrCode { get; set; }
        public string qrDataURL { get; set; }
    }
}
