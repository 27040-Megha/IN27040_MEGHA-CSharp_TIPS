namespace CalculatorApp.Domain
{
    public class MathematicalExpression
    {
        public MathematicalExpression(int number1, int number2, char op)
        {
            this.Number1 = number1;
            this.Number2 = number2;
            this.Operator = op;
        }

        public int Number1 { get; set; }

        public int Number2 { get; set; }

        public char Operator { get; set; }
    }
}
