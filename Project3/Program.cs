using System;
using Project3.Input;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter number of columns: ");
        int columns = int.Parse(Console.ReadLine());

        TableInputHandler inputHandler = new TableInputHandler(rows, columns);

        inputHandler.InputTable();

        inputHandler.DisplayTable();    
    }
}