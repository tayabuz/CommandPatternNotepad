using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using CommandPatternNotepad.Commands;


namespace CommandPatternNotepad
{
    class ParsingCommands
    {
        public static List<ICommand> ParseCommands(string path, Notepad n)
        {
            List<ICommand> result = new List<ICommand>();
            if (File.Exists(path))
            {
                string[] CommandsArray = File.ReadAllLines(path, Encoding.Default);
                foreach (var command in CommandsArray)
                {
                    string par1 = "", par2 = "";
                    string com = command.Split(' ')[0];
                    try
                    {
                        par1 = command.Split(' ')[1];
                        par1 = par1.Replace(",", "");
                        par1 = par1.Trim('\"');
                        par2 = command.Split(' ')[2];
                        result.Add(GetCommand(com, par1, par2, n));
                    }
                    catch (IndexOutOfRangeException)
                    {
                        result.Add(GetCommand(com, par1, par2, n));
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Invalid path: File not found");
            }
            return result;
        }
       
        private static ICommand GetCommand(string com, string par1, string par2, Notepad n)
        {
            switch (com)
            {
                case "copy":
                    return new CommandCopy(n, Convert.ToInt32(par1), Convert.ToInt32(par2));
                    break;
                case "delete":
                    return new CommandDelete(n, Convert.ToInt32(par1), Convert.ToInt32(par2));
                    break;
                case "insert":
                    return new CommandInsert(n, par1, Convert.ToInt32(par2));
                    break;
                case "paste":
                    return new CommandPaste(n, Convert.ToInt32(par1));
                    break;
                case "undo":
                    return new CommandUndo();
                    break;
                case "redo":
                    return  new CommandRedo();
                    break;
            }
            return new NoCommand();
        }
    }
}
