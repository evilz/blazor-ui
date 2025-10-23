using BlazorApp.Components;
using BlazorApp.Services;
using Sysinfocus.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Sysinfocus Simple/UI services
builder.Services.AddSysinfocus();

builder.Services.AddScoped<StateManager>();
builder.Services.AddScoped<BrowserExtensions>();

// Add HttpClient for JsonPlaceholder API
// Note: Using mock service because external API access may be restricted
// To use real API, uncomment the next line and comment out the mock service line
// builder.Services.AddHttpClient<IJsonPlaceholderService, JsonPlaceholderService>();
builder.Services.AddScoped<IJsonPlaceholderService, MockJsonPlaceholderService>();

// Add Mail service
builder.Services.AddScoped<IMailService, MockMailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
