using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW8.UserOrder.Models;

namespace Modul3HW8.UserOrder.Processors.Abstractions
{
    public interface IDataProcessor
    {
        public List<User> UserFunc(List<string> usersFromFile);
        public List<Order> OrderFunc(List<string> usersFromFile);
        public string ResultFunc(List<User> users, List<Order> orders);
    }
}
