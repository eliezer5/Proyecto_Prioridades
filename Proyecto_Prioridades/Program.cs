using Microsoft.EntityFrameworkCore;
using Proyecto_Prioridades.Services;
using Proyecto_Prioridades.Components;
using Proyecto_Prioridades.DAL;
using Proyecto_Prioridades.Models;
using Proyecto_Prioridades.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(ConStr));
builder.Services.AddScoped<PrioridadesService>();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<TicketsService>();
builder.Services.AddScoped<SistemasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
