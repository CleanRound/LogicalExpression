internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter a logical expression (for instance: 3>2 or 7<3): ");
            string input = Console.ReadLine();

            bool result = EvaluateExpression(input);
            Console.WriteLine($"Result: {result}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static bool EvaluateExpression(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
        {
            throw new ArgumentException("Expression cannot be null or empty.");
        }

        string[] parts = expression.Split(new char[] { '<', '>', '=', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid expression format.");
        }

        if (!int.TryParse(parts[0], out int operand1))
        {
            throw new ArgumentException("Invalid operand: " + parts[0]);
        }

        if (!int.TryParse(parts[1], out int operand2))
        {
            throw new ArgumentException("Invalid operand: " + parts[1]);
        }

        char op = expression[parts[0].Length];

        switch (op)
        {
            case '<':
                return operand1 < operand2;
            case '>':
                return operand1 > operand2;
            case '=':
                return operand1 == operand2;
            case '!':
                return operand1 != operand2;
            default:
                throw new ArgumentException("Invalid operator: " + op);
        }
    }
}