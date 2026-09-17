namespace AdvancedPatternMatching
{
    /// <summary>
    /// Subclass inherits from Shape
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="baseValue">Base of Triangle</param>
        /// <param name="height">Height of Triangle</param>
        /// <param name="color">Color of triangle</param>
        public Triangle(double baseValue, double height, string color)
            : base(color)
        {
            this.Base = baseValue;
            this.Height = height;
        }

        /// <summary>
        /// Gets or Sets the value of Base of Triangle
        /// </summary>
        /// <value>
        /// Base of Triangle
        /// </value>
        public double Base { get; set; }

        /// <summary>
        /// Gets or Sets the value of Height of Triangle
        /// </summary>
        /// <value>
        /// Height of Triangle
        /// </value>
        public double Height { get; set; }

        /// <summary>
        /// Calculates the Area
        /// </summary>
        /// <returns>Area</returns>
        public override double CalculateArea()
        {
            this.Area = 0.5 * this.Base * this.Height;
            return this.Area;
        }
    }
}
