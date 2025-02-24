using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RogueLike
{
    internal class Save
    {
        public string filePath;
        public string fileName;

        public void LogSave(string LogText)
        {
            filePath = "...source/repos/RogueLike/battleLog.txt";
            //filePath = "C:\\Users\\Fallan\\source\\repos\\RogueLike\\battleLog.txt";
            File.AppendAllText(this.filePath, DateTime.Now + LogText + Environment.NewLine);
        }

    }
}
