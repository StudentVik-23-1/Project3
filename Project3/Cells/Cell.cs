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

    public CellType Type { get; set; } = CellType.String;
    
    public CellType InitialType { get; private set; } 

    public string Formula { get; set; } 

    public void Evaluate()
    {
        if (Type == CellType.Formula && !string.IsNullOrEmpty(Formula))
        {
            try
            {
                if (MathExpressionEvaluator.TryEvaluate(Formula, out double result))
                {
                    Value = result.ToString(CultureInfo.InvariantCulture);
                }
            }
            catch
            {
                Value = "Error";
                Type = CellType.Error;
            }
        }
    }
    
    public void CaptureInitialType()
    {
        InitialType = Type;
    }

    private void UpdateCellType()
    {
        if (!string.IsNullOrEmpty(_value))
        {
            if (_value.StartsWith(FormulaPrefix))
            {
                Type = CellType.Formula;
                Formula = _value.Substring(FormulaPrefixLength);
            }
            else if (double.TryParse(_value, out _))
            {
                Type = CellType.Number;
                Formula = null;
            }
            else
            {
                Type = CellType.String;
                Formula = null;
            }
        }
        else
        {
            Type = CellType.Error;
            Formula = null;
        }
    }
}