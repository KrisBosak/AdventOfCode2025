namespace AdventOfCode2025.Services.Day1;

public static class DecryptDocumentAndFindPassword
{
    public static void FindPassword() // Probably will remove static and add DI
    {
        if (MainProgramHelpers.IsDayConfirmed(1))
        {
            Console.Clear();
            Console.WriteLine("I'm decrypted, oh no.");
            
            MainProgramHelpers.ClosingStatementOfTheOption();
        }
    }
}