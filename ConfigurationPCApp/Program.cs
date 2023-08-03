using Microsoft.EntityFrameworkCore;
using PCBuilderApp.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PCBuilderContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConfigurationPCContext") ?? throw new InvalidOperationException("Connection string 'ConfigurationPCContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
//app.UseEndpoints(routes =>
//{
//    routes.MapRoute(
//        name: "default",
//        template: "{controller=Home}/{action=Index}/{id?}");
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
