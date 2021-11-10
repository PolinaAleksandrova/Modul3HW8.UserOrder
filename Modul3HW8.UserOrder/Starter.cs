using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Modul3HW8.UserOrder.Processors;
using Modul3HW8.UserOrder.Processors.Abstractions;

namespace Modul3HW8.UserOrder
{
    public class Starter
    {
        public void StartApplication()
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<IDataProcessor, DataProcessor>()
            .AddTransient<IFileProcessor, FileProcessor>()
            .AddTransient<Application>()
            .BuildServiceProvider();
            var appStarter = serviceProvider.GetService<Application>();
            appStarter.Run();
        }
    }
}
