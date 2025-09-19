using CarRentalCsv.Services;
using CarRentalCsv;
using CarRentalCsv.Components;


var builder = WebApplication.CreateBuilder(args);


// Razor Components + Interaktivität (Server)
builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();


// CsvWriter als DI-Service
builder.Services.AddSingleton<CsvWriter>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Error");
app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
.AddInteractiveServerRenderMode();


app.Run();