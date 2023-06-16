using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    public class QueryFolderFilesCommand : ICommand
    {
        private string folderPath;

        public QueryFolderFilesCommand(string folderPath)
        {
            this.folderPath = folderPath;
        }

        public void Execute()
        {
            // Perform query folder files logic
            var files = Directory.GetFiles(folderPath);
            Console.WriteLine($"Files in folder {folderPath}:");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
