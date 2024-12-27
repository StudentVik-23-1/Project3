namespace Project3.Cells;

public interface ICell
{
    string Coordinates { get; }
    string Value { get; set; }
    CellType Type { get; }
    string Formula { get; set; }
    void Evaluate(); 
}

public enum CellType
{
    Value,   
    Formula, 
    Error    
}
