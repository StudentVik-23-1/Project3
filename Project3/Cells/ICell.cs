namespace Project3.Cells;

public interface ICell
{
    string Coordinates { get; }
    string Value { get; set; }
    CellType Type { get; set; }
    string Formula { get; set; }
    CellType InitialType { get; } 

    void Evaluate(); 
    void CaptureInitialType(); 

}
