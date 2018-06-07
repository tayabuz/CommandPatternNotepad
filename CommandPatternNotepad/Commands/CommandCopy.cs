namespace CommandPatternNotepad.Commands
{
    class CommandCopy:ICommand
    {
        Notepad notepad;
        private int pos1, pos2;
        public CommandCopy(Notepad n, int p1, int p2)
        {
            notepad = n;
            pos1 = p1;
            pos2 = p2;
        }
        public void Execute()
        {
            notepad.Copy(pos1, pos2);
        }

        public void Undo()
        {
            notepad.UndoCopy();
        }

        public void Redo()
        {
            notepad.Copy(pos1, pos2);
        }
    }
}
