using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW8.UserOrder.Models;
using Modul3HW8.UserOrder.Processors.Abstractions;

namespace Modul3HW8.UserOrder.Processors
{
    public class DataProcessor : IDataProcessor
    {
        public List<User> UserFunc(List<string> usersFromFile)
        {
            var allUsers = new List<User>();
            foreach (var user in usersFromFile)
            {
                string[] userStr = user.Split(';');
                var addedUser = new User()
                {
                    Id = Convert.ToInt32(userStr[0]),
                    Name = userStr[1],
                    Gender = userStr[2],
                    Age = Convert.ToInt32(userStr[3])
                };
                allUsers.Add(addedUser);
            }

            return allUsers;
        }

        public List<Order> OrderFunc(List<string> ordersFromFile)
        {
            var allOrders = new List<Order>();
            foreach (var order in ordersFromFile)
            {
                string[] orderStr = order.Split(';');

                var addedOrder = new Order()
                {
                    Id = Convert.ToInt32(orderStr[0]),
                    User_id = Convert.ToInt32(orderStr[1]),
                    Order_number = Convert.ToInt32(orderStr[2]),
                    Order_date = Convert.ToDateTime(orderStr[3]),
                    Total = Convert.ToDouble(orderStr[4])
                };
                allOrders.Add(addedOrder);
            }

            return allOrders;
        }

        public string ResultFunc(List<User> users, List<Order> orders)
        {
            var res = new StringBuilder();
            var selectedOrders = from user in users
                                 from order in orders
                                 where user.Id == order.User_id
                                 where user.Age > 18 && user.Age < 65
                                 where order.Order_date >= DateTime.Now.AddDays(-7)
                                 orderby order.Order_date descending
                                 select new
                                 {
                                     Order_Number = order.Order_number,
                                     Order_Date = order.Order_date.ToString("yyyy-MM-dd"),
                                     User_Name = user.Name,
                                     Total = order.Total
                                 };
            foreach (var selected in selectedOrders)
            {
                res.AppendLine($"{selected.Order_Number};{selected.Order_Date};{selected.User_Name};{selected.Total};");
            }

            return res.ToString();
        }
    }
}
