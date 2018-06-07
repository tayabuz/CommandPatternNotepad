namespace CommandPatternNotepad
{
    interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();

    }
}
