var builder = WebApplication.CreateBuilder();
builder.Services.AddTransient<CalcService>();
builder.Services.AddTransient<TimeOfDayService>();
var app = builder.Build();
app.Run(async context =>
{
    var timeOfDayService = app.Services.GetService<TimeOfDayService>();
    var CalcService = app.Services.GetService<CalcService>();

    await context.Response.WriteAsync($"Time: {timeOfDayService?.GetTimeOfDay()}");
    await context.Response.WriteAsync($"\nSum of 77 and 33: {CalcService?.Add(77,33)}");
    await context.Response.WriteAsync($"\nSubtraction of 77 and 33: {CalcService?.Subtract(77, 33)}");
    await context.Response.WriteAsync($"\nDividion of 77 and 33: {CalcService?.Divide(77, 33)}");
    await context.Response.WriteAsync($"\nMultiplication of 33 and 77: {CalcService?.Multiplication(33, 77)}");

});
app.Run();