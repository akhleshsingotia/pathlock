using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    public class FileDeleteCommand : ICommand
    {
        private string filePath;

        public FileDeleteCommand(string filePath)
        {
            this.filePath = filePath;
        }

        public void Execute()
        {
            // Perform file delete logic
            Console.WriteLine($"Deleting file: {filePath}");
        }
    }
}
