namespace Oop;

public class Program
{
    public static TodoService todoService = new LocalTodoService();
    private static Dictionary<string, Command> commands = new Dictionary<string, Command>();

    static void Main(string[] _args)
    {
        Console.WriteLine("Starting Todo Application...");

        SetupCommands();

        string? line = Console.ReadLine();
        while (line != null && !Utils.CompareStrings(line, "exit"))
        {
            TryCommand(line);
            Console.WriteLine("-------------------");
            line = Console.ReadLine();
        }
    }

    public static void SetupCommands()
    {
        commands.Add("help", new HelpCommand());
        commands.Add("list", new ListCommand(todoService));
        commands.Add("add", new AddCommand(todoService));
        commands.Add("remove", new RemoveCommand(todoService));
        commands.Add("update", new UpdateCommand(todoService));
    }

    public static void TryCommand(string line)
    {
        string[] args = line.Split(" ");
        if (args.Length == 0)
        {
            return;
        }

        string action = args[0];
        Command command = commands[action.ToLower()];
        command.execute(args);
    }
}
