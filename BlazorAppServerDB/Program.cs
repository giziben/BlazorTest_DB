using BlazorAppServerDB.Components;
using BlazorAppServerDB.Models;
using BlazorAppServerDB.Services;

// Added using statement
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// This registers the various services needed to support
// server-side rendering of Razor components.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

// Connection string from Settings
var connectionString = builder.Configuration.GetConnectionString("CustomersDB");
// SQLite inject service
builder.Services.AddSqlite<CustomersContext>(connectionString);
//builder.Services.AddDbContextFactory<PersonContext>(options => options.UseSqlite(connectionString));

// Our our service so it can be injected to the page
builder.Services.AddScoped<CustomerService>();

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

// We also need to be able to route requests to our Razor Components.
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.UseStatusCodePagesWithRedirects("/errorpage404{0}");

app.Run();
