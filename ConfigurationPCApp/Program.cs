using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationPCApp.Data;
ProgramParse builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ConfigurationPCContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConfigurationPCContext") ?? throw new InvalidOperationException("Connection string 'ConfigurationPCContext' not found.")));
builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseEndpoints(endpoints =>
    endpoints.MapControllers());

app.Run();
