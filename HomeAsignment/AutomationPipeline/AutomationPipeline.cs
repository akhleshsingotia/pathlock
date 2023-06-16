using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    public class AutomationPipeline
    {
        private List<ICommand> commands;

        public AutomationPipeline(List<ICommand> commands)
        {
            this.commands = commands;
        }

        public void ExecuteCommands()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }
}
