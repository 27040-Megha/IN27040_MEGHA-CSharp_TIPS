namespace AdvancedPatternMatching
{
    /// <summary>
    /// Subclass inherits from Shape
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="length">Length of rectangle</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="color">Color of Rectangle</param>
        public Rectangle(double length, double width, string color)
            : base(color)
        {
            this.Length = length;
            this.Width = width;
        }

        /// <summary>
        /// Gets or Sets the value of Length of Rectangle
        /// </summary>
        /// <value>
        /// Length of rectangle
        /// </value>
        public double Length { get; set; }

        /// <summary>
        /// Gets or Sets the value of Width of Rectangle
        /// </summary>
        /// <value>
        /// Width of rectangle
        /// </value>
        public double Width { get; set; }

        /// <summary>
        /// Calculates the Area
        /// </summary>
        /// <returns>Area</returns>
        public override double CalculateArea()
        {
            this.Area = this.Length * this.Width;
            return this.Area;
        }
    }
}
