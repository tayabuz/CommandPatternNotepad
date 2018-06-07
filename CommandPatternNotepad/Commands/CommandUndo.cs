using System;

namespace CommandPatternNotepad.Commands
{
    class CommandUndo:ICommand
    {
        public ICommand command;

        public void Execute()
        {
            command.Undo();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }
    }
}
