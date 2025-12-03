using AdventOfCode2025.Entities;

namespace AdventOfCode2025
{
    public static class MainProgramHelpers
    {
        public static readonly  List<MainMenuOption> Options =
        [
            new MainMenuOption("Day 1", () => WriteTemporaryMessage("Day 1")),
            new MainMenuOption("Day 2", () => WriteTemporaryMessage("Day 2")),
            new MainMenuOption("Day 3", () => WriteTemporaryMessage("Day 3")),
            new MainMenuOption("Exit", () => Environment.Exit(0)),
        ];

        public static void HandleMenuNavigation()
        {
            // Menu position
            int index = 0;

            WriteMenu(Options[index]);

            ConsoleKeyInfo keyInfo;
            do
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
            while (keyInfo.Key is not ConsoleKey.X);
        }

        static void WriteMenu(MainMenuOption selectedMainMenuOption)
        {
            Console.Clear();

            foreach (MainMenuOption option in Options)
            {
                if (option == selectedMainMenuOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }

        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            WriteMenu(Options.First());
        }
    }
}
