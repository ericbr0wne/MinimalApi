using MinimalApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/color/{color}", (string color) => 
{
    if (Enum.TryParse<Color>(color, true, out var colorEnum))
    {
        return Results.Ok($"Color: {colorEnum}");
    }
    else
    {
        return Results.BadRequest("Invalid color");
    }
});

app.MapGet("/vinyl/{name}", (string name) => 
{
    var record = new Records();
    return record.GetVinylInfo(name);
});

app.Run();
