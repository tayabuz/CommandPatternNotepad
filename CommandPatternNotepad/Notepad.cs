using System;
using System.IO;
using System.Text;

namespace CommandPatternNotepad
{
    class Notepad
    {
        private string Text;
        private string CopyBuffer;
        private string TextBackup;

        public Notepad(string path)
        {
            Text = GetTextFromFile(path);
        }
        private string GetTextFromFile(string path)
        {
            if (File.Exists(path))
            {
                var text = File.ReadAllText(path, Encoding.Default);
                return text;
            }
            else
            {
                throw new FileNotFoundException("Invalid path: File not found");
            }
        }

        public void PrintText()
        {
            Console.WriteLine(Text);
        }

        public void UndoPaste(int pos)
        {
            Text = Text.Remove(pos, CopyBuffer.Length);
        }

        public void UndoCopy()
        {
            CopyBuffer = "";
        }

        public void Copy(int pos1, int pos2)
        {
            var result = Text.Substring(pos1, pos2);
            CopyBuffer = result;
        }       
            
        public void Delete(int pos1, int pos2)
        {
            TextBackup = Text;
            Text = Text.Remove(pos1, pos2);
        }

        public void UndoDelete()
        {
            Text = TextBackup;
        }

        public void Insert(string s, int pos)
        {
            Text = Text.Insert(pos, s);
        }

        public void UndoInsert(string s, int pos)
        {
            Text = Text.Remove(pos, s.Length);
        }

        public void Paste(int pos)
        {
            Text = Text.Insert(pos, CopyBuffer);
        }
    }
}
