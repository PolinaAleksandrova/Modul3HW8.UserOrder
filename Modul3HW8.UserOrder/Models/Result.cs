using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW8.UserOrder.Models
{
    public class Result
    {
        public uint Order_number { get; set; }
        public DateTime Order_date { get; set; }
        public string User_name { get; set; }
        public double Total { get; set; }
    }
}
