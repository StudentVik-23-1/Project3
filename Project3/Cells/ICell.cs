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

/*
 *  void CaptureInitialType(); and CellType InitialType { get; }
 *  are only needed for method called DisplayCellDetails()
 *  this method was created for testing purposes
 *  it can be deleted and the program will be just fine
*/