namespace CommandPatternNotepad.Commands
{
    class CommandInsert:ICommand
    {
        private Notepad notepad;
        private string str;
        private int pos;
        public CommandInsert(Notepad n, string s, int p)
        {
            notepad = n;
            str = s;
            pos = p;
        }
        public void Execute()
        {
            notepad.Insert(str, pos);
            notepad.PrintText();
        }

        public void Undo()
        {
            notepad.UndoInsert(str, pos);
            notepad.PrintText();
        }

        public void Redo()
        {
            notepad.Insert(str, pos);
            notepad.PrintText();
        }
    }
}
