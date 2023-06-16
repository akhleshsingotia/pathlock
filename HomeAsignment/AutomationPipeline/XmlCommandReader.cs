using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;  

namespace AutomationPipeline
{
    public class XmlCommandReader
    {
        public List<ICommand> ReadCommands(string xmlFilePath)
        {
            var commands = new List<ICommand>();

            // Read XML file and parse commands
            var xmlDocument = XDocument.Load(xmlFilePath);
            foreach (var commandElement in xmlDocument.Root.Elements("Command"))
            {
                var commandName = commandElement.Attribute("Name")?.Value;
                if (commandName == "FileCopy")
                {
                    var sourceFile = commandElement.Attribute("SourceFile")?.Value;
                    var destinationFile = commandElement.Attribute("DestinationFile")?.Value;
                    commands.Add(new FileCopyCommand(sourceFile, destinationFile));
                }
                else if (commandName == "FileDelete")
                {
                    var filePath = commandElement.Attribute("FilePath")?.Value;
                    commands.Add(new FileDeleteCommand(filePath));
                }
                // Add other command types...
            }

            return commands;
        }
    }
}
