using AdventOfCode2025.Entities;
using AdventOfCode2025.Services.Day1;

namespace AdventOfCode2025;

public static class MainProgramHelpers
{
    private static bool _keepAppOpen = true;
    private static readonly List<MainMenuOption> Options =
    [
        new MainMenuOption("Day 1", () => DecryptDocumentAndFindPassword.FindPassword()),
        new MainMenuOption("Exit", () => _keepAppOpen = false),
    ];

    public static void HandleMenuNavigation()
    {
        // Menu position
        int index = 0;

        WriteMenu(Options[index]);

        ConsoleKeyInfo keyInfo;
        while (_keepAppOpen)
        {
            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                {
                    if (index + 1 < Options.Count)
                    {
                        index++;
                        WriteMenu(Options[index]);
                    }

                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(Options[index]);
                    }

                    break;
                }
                case ConsoleKey.Enter:
                    Options[index].Selected.Invoke();
                    index = 0;
                    break;
            }
        }

        if (_keepAppOpen == false)
        {
            Environment.Exit(0);
        }
    }

    static void WriteMenu(MainMenuOption selectedMainMenuOption)
    {
        Console.Clear();

        foreach (MainMenuOption option in Options)
        {
            Console.Write(option == selectedMainMenuOption ? "> " : " "); // I should probably put this into a const variable

            Console.WriteLine(option.Name);
        }
    }

    public static bool IsDayConfirmed(int day)
    {
        Console.Clear();
        
        Console.WriteLine($"Are you sure you want to continue with this day {day}? \r\n");
        Console.WriteLine($"y / n: ");
        
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
            case ConsoleKey.Y:
                return true;
            default:
                WriteMenu(Options.First());
                return false;
        }
    }
    
    public static void ClosingStatementOfTheOption()
    {
        Console.WriteLine("\r\nPress ENTER to finish the day... and go back to the menu.");
        if (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            WriteMenu(Options.First());
        }
    }
}
