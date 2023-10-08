var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    Company company = new Company();
    company.Name = "Name111";
    company.Email = "Email222";
    company.Address = "Address333";

    Random random = new Random();
    int randomNumber = random.Next(0, 101);

    await context.Response.WriteAsync($"Compamy:\n {company.Name} \n {company.Email} \n {company.Address} ");
    await context.Response.WriteAsync($"\nRandom number: {randomNumber}");

});
app.Run();
public class Company
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}
