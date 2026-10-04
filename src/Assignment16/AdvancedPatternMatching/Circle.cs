namespace AdvancedPatternMatching
{
    /// <summary>
    /// Subclass inherits from Shape
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Radius Of Circle</param>
        /// <param name="color">Color Of Circle</param>
        public Circle(double radius, string color)
            : base(color)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or Sets the value of Radius of Circle
        /// </summary>
        /// <value>
        /// Radius
        /// </value>
        public double Radius { get; set; }

        /// <summary>
        /// Calculates the Area
        /// </summary>
        /// <returns>Area</returns>
        public override double CalculateArea()
        {
            this.Area = 3.14 * this.Radius;
            return this.Area;
        }
    }
}
