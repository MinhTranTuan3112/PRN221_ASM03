using SignalRAssignment.BusinessLogic.Extensions;
using SignalRAssignment.DataAccess.Extensions;
using SignalRAssignment.Extensions;
using SignalRAssignment.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddWebAppDependencies(configuration)
                .AddBusinessLogicDependencies()
                .AddDataAccessDependencies();

builder.Services.AddSignalR();

var app = builder.Build();


app.MapCustomEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.MapSignalRHubs();

app.UseCors("AllowAll");

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
