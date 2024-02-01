using Microsoft.VisualStudio.TestPlatform.TestHost;
using Oop;

public class FakeTodoService : TodoService
{
    public string? title = null;

    public override void Add(Todo todo)
    {
        title = todo.Title;
    }

    public override List<Todo> GetAll()
    {
        throw new NotImplementedException();
    }

    public override Todo? Remove(int id)
    {
        throw new NotImplementedException();
    }

    public override Todo? Update(int id, bool completed)
    {
        throw new NotImplementedException();
    }
}

public class TodoTests
{
    [Fact]
    public void TodoService_Add()
    {
        LocalTodoService service = new LocalTodoService();
        Todo todo = new Todo("Städa", false);

        service.Add(todo);
        Assert.Single(service.GetAll());
    }

    [Fact]
    public void TodoService_Remove()
    {
        LocalTodoService service = new LocalTodoService();

        Todo? todo = service.Remove(0);
        Assert.Null(todo);
    }

    [Fact]
    public void TodoService_RemoveWith()
    {
        LocalTodoService service = new LocalTodoService();
        Todo todo = new Todo("Städa", false);
        service.Add(todo);

        Todo? removed = service.Remove(todo.Id);
        Assert.NotNull(removed);
        Assert.Equal(todo.Title, removed.Title);
    }

    [Fact]
    public void AddCommand_Normal()
    {
        FakeTodoService service = new FakeTodoService();
        AddCommand command = new AddCommand(service);

        command.execute(["add", "hej"]);

        Assert.Equal("hej", service.title);
    }

    [Fact]
    public void AddCommand_Integration()
    {
        LocalTodoService service = new LocalTodoService();
        AddCommand command = new AddCommand(service);

        command.execute(["add", "hej"]);

        Assert.Single(service.GetAll());
        Assert.Equal("hej", service.GetAll()[0].Title);
    }

    [Fact]
    public void AddCommand_FullIntegration()
    {
        Oop.Program.SetupCommands();
        Oop.Program.TryCommand("add hej");

        Assert.Single(Oop.Program.todoService.GetAll());
        Assert.Equal("hej", Oop.Program.todoService.GetAll()[0].Title);
    }
}
