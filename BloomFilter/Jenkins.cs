using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloomFilter
{
    public class Jenkins:IHash
    {
        public uint Compute(byte[] data)
        {
            uint hash = 0;
            foreach (var b in data)
            {
                hash += b;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }
            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;
            return hash;
        }
    }
}
