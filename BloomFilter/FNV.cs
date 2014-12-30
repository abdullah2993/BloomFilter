using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Math;

namespace BloomFilter
{
    public class Fnv:IHash
    {
        public uint Compute(byte[] data)
        {
            const uint fnvPrime = 16777619;
            var hash = 2166136261;
            foreach (var b in data)
            {
                hash *= fnvPrime;
                hash ^= b;
            }
            return hash;
        }
    }
}
