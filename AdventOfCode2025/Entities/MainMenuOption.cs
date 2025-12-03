namespace AdventOfCode2025.Entities
{
    public class MainMenuOption(string name, Action selected)
    {
        public string Name { get; } = name;
        public Action Selected { get; } = selected;
    }
}
