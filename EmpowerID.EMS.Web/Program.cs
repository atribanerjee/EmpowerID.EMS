using EmpowerID.EMS.ApplicationCore.Interfaces;
using EmpowerID.EMS.Infrastructure.Data;
using EmpowerID.EMS.Web.Interfaces;
using EmpowerID.EMS.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
c.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "EmpowerID.EMS.REST API",
    Version = "v1"
}));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin();
        corsPolicyBuilder.AllowAnyMethod();
        corsPolicyBuilder.AllowAnyHeader();
    });
});

builder.Services.AddDbContext<EMSContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EMSDBConn"),
sqlServerOptions => sqlServerOptions.CommandTimeout(300)));


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();


builder.Services.AddScoped<IEmployeeService, EmployeeService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}

app.UseCors("CORS");

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmpowerID.EMS.REST API V1");
});



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
