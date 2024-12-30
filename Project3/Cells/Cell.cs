using Project3.Parser;

namespace Project3.Cells;

public class Cell : ICell
{
    public string Coordinates { get; private set; }
    private string _value;
    public string Value
    {
        get { return _value; }
        set
        {
            _value = value;
            UpdateCellType();
        }
    }    public CellType Type { get; private set; }
    public string Formula { get; set; }

    public Cell(string coordinates)
    {
        Coordinates = coordinates;
        Type = CellType.Value; // За замовчуванням клітинка містить значення
    }
    private void UpdateCellType()
    {
        if (!string.IsNullOrEmpty(_value) && _value.StartsWith("="))
        {
            Type = CellType.Formula;
            Formula = _value.Substring(1); // Зберігаємо формулу без знака "="
        }
        else
        {
            Type = CellType.Value;
            Formula = null;
        }
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
