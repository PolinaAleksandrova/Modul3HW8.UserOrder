using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW8.UserOrder.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Order_number { get; set; }
        public DateTime Order_date { get; set; }
        public double Total { get; set; }
    }
}
