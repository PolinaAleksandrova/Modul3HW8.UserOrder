using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW8.UserOrder.Processors.Abstractions;

namespace Modul3HW8.UserOrder
{
    public class Application
    {
        private readonly IFileProcessor _fileProcessor;
        private readonly IDataProcessor _dataProcessor;

        public Application(IFileProcessor fileProcessor, IDataProcessor dataProcessor)
        {
            _fileProcessor = fileProcessor;
            _dataProcessor = dataProcessor;
        }

        public void Run()
        {
            var getUser = _fileProcessor.ReadAsync("users.txt").Result;
            var getOrder = _fileProcessor.ReadAsync("orders.txt").Result;
            var userList = _dataProcessor.UserFunc(getUser);
            var orderList = _dataProcessor.OrderFunc(getOrder);

            var resultsList = _dataProcessor.ResultFunc(userList, orderList);
            _fileProcessor.WriteAsync<string>("results.txt", resultsList);
        }
    }
}
