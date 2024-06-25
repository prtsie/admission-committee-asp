using Database;
using Serilog;

namespace AdmissionCommitteeASP;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Seq("http://localhost:5341/")
            .WriteTo.File("log.txt")
            .CreateLogger();
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSingleton(Log.Logger);
        builder.Services.AddTransient<CommitteeContext>();
        builder.Services.AddTransient<Services.DbAccessService>();
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Applicants}/{action=List}/{id?}");

        Log.Information("Приложение запущено");
        app.Run();
        Log.Information("Приложение остановлено");
        Log.CloseAndFlush();
    }
}
