using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloomFilter
{
    public class Murmur:IHash
    {
        public uint Compute(byte[] data)
        {
            const uint c1 = 0xcc9e2d51;
            const uint c2 = 0x1b873593;
            const int r1 = 15;
            const int r2 = 13;
            const uint m = 5;
            const uint n = 0xe6546b64;
            const uint seed = 0xefa0110b;
            var hash = seed;
            var remaining = (uint)data.Length%4;
            for (var i = 0; i < data.Length-remaining; i+=4)
            {
                var k = BitConverter.ToUInt32(data, i);
                k *= c1;
                k = (k << r1) | (k >> (32 - r1));
                k *= c2;

                hash ^= k;
                hash = (hash << r2) | (hash >> (32 - r2));
                hash = hash*m + n;
            }
            if (remaining > 0)
            {
                switch (remaining)
                {
                    case 1:
                        remaining =(data[data.Length - 1 - remaining] & 0xffffffff);
                        break;
                    case 2:
                        remaining = (uint) (data[data.Length - 1 - remaining] | ((data[data.Length - 2 - remaining] << 8)) & 0xffffffff);
                        break;
                    case 3:
                        remaining =  (uint) (data[data.Length - 1 - remaining] | ((data[data.Length - 2 - remaining] << 8)) | ((data[data.Length - 3 - remaining] << 16)) & 0xffffffff);
                        break;
                }
                remaining *= c1;
                remaining = (remaining << r1) | (remaining >> 32 - r1);
                remaining *= c2;
                hash ^= remaining;
            }

            hash ^= (uint)data.Length;
            hash ^= (hash >> 16);
            hash *= 0x85ebca6b;
            hash ^= (hash >> 13);
            hash *= 0xc2b2ae35;
            hash ^= (hash >> 16);
            return hash;
        }
    }
}
