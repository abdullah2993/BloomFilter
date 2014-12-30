using System;
using System.Collections;
using System.Linq;

namespace BloomFilter
{
    public class BloomFilter
    {
        private readonly BitArray _filter;
        private readonly IHash[] _hashers;
        private readonly int _max;

        public BloomFilter(int bits)
            : this(bits, new IHash[] {new Jenkins(), new Fnv(), new Murmur()})
        {

        }

        public BloomFilter(int bits,IHash[] hashers)
        {
            if(bits>32)
                throw new ArgumentException("Unknow bit size");
            _max = (int) (Math.Pow(2, bits))-1;
            _filter=new BitArray(_max+1,false);
            _hashers = hashers;
            
        }

        public void Add(byte[] data)
        {
            foreach (var hasher in _hashers)
            {
                _filter.Set((int) hasher.Compute(data) & _max,true);
            }
        }

        public bool Exist(byte[] data)
        {
            return _hashers.All(hasher => _filter.Get((int) hasher.Compute(data)&_max));
        }
    }
}
