using DotNetEd.CoreAdmin;
using Grove.Data;
using Grove.Data.Models;
using Grove.Handling;
using Grove.Infrastructure;
using Grove.Logic;
using Grove.Web.Components;
using Grove.Web.Extensions;
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
builder.Services.AddLogic();

builder.Services.AddDbContext<GroveDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCoreAdmin(new CoreAdminOptions()
{
    IgnoreEntityTypes =
    [
        typeof(BillingEm),
        typeof(BillingItemEm),
        typeof(CustomerEm)
    ]
});

#endregion


#region app

builder.Services.AddLocalization(options => 
    options.ResourcesPath = "Resoruces"
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.Urls.Add("http://0.0.0.0:10000");
}

app.ApplyMigrations();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.UseAntiforgery();

var supportedCultures = builder.Configuration.GetSection("Cultures")
    .GetChildren().ToDictionary(x => x.Key, x => x.Value).Keys.ToArray();

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseCoreAdminCustomTitle("Grove.Admin");

app.UseStatusCodePagesWithRedirects("/{0}");

app.UseCoreAdminCustomAuth(CustomAuthExtension.customAuthFunctiion);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

#endregion