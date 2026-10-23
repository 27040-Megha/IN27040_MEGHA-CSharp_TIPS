namespace SecurityInterface
{
    /// <summary>
    /// Defines a Security contract for implementing classes
    /// </summary>
    public interface ISecurity
    {
        /// <summary>
        /// Gets or sets the value of name of Encryption Algorithm
        /// </summary>
        /// <value>
        /// The value of name of Encryption Algorithm
        /// </value>
        public string AlgorithmName { get; set; }

        /// <summary>
        /// Encrypts the given message
        /// </summary>
        /// <param name="text">Message to be encrypted</param>
        /// <returns>Encrypted Message</returns>
        public string Encrypt(string text);

        /// <summary>
        /// Decrypts the given encrypted message
        /// </summary>
        /// <param name="text">Message to be decrypted</param>
        /// <returns>Original Message</returns>
        public string Decrypt(string text);
    }
}