using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID
{
    // just stores a couple of journal entries and ways of
    // working with them
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        #region Breaks Single Responsibility Princinple
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllLines(filename, entries);
        }

        public void Load(string filename)
        {
            throw new NotImplementedException();
        }

        public void Load(Uri uri)
        {
            throw new NotImplementedException();
        }
        #endregion breaks single responsibility principle
    }
}
