using System.Text;
using SecurityInterface;

namespace CaeserCipher
{
    /// <summary>
    /// Implements the security interface and provides definition for Encryption and Decryption 
    /// </summary>
    public class CaeserCipherEncryption : ISecurity
    {
        private int _cipherKey = 3;

        /// <summary>
        /// Gets or sets the value of name of Encryption Algorithm
        /// </summary>
        /// <value>
        /// The value of name of Encryption Algorithm
        /// </value>
        public string AlgorithmName { get; set; } = "Caeser Cipher Encryption";

        /// <summary>
        /// Encrypts the given message using Caeser Cipher Encryption
        /// </summary>
        /// <param name="text">Message to be encrypted</param>
        /// <returns>Encrypted Message</returns>
        public string Encrypt(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in text)
            {
                int shiftedValue = ch + this._cipherKey;
                sb.Append((char)shiftedValue);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Decrypts the given encrypted message using Caeser Cipher Encryption
        /// </summary>
        /// <param name="text">Message to be decrypted</param>
        /// <returns>Original Message</returns>
        public string Decrypt(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in text)
            {
                int shiftedValue = ch - this._cipherKey;
                sb.Append((char)shiftedValue);
            }

            return sb.ToString();
        }
    }
}
