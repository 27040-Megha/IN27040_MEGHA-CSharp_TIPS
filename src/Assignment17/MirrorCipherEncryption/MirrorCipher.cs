using System.Text;
using SecurityInterface;

namespace MirrorCipherEncryption
{
    /// <summary>
    /// Implements the security interface and provides definition for Encryption and Decryption 
    /// </summary>
    public class MirrorCipher : ISecurity
    {
        /// <summary>
        /// Gets or sets the value of name of Encryption Algorithm
        /// </summary>
        /// <value>
        /// The value of name of Encryption Algorithm
        /// </value>
        public string AlgorithmName { get; set; } = "Mirror Cipher Encryption";

        /// <summary>
        /// Encrypts the given message using Mirror Cipher Encryption
        /// </summary>
        /// <param name="text">Message to be encrypted</param>
        /// <returns>Encrypted Message</returns>
        public string Encrypt(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in text)
            {
                if (char.IsUpper(ch))
                {
                    char mirroredValue = (char)('Z' - (ch - 'A'));
                    sb.Append(mirroredValue);
                }
                else if (char.IsLower(ch))
                {
                    char mirroredValue = (char)('z' - (ch - 'a'));
                    sb.Append(mirroredValue);
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Decrypts the given encrypted message using Mirror Cipher Encryption
        /// </summary>
        /// <param name="text">Message to be decrypted</param>
        /// <returns>Original Message</returns>
        public string Decrypt(string text)
        {
            return this.Encrypt(text);
        }
    }
}
