using System.Linq;
using System.Net.Cache;
using System.Security.Cryptography.Xml;

List<Person> users = new List<Person>
{
    new () { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
    new () { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
    new () { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }

};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapGet("/api/users", ()=> users);

app.MapGet("/api/users/{id}", (string id) =>
{
    Person? user = users.FirstOrDefault(u => u.Id == id);

    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });
    
    return Results.Json(user);
});

app.MapDelete("/api/users/{id}", (string id) =>
{
    Person? user = users.FirstOrDefault(u => u.Id == id);

    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

    users.Remove(user);
    return Results.Json(user);
});

app.MapPost("/api/users", (Person user) =>
{
    user.Id = Guid.NewGuid().ToString();

    users.Add(user);
    return user;
});

app.MapPut("/api/users", (Person userData) =>
{
    var user = users.FirstOrDefault(u => u.Id == userData.Id);

    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

    return Results.Json(user);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class Person
{
    public string Id { get; set; } = "";

    public string Name { get; set; } = "";

    public int Age { get; set; }
}