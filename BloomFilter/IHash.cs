using Org.BouncyCastle.Math;

namespace BloomFilter
{
    public interface IHash
    {
        uint Compute(byte[] data);
    }
}
