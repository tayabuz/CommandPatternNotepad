namespace CommandPatternNotepad.Commands
{
    class CommandPaste:ICommand
    {
        private Notepad notepad;
        private int pos;
        public CommandPaste(Notepad n, int p)
        {
            notepad = n;
            pos = p;
        }
        public void Execute()
        {
            notepad.Paste(pos);
            notepad.PrintText();
        }

        public void Undo()
        {
            notepad.UndoPaste(pos);
            notepad.PrintText();
        }

        public void Redo()
        {
            notepad.Paste(pos);
            notepad.PrintText();
        }
    }
}
