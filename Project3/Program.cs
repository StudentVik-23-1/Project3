﻿using System;
using Project3.Input;
using Project3.Validators;

class Program
{
    static void Main(string[] args)
    {
        TableSizeValidator sizeValidator = new TableSizeValidator();
        
        ushort rows = sizeValidator.GetValidRowInput();
        ushort columns = sizeValidator.GetValidColumnInput();
        
        TableInputHandler inputHandler = new TableInputHandler(rows, columns);

        inputHandler.InputTable();

        inputHandler.DisplayTable();    
    }
}