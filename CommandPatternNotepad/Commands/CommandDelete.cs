namespace CommandPatternNotepad.Commands
{
    class CommandDelete:ICommand
    {
        private Notepad notepad;
        private int pos1, pos2;
        public CommandDelete(Notepad n, int p1, int p2)
        {
            notepad = n;
            pos1 = p1;
            pos2 = p2;
        }
        public void Execute()
        {
            notepad.Delete(pos1, pos2);
            notepad.PrintText();
        }

        public void Undo()
        {
            notepad.UndoDelete();
            notepad.PrintText();
        }

        public void Redo()
        {
            notepad.Delete(pos1, pos2);
            notepad.PrintText();
        }
    }
}
