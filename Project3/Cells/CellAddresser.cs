namespace Project3.Cells;

public class CellAddresser
{
    public static string GetCellAddress(int row, int col)
    {
        char colLetter = (char)('A' + col);
        return $"{colLetter}{row + 1}"; 
    }
}