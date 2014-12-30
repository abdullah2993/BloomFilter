using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BloomFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bloomFilter = new BloomFilter(12);
            var list = GetRandomBytes();

            foreach (var data in list)
            {
                bloomFilter.Add(data);
            }

            foreach (var data in list)
            {
                Console.WriteLine("{0} Exists: {1}",BitConverter.ToString(data).Replace("-",""),bloomFilter.Exist(data));
            }

            list = GetRandomBytes();

            foreach (var data in list)
            {
                Console.WriteLine("{0} Exists: {1}", BitConverter.ToString(data).Replace("-", ""), bloomFilter.Exist(data));
            }

            Process.GetCurrentProcess().WaitForExit();
        }

        public static List<byte[]> GetRandomBytes()
        {
            var list = new List<byte[]>();
            var random = new Random();
            var tempBuffer = new byte[10];
            for (var i = 0; i < 1000; i++)
            {
                random.NextBytes(tempBuffer);
                list.Add(tempBuffer);
            }
            return list;
        }
    }
}
