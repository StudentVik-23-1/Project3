using Project3.Cells;

namespace Project3.Parser
{
    public class FormulaParser
    {
        private readonly ICell[,] _cells;

        public FormulaParser(ICell[,] tableCells)
        {
            _cells = tableCells;
        }

        public double ParseFormula(string formula)
        {
            if (formula.StartsWith("="))
            {
                formula = formula.Substring(1);
            }

            formula = ReplaceCellReferences(formula);

            if (MathExpressionEvaluator.TryEvaluate(formula, out double result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException($"Error parsing formula: {formula}");
            }
        }

        private string ReplaceCellReferences(string formula)
        {
            for (int row = 0; row < _cells.GetLength(0); row++)
            {
                for (int col = 0; col < _cells.GetLength(1); col++)
                {
                    string cellAddress = _cells[row, col].Coordinates;
                    string cellValue = _cells[row, col].Value;

                    if (formula.Contains(cellAddress))
                    {
                        formula = formula.Replace(cellAddress, cellValue);
                    }
                }
            }

            return formula;
        }
    }
}