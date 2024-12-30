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

        // Парсимо формулу і заміняємо клітинки на їхні значення
        public double ParseFormula(string formula)
        {
            // Видалення знаку "=" на початку формули
            if (formula.StartsWith("="))
            {
                formula = formula.Substring(1);
            }

            // Заміняємо посилання на клітинки на їхні значення
            formula = ReplaceCellReferences(formula);

            // Використовуємо MathExpressionEvaluator для обчислення
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
            // Заміняємо посилання на клітинки на їхні значення
            for (int row = 0; row < _cells.GetLength(0); row++)
            {
                for (int col = 0; col < _cells.GetLength(1); col++)
                {
                    string cellAddress = _cells[row, col].Coordinates;
                    string cellValue = _cells[row, col].Value;

                    // Якщо формула містить посилання на клітинку, заміняємо її на значення клітинки
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