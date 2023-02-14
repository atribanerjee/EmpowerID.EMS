using EmpowerID.EMS.ApplicationCore.Interfaces;
using EmpowerID.EMS.Infrastructure.Data;
using EmpowerID.EMS.Web.Interfaces;
using EmpowerID.EMS.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");



builder.Services.AddDbContext<EMSContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EMSDBConn"),
sqlServerOptions => sqlServerOptions.CommandTimeout(300)));


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();


builder.Services.AddScoped<IEmployeeService,EmployeeService>();



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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
