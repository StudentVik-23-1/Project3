using System.Globalization;

namespace Project3.Input;

using Project3.Cells;
using Project3.Parser;

public sealed class TableInputHandler
{
    private const int CellDisplayWidth = 12;

    private const int TableStartCursorY = 3;

    private const string TableInputPrompt = "Please input values for a table of {0}x{1}";

    private const string InputLengthWarning = "Please keep the input length under 12 symbols!";

    private const string TableOutputHeading = "Table Output:";

    private const string CellDetailsHeading = "Cell Details:";

    private const string ErrorValue = "Error";

    private readonly int _rows;
    private readonly int _columns;
    private readonly ICell[,] _cells;
    private readonly FormulaParser _formulaParser;

    public TableInputHandler(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        _cells = new ICell[_rows, _columns];

        InitializeCells();
        _formulaParser = new FormulaParser(_cells);
    }

    private void InitializeCells()
    {
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                string coordinates = CellAddressHelper.GenerateCellAddress(row, col);
                _cells[row, col] = new Cell(coordinates);
            }
        }
    }

    public void InputTable()
    {
        Console.Clear();
        Console.WriteLine(TableInputPrompt, _rows, _columns);
        Console.WriteLine(InputLengthWarning);

        int cursorX = 0;
        int cursorY = TableStartCursorY;

        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                Console.SetCursorPosition(cursorX, cursorY);
                string userValue = ReadCellInput();
                _cells[row, col].Value = userValue;

                EvaluateCellFormula(row, col);

                cursorX += CellDisplayWidth;
            }

            cursorY++;
            cursorX = 0;
        }
    }

    private void EvaluateCellFormula(int row, int col)
    {
        ICell cell = _cells[row, col];

        if (cell.Type == CellType.Formula)
        {
            try
            {
                string formula = cell.Formula;
                double result = _formulaParser.ParseFormula(formula);
                cell.Value = result.ToString(CultureInfo.InvariantCulture);
            }
            catch
            {
                cell.Value = ErrorValue;
            }
        }
    }

    private static string ReadCellInput()
    {
        string input = string.Empty;
        bool inputComplete = false;

        while (!inputComplete)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key is ConsoleKey.Tab or ConsoleKey.Enter)
            {
                inputComplete = true;
            }
            else
            {
                input += keyInfo.KeyChar;
                Console.Write(keyInfo.KeyChar);
            }
        }

        return input;
    }

    public void DisplayTable()
    {
        Console.WriteLine();
        Console.WriteLine(TableOutputHeading);

        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                string cellValue = _cells[row, col].Value;
                Console.Write(cellValue.PadRight(CellDisplayWidth));
            }
            Console.WriteLine();
        }

        DisplayCellDetails();
    }

    private void DisplayCellDetails()
    {
        Console.WriteLine();
        Console.WriteLine(CellDetailsHeading);

        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                ICell cell = _cells[row, col];
                Console.WriteLine(
                    $"Address: {cell.Coordinates}, Value: {cell.Value}, Type: {cell.Type}");
            }
        }
    }
}