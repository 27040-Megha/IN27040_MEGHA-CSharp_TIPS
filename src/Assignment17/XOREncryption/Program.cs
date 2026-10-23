using System.Text;

namespace XOREncryption
{
    public class XOREncryptionAlgorithm
    {
        private char _xorKey = 'B';

        public string AlgorithmName { get; set; } = "XOR Encryption Algoritm";

        public string Encrypt(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in text)
            {
                int xorValue = ch ^ _xorKey;
                sb.Append((char)xorValue);
            }

            return sb.ToString();
        }

        public string Decrypt(string text)
        {
            return Encrypt(text);
        }
    }
}
