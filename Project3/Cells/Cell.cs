using System.Globalization;
using Project3.Parser;

namespace Project3.Cells;

public sealed class Cell(string coordinates) : ICell
{
    private const string FORMULA_PREFIX = "=";
    private const int FORMULA_PREFIX_LENGTH = 1;

    private string _value;

    public string Coordinates { get; private set; } = coordinates;

    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            UpdateCellType();
        }
    }

    public CellType Type { get; private set; } = CellType.Value;

    public string Formula { get; set; }     // TODO look into making { get; private set; }

    public void Evaluate()
    {
        if (MathExpressionEvaluator.TryEvaluate(Value, out double result))
        {
            Value = result.ToString(CultureInfo.InvariantCulture);
            Type = CellType.Value;
        }
    }

    private void UpdateCellType()
    {
        if (!string.IsNullOrEmpty(_value) && _value.StartsWith(FORMULA_PREFIX))
        {
            Type = CellType.Formula;
            Formula = _value[FORMULA_PREFIX_LENGTH..];
        }
        else
        {
            Type = CellType.Value;
            Formula = null;
        }
    }
}