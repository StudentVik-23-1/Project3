using System.Globalization;
using Project3.Parser;

namespace Project3.Cells;

public sealed class Cell(string coordinates) : ICell
{
    private const string FormulaPrefix = "=";
    private const int FormulaPrefixLength = 1;

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

    public string Formula { get; set; } 

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
        if (!string.IsNullOrEmpty(_value) && _value.StartsWith(FormulaPrefix))
        {
            Type = CellType.Formula;
            Formula = _value[FormulaPrefixLength..];
        }
        else
        {
            Type = CellType.Value;
            Formula = null;
        }
    }
}