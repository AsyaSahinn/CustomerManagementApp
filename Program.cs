using CustomerManagement.BackgroundJob.Concrete;
using CustomerManagement.BackgroundJob;
using CustomerManagement.DAL.Abstract;
using CustomerManagement.DAL.Concrete;
using CustomerManagement.DAL.GenericRepository;
using CustomerManagement.DBContext;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire;
using Hangfire.Redis.StackExchange;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserManagementApp"));

});

JobStorage.Current = new Hangfire.Redis.StackExchange.RedisStorage(builder.Configuration.GetConnectionString("redis"));

builder.Services.AddHangfireServer();
builder.Services.AddHangfire(x => x.UseRedisStorage(builder.Configuration.GetConnectionString("redis")));


JobStorage.Current = new RedisStorage(builder.Configuration.GetConnectionString("redis"));


builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("redis")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IBackgroundJob, BackGroundJob>();

//RecurringJob.AddOrUpdate<IBackgroundJob>(("user"), job => job.UserCache(), "59 23 * * *");

var app = builder.Build();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
        {
            RequireSsl = false,
            SslRedirect = false,
            LoginCaseSensitive = true,
            Users = new []
            {
                new BasicAuthAuthorizationUser
                {
                    Login = "admin",
                    PasswordClear =  "hangfire#"
                }
            }
        }) }
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//    options.RoutePrefix = string.Empty;
//});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseHangfireDashboard();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Login}");
app.Run();
