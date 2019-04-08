using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID
{
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}
