namespace Project3.Input;

using Project3.Cells;
using Project3.Parser;

public class TableInputHandler
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly ICell[,] _cells;
    private readonly FormulaParser _formulaParser;

    public TableInputHandler(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        _cells = new ICell[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                string coordinates = CellAddresser.GetCellAddress(row, col);
                _cells[row, col] = new Cell(coordinates);
            }
        }

        _formulaParser = new FormulaParser(_cells);
    }

    public void InputTable()
    {
        Console.Clear();
        Console.WriteLine($"Please input values for a table of {_rows}x{_columns}");
        Console.WriteLine($"Please keep the input length under 12 symbols!");

        int cursorX = 0;
        int cursorY = 3;

        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                Console.SetCursorPosition(cursorX, cursorY);
                
                string value = ReadCellInput();
                _cells[row, col].Value = value;
                
                if (_cells[row, col].Type == CellType.Formula)
                {
                    try
                    {
                        string formula = _cells[row, col].Formula;
                        double result = _formulaParser.ParseFormula(formula);
                        _cells[row, col].Value = result.ToString();
                    }
                    catch
                    {
                        _cells[row, col].Value = "Error";
                    }
                }

                cursorX += 12;
            }
            cursorY += 1;
            cursorX = 0;
        }
    }

    private string ReadCellInput()
    {
        string input = string.Empty;
        bool inputComplete = false;

        while (!inputComplete)
        {
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Tab || key.Key == ConsoleKey.Enter)
            {
                inputComplete = true;
            }
            else
            {
                input += key.KeyChar;
                Console.Write(key.KeyChar);
            }
        }

        return input;
    }

    public void DisplayTable()
    {
        Console.WriteLine("\nTable Output:");
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                Console.Write(_cells[row, col].Value.PadRight(12));
            }
            Console.WriteLine();
        }
        DisplayCellDetails();
    }
    
    //  Testing Method ( Unnecessary )
    public void DisplayCellDetails()
    {
        Console.WriteLine("\nCell Details:");
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _columns; col++)
            {
                ICell cell = _cells[row, col];
                Console.WriteLine($"Address: {cell.Coordinates}, Value: {cell.Value}, Type: {cell.Type}");
            }
        }
    }
}
