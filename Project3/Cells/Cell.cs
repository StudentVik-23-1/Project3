using Project3.Parser;

namespace Project3.Cells;

public class Cell : ICell
{
    public string Coordinates { get; private set; }
    public string Value { get; set; }
    public CellType Type { get; private set; }
    public string Formula { get; set; }

    public Cell(string coordinates)
    {
        Coordinates = coordinates;
        Type = CellType.Value; // За замовчуванням клітинка містить значення
    }

    public void Evaluate()
    {
        // if (Type == CellType.Formula)
        // {
            if (MathExpressionEvaluator.TryEvaluate(Value, out double result))
            {
                Value = result.ToString();
                Type = CellType.Value; 
            }
        // }
    }
}
