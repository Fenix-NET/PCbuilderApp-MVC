using Microsoft.EntityFrameworkCore;
using System;
using PcBuilderApp;
using PcBuilderApp.Data;
using PcBuilderApp.Services.CatalogService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PcBuilderContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConfigurationPCContext") ?? throw new InvalidOperationException("Connection string 'ConfigurationPCContext' not found.")));

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<ICatalogService, CatalogeService>();

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
