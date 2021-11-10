using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW8.UserOrder.Processors.Abstractions
{
    public interface IFileProcessor
    {
        public Task<List<string>> ReadAsync(string path);
        public void WriteAsync<T>(string path, T data);
    }
}
