using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    public class WaitForHourCommand : ICommand
    {
        private int targetHour;

        public WaitForHourCommand(int targetHour)
        {
            this.targetHour = targetHour;
        }

        public void Execute()
        {
            // Perform wait for hour logic
            Console.WriteLine($"Waiting for hour: {targetHour}");
        }
    }
}
