using MudBlazor.Services;
using DiplomaCRM.Context;
using Microsoft.AspNetCore.Components.Authorization;
using DiplomaCRM.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddDbContextFactory<DiplomaCRMContext>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<WebAuthentication>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<WebAuthentication>());

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();