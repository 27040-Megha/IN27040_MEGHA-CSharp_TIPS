namespace AdvancedPatternMatching
{
    /// <summary>
    /// Shape Class that is not a subclass of Shape
    /// </summary>
    public class Hexagon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hexagon"/> class.
        /// </summary>
        /// <param name="color">Color of the Shape</param>
        public Hexagon(string color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or Sets the value of color
        /// </summary>
        /// <value>
        /// Color
        /// </value>
        public string Color { get; set; }
    }
}
