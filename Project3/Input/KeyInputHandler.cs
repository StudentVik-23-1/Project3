namespace Project3.Input;

//  Not working, maybe fix later. Tried to fix "if else" in TableInputHandler

public class KeyInputHandler
{
    private Dictionary<ConsoleKey, Action> _keyActions;

    public KeyInputHandler()
    {
        _keyActions = new Dictionary<ConsoleKey, Action>
        {
            { ConsoleKey.Tab, OnTabKey },
            { ConsoleKey.Enter, OnEnterKey }
        };
    }

    public string ReadCellInput()
    {
        string input = string.Empty;
        bool inputComplete = false;

        while (!inputComplete)
        {
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            if (_keyActions.ContainsKey(key.Key))
            {
                inputComplete = true;
            }
            else
            {
                input += key.KeyChar;
            }
        }

        return input;
    }

    private void OnTabKey()
    {
    }

    private void OnEnterKey()
    {
    }
}