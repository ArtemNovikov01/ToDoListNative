using ToDoListNative.Web;

var app = WebApplication
    .CreateBuilder(args)
    .BuildWebApplication()
    .Build();

app.ConfigureWebApplication();

app.Run();
