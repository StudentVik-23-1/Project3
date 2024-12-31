namespace Project3.Validators;

public class TableSizeValidator
{
    public ushort GetValidRowInput()
    {
        return GetValidInput("Enter number of rows: ");
    }

    public ushort GetValidColumnInput()
    {
        return GetValidInput("Enter number of columns: ");
    }

    private ushort GetValidInput(string prompt)
    {
        ushort result = 0;
        bool isValid = false;

        while (!isValid)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (ushort.TryParse(input, out result))
            {
                if (result > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter a positive value greater than 0.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
            }
        }

        return result;
    }
}