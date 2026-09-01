namespace CalculatorApp.PresentationLayer.Helper
{
    public static class InputValidation
    {
        public static bool ValidateInteger(string input, out int validNumber)
        {
            if (int.TryParse(input, out int number))
            {
                validNumber = number;
                return true;
            }

            validNumber = -1;
            return false;
        }
    }
}
