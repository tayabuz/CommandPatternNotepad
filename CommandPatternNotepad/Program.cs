using System;

namespace CommandPatternNotepad
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               Console.WriteLine("Enter path of TextFile");
                var path = Console.ReadLine();
                Console.WriteLine("Enter path of CommandList");
                var path1 = Console.ReadLine();
                Notepad n = new Notepad(path);
                NotepadManager nm = new NotepadManager();
                nm.CommandsExecute(ParsingCommands.ParseCommands(path1, n));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
