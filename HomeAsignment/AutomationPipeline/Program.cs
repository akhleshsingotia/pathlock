using AutomationPipeline;

public class Program
{
    public static void Main(string[] args)
    {
        // Stage 1: Read commands from text file
        var commandFilePath = "commands.txt";
        var commandLines = File.ReadAllLines(commandFilePath);

        var commands = new List<ICommand>();
        foreach (var commandLine in commandLines)
        {
            var commandParts = commandLine.Split(',');
            var commandName = commandParts[0];

            if (commandName == "FileCopy")
            {
                var sourceFile = commandParts[1];
                var destinationFile = commandParts[2];
                commands.Add(new FileCopyCommand(sourceFile, destinationFile));
            }
            else if (commandName == "FileDelete")
            {
                var filePath = commandParts[1];
                commands.Add(new FileDeleteCommand(filePath));
            }
            // Add other command types...
        }

        // Create automation pipeline and execute commands
        var pipeline = new AutomationPipeline.AutomationPipeline(commands);
        pipeline.ExecuteCommands();

        // Stage 3: Read commands from XML file
        var xmlFilePath = "commands.xml";
        var xmlCommandReader = new XmlCommandReader();
        var xmlCommands = xmlCommandReader.ReadCommands(xmlFilePath);

        // Create automation pipeline and execute XML commands
        var xmlPipeline = new AutomationPipeline.AutomationPipeline(xmlCommands);
        xmlPipeline.ExecuteCommands();

        Console.ReadLine();
    }
}
 