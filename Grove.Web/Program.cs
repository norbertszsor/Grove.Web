using System.Text;
using DotNetEd.CoreAdmin;
using Grove.Data;
using Grove.Data.Models;
using Grove.Handling;
using Grove.Infrastructure;
using Grove.Logic;
using Grove.Logic.Abstraction;
using Grove.Web.Components;
using Grove.Web.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["TokenOptions:SecretKey"]!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCoreAdmin(new CoreAdminOptions()
{
    IgnoreEntityTypes =
    [
        typeof(BillingEm),
        typeof(BillingItemEm),
        typeof(CustomerEm),
        typeof(UserEm)
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

app.ApplySeed();

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

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.UseCoreAdminCustomAuth(x => x.GetService<IAuthService>()!.IsAuthenticatedAdminAsync());

app.UseCoreAdminCustomTitle("Grove.Admin");

app.UseStatusCodePagesWithRedirects("/{0}");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

#endregion