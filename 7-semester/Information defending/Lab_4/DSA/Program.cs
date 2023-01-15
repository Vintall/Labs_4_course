using System;
using System.Numerics;
using System.Security.Cryptography;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Generate a random private key
            int keySize = 1024;


            BigInteger privateKey = GenerateRandomBigInteger(keySize);

            if (privateKey < 0)
                privateKey *= -1;

            // Generate the corresponding public key
            BigInteger p = GenerateRandomPrime(keySize);
            BigInteger q = GenerateRandomPrime(keySize);
            BigInteger g = GenerateRandomBigInteger(keySize);

            if (g < 0)
                g *= -1;

            BigInteger publicKey = BigInteger.ModPow(g, privateKey, p * q);

            // Get a message to sign
            Console.Write("Enter a message to sign: ");
            string message = Console.ReadLine();
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
            BigInteger hash = Hash(messageBytes);

            // Sign the message
            BigInteger k = GenerateRandomBigInteger(keySize);

            if (k < 0)
                k *= -1;

            BigInteger r = BigInteger.ModPow(g, k, p) % q;
            BigInteger s = (ModInverse(k,q) * (hash + privateKey * r)) % q;
            byte[] signature = ToByteArray(r, s);

            // Verify the signature
            BigInteger w = ModInverse(s,q);
            BigInteger u1 = (hash * w) % q;
            BigInteger u2 = (r * w) % q;
            BigInteger v = ((BigInteger.ModPow(g, u1, p * q) * BigInteger.ModPow(publicKey, u2, p * q)) % (p * q)) % q;
            bool verified = v == r;

            // Print the results
            Console.WriteLine($"Signature verified: {verified}");

            Console.Read();
        }
        // Generate a random big integer
        static BigInteger GenerateRandomBigInteger(int bitLength)
        {
            byte[] bytes = new byte[bitLength / 8];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return new BigInteger(bytes);
        }

        // Generate a random prime number
        static BigInteger GenerateRandomPrime(int bitLength)
        {
            BigInteger prime;
            do
            {
                prime = GenerateRandomBigInteger(bitLength);
            }
            while (!IsProbablePrime(prime, 5));
            return prime;
        }

        // Test if a big integer is a probable prime
        static bool IsProbablePrime(BigInteger value, int witnesses)
        {
            if (value <= 1)
                return false;
            if (witnesses < 0)
                witnesses = 0;
            BigInteger d = value - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                s++;
                d /= 2;
            }
            byte[] bytes = new byte[value.ToByteArray().LongLength];
            BigInteger a;
            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    RandomNumberGenerator.Create().GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);
                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1)
                    continue;
                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);
                    if (x == 1)
                        return false;
                    if (x == value - 1)
                        break;
                }
                if (x != value - 1)
                    return false;
            }
            return true;
        }

        // Hash a byte array
        static BigInteger Hash(byte[] bytes)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(bytes);
                return new BigInteger(hash);
            }
        }

        // Convert a pair of big integers to a byte array
        static byte[] ToByteArray(BigInteger r, BigInteger s)
        {
            byte[] rBytes = r.ToByteArray();
            byte[] sBytes = s.ToByteArray();
            byte[] bytes = new byte[rBytes.Length + sBytes.Length];
            Array.Copy(rBytes, 0, bytes, 0, rBytes.Length);
            Array.Copy(sBytes, 0, bytes, rBytes.Length, sBytes.Length);
            return bytes;
        }

        public static BigInteger ModInverse(BigInteger value, BigInteger modulo)
        {
            BigInteger x, y;

            if (1 != Egcd(value, modulo, out x, out y))
                throw new ArgumentException("Invalid modulo", nameof(modulo));

            if (x < 0)
                x += modulo;

            return x % modulo;
        }
        public static BigInteger Egcd(BigInteger left,
                              BigInteger right,
                          out BigInteger leftFactor,
                          out BigInteger rightFactor)
        {
            leftFactor = 0;
            rightFactor = 1;
            BigInteger u = 1;
            BigInteger v = 0;
            BigInteger gcd = 0;

            while (left != 0)
            {
                BigInteger q = right / left;
                BigInteger r = right % left;

                BigInteger m = leftFactor - u * q;
                BigInteger n = rightFactor - v * q;

                right = left;
                left = r;
                leftFactor = u;
                rightFactor = v;
                u = m;
                v = n;

                gcd = right;
            }

            return gcd;
        }
    }
}
