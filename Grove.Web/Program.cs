using Grove.Data;
using Grove.Handling;
using Grove.Infrastructure;
using Grove.Web.Components;
using Microsoft.EntityFrameworkCore;

#region builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(options =>
{
    options.AddConsole();
    options.AddDebug();
});

builder.Services.AddInfrastructure();

builder.Services.AddHandling();

builder.Services.AddDbContext<GroveDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCoreAdmin();

#endregion


#region app

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.UseAntiforgery();

app.UseCoreAdminCustomTitle("Grove.Admin");

app.UseStatusCodePagesWithRedirects("/{0}");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

#endregion