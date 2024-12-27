using System.Data;

namespace Project3.Parser;


public static class MathExpressionEvaluator
{
    public static bool TryEvaluate(string input, out double result)
    {
        try
        {
            DataTable table = new DataTable();
            table.CaseSensitive = false;

            object evaluationResult = table.Compute(input, string.Empty);

            if (evaluationResult is double || evaluationResult is int)
            {
                result = Convert.ToDouble(evaluationResult);
                return true;
            }
        }
        catch
        {
            
        }

        result = 0;
        return false;
    }
}
