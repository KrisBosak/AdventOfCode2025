using AdventOfCode2025.Entities;

namespace AdventOfCode2025
{
    public static class MainProgramHelpers
    {
        public static readonly  List<Option> _options =
        [
            new Option("Day 1", () => WriteTemporaryMessage("Day 1")),
            new Option("Day 2", () => WriteTemporaryMessage("Day 2")),
            new Option("Day 3", () => WriteTemporaryMessage("Day 3")),
            new Option("Exit", () => Environment.Exit(0)),
        ];

        public static void HandleMenuNavigation()
        {
            // Menu position
            int index = 0;

            WriteMenu(_options[index]);

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                    {
                        if (index + 1 < _options.Count)
                        {
                            index++;
                            WriteMenu(_options[index]);
                        }

                        break;
                    }
                    case ConsoleKey.UpArrow:
                    {
                        if (index - 1 >= 0)
                        {
                            index--;
                            WriteMenu(_options[index]);
                        }

                        break;
                    }
                    case ConsoleKey.Enter:
                        _options[index].Selected.Invoke();
                        index = 0;
                        break;
                }
            }
            while (keyInfo.Key is not ConsoleKey.X);
        }

        static void WriteMenu(Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in _options)
            {
                if (option == selectedOption)
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
            WriteMenu(_options!.First());
        }
    }
}
