using System.Collections.Generic;
using CommandPatternNotepad.Commands;

namespace CommandPatternNotepad
{
    class NotepadManager
    {
        private List<ICommand> HistoryOfCommands = new List<ICommand>();
        private ICommand command;
        private int IndexOfHistory;
        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
            if (IndexOfHistory < HistoryOfCommands.Count)
            {
                for(int i = IndexOfHistory + 1; i < HistoryOfCommands.Count; i++)
                {
                    HistoryOfCommands.Remove(HistoryOfCommands[i]);
                }
            }
            HistoryOfCommands.Add(command);
            IndexOfHistory = HistoryOfCommands.Count;
        }
        public void PressUndo()
        {
            if (IndexOfHistory > 0)
            {
                IndexOfHistory--;
                ICommand undoCommand = HistoryOfCommands[IndexOfHistory];
                undoCommand.Undo();
                HistoryOfCommands.Add(undoCommand);
            }
        }

        public void PressRedo()
        {
            if (HistoryOfCommands.Count > 0 && IndexOfHistory != HistoryOfCommands.Count)
            {
                IndexOfHistory++;
                ICommand redoCommand = HistoryOfCommands[IndexOfHistory];
                redoCommand.Redo();
                HistoryOfCommands.Add(redoCommand);
            }
        }

        public void CommandsExecute(List<ICommand> commands)
        {
            foreach (var com in commands)
            {
                if (com is CommandRedo || com is CommandUndo)
                {
                    if(com is CommandRedo) { PressRedo(); }
                    else { PressUndo(); }
                }
                else
                {
                    SetCommand(com);
                    PressButton();
                }
            }
        }
    }
}
