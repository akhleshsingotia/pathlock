using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    public class RunCommandFileCommand : ICommand
    {
        private string commandFilePath;

        public RunCommandFileCommand(string commandFilePath)
        {
            this.commandFilePath = commandFilePath;
        }

        public void Execute()
        {
            // Perform run command file logic
            Console.WriteLine($"Running command file: {commandFilePath}");
        }
    }
}
