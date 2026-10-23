namespace SerializationAPI
{
    /// <summary>
    /// Class definition for a Printing machine
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// On or Off status of the machine
        /// </summary>
        private bool _isOn = true;

        /// <summary>
        /// Gets or sets the value of name of the printing machine
        /// </summary>
        /// <value>
        /// Name of the Printing machine
        /// </value>
        public string MachineName { get; set; } = "HP LaserJet Printer";
    }
}
