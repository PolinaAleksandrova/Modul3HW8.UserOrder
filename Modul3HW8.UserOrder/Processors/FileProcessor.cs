using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW8.UserOrder.Processors.Abstractions;

namespace Modul3HW8.UserOrder.Processors
{
    public class FileProcessor : IFileProcessor
    {
        public async Task<List<string>> ReadAsync(string path)
        {
            var allData = new List<string>();
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    allData.Add(line);
                }
            }

            return allData;
        }

        public async void WriteAsync<T>(string path, T data)
        {
            using (StreamWriter str = new StreamWriter(path, false, Encoding.Default))
            {
                await str.WriteAsync(Convert.ToString(data));
            }
        }
    }
}
