using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<Company>();
builder.Services.AddTransient<Person>();

builder.Configuration.AddJsonFile("new/Companies.json");

var app = builder.Build();
var configuration = app.Services.GetService<IConfiguration>();
var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "new/persons");

if (File.Exists(jsonFilePath))
{
    var jsonContent = File.ReadAllText(jsonFilePath);
}

app.Map("/", () => "Index Page");

app.Map("/Companies", async (context) =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Map("/Companies/company", async (context) =>
{
    var company = app.Services.GetService<Company>();
    var companiesList = configuration.GetSection("Companies").Get<List<Company>>();
    foreach (var item in companiesList)
    {
        await context.Response.WriteAsync($"Company: {item.Name}; Numer of Employers: {item.NumberOfEmpl}\n");
    }
});

app.Map("/Companies/Profile/{id:int?}", (int? id) =>
{
    if (id.HasValue && id >= 0 && id <= 5)
    {
        var configFileName = $"new/persons/person{id}.json";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), configFileName);

        if (File.Exists(filePath))
        {
            var Person = JsonConvert.DeserializeObject<Person>(File.ReadAllText(filePath));
            return $"Name: {Person.Name}, Age: {Person.Age}";
        }
        else
        {
            return "File configuration of person is not found.";
        }
    }
    else
    {

        var defaultPerson = JsonConvert.DeserializeObject<Person>(File.ReadAllText("person0.json"));
        return $"Name: {defaultPerson.Name}, Age: {defaultPerson.Age}";
    }

});

app.MapGet("/allmaps", (IEnumerable<EndpointDataSource> endpointSources) =>
string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));

app.Run();