namespace Login.Encryption.Domain
{
    public interface IState
    {
        int Seed { get; }

        int MajorVersion { get; }

        int MinorVersion { get; }

        int Patch { get; }

        uint FirstClientKey { get; set; }

        uint SecondClientKey { get; set; }

        uint FirstCurrentKey { get; set; }

        uint SecondCurrentKey { get; set; }

        bool Encrypted { get; set; }

        public void Initialize()
        {
            FirstClientKey = GetFirstClientKey((uint)MajorVersion, (uint)MinorVersion, (uint)Patch);

            SecondClientKey = GetSecondClientKey((uint)MajorVersion, (uint)MinorVersion, (uint)Patch);

            var seed = (uint)Seed;

            FirstCurrentKey = ((~seed ^ 0x00001357) << 16) | ((seed ^ 0xffffaaaa) & 0x0000ffff);

            SecondCurrentKey = ((seed ^ 0x43210000) >> 16) | ((~seed ^ 0xabcdffff) & 0xffff0000);

            Encrypted = true;
        }

        internal void Decrypt(byte[] buffer, int offset, int length)
        {
            for (var i = offset; i < length; i++)
            {
                buffer[i] = (byte)(FirstCurrentKey ^ buffer[i]);

                var oldKey0 = FirstCurrentKey;
                var oldKey1 = SecondCurrentKey;

                FirstCurrentKey = ((oldKey0 >> 1) | (oldKey1 << 31)) ^ SecondClientKey;
                SecondCurrentKey = (((((oldKey1 >> 1) | (oldKey0 << 31)) ^ FirstClientKey) >> 1) | (oldKey0 << 31)) ^ FirstClientKey;
            }
        }

        private static uint GetFirstClientKey(uint ver1, uint ver2, uint ver3)
        {
            var num1 = ver3;
            var num2 = ver1;
            var num3 = ver2;
            var num4 = num1;

            num4 *= num1;
            num2 <<= 9;
            num2 |= num3;
            num2 <<= 10;
            num2 |= num1;
            num4 <<= 5;
            num2 ^= num4;
            num4 = num3;
            num4 *= num3;
            num2 <<= 4;
            num2 ^= num4;
            num4 = num3 + num3 * 4;
            num3 += num4 * 2;
            num3 <<= 0x18;
            num2 ^= num3;
            num3 = num1 * 8;
            num3 -= num1;
            num3 <<= 0x13;
            num2 ^= num3;

            return num2 ^ 0x2c13a5fd;
        }

        private static uint GetSecondClientKey(uint ver1, uint ver2, uint ver3)
        {
            var num1 = ver3;
            var num3 = ver2;
            var num2 = num1;
            var num4 = ver1;

            num2 *= num1;
            num4 <<= 9;
            num4 |= num1;
            num2 += num2 * 2;
            num4 <<= 10;
            num4 |= num3;
            num4 <<= 3;
            num2 <<= 10;
            num4 ^= num2;
            num2 = num3;
            num2 *= num3;
            num4 ^= num2;
            num2 = num3 + num3 * 2;
            num3 += num2 * 4;
            num2 = num1 * 8;
            num3 <<= 0x17;
            num2 -= num1;
            num4 ^= num3;
            num2 <<= 0x12;
            num4 ^= num2;

            return num4 ^ 0xa31d527f;
        }
    }
}
