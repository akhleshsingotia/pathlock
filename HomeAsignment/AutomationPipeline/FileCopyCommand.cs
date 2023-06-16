using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    public class FileCopyCommand : ICommand
    {
        private string sourceFile;
        private string destinationFile;

        public FileCopyCommand(string sourceFile, string destinationFile)
        {
            this.sourceFile = sourceFile;
            this.destinationFile = destinationFile;
        }

        public void Execute()
        {
            // Perform file copy logic
            Console.WriteLine($"Copying file: {sourceFile} to {destinationFile}");
        }
    }
}
