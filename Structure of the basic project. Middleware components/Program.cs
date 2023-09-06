using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Structure_of_the_basic_project._Middleware_components.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new Company
{
    Name = "Rekonvald Company",
    Address = "121 Street",
    AmountOfWorkers = 100
});

var app = builder.Build();

app.MapGet("/company", (IServiceProvider serviceProvider) =>
{
    var company = serviceProvider.GetRequiredService<Company>();
    var random = new Random();
    var randomNumber = random.Next(0, 101);
    return $"Name: {company.Name}\n" +
           $"Address: {company.Address}\n" +
           $"Amount of workers: {company.AmountOfWorkers}\n" +
           $"Number of workers who have a shift today: {randomNumber}\n";
});

app.Run();
