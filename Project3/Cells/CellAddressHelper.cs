namespace Project3.Cells;

public class CellAddressHelper
{
    private const char BaseColumnLetter = 'A';
    private const int RowOffset = 1;

    public static string GenerateCellAddress(int row, int col)
    {
        char colLetter = (char)(BaseColumnLetter + col);
        int rowNumber = row + RowOffset;
        return $"{colLetter}{rowNumber}";
    }
}