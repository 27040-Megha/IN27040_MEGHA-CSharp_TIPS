namespace AdvancedPatternMatching
{
    /// <summary>
    /// Parent Shape class that has common properties and methods
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="color">Color of shape</param>
        public Shape(string color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or Sets the value of Color of Shape
        /// </summary>
        /// <value>
        /// Color of shape
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or Sets the value of Area of Shape
        /// </summary>
        /// <value>
        /// Area of Shape
        /// </value>
        public double Area { get; set; }

        /// <summary>
        /// Calculates the Area
        /// </summary>
        /// <returns>Area</returns>
        public abstract double CalculateArea();
    }
}
