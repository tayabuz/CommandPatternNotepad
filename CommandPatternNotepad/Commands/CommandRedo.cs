using System;

namespace CommandPatternNotepad.Commands
{
    class CommandRedo:ICommand
    {
        public ICommand command;

        public void Execute()
        {
            command.Redo();
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
