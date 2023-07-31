using Microsoft.EntityFrameworkCore;
using PCBuilderApp.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PCBuilderContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConfigurationPCContext") ?? throw new InvalidOperationException("Connection string 'ConfigurationPCContext' not found.")));
builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;

    });
}



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
