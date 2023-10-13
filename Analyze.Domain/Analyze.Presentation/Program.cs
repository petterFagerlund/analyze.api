using Analyze.Application.Services;
using Analyze.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IStockService, StockService>();
builder.Services.AddHttpClient<IStockService, StockService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Yahoo:Url"]);
});
var app = builder.Build();
app.MapPost("/financialData", async (StockRequest request, IStockService service) => await service.GetFinancialDataAsync(request));

app.Run();