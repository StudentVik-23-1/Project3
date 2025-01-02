namespace Project3.Cells;

public class CellAddressHelper
{
    private const char BASE_COLUMN_LETTER = 'A';
    private const int ROW_OFFSET = 1;

    public static string GenerateCellAddress(int row, int col)
    {
        char colLetter = (char)(BASE_COLUMN_LETTER + col);
        int rowNumber = row + ROW_OFFSET;
        return $"{colLetter}{rowNumber}";
    }
}