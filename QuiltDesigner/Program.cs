using QuiltDesigner.Services;

namespace QuiltDesigner;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        
        builder.Services.AddKeyedTransient<ISwatchService, SwatchService>("winchester");
        builder.Services.AddKeyedTransient<ISwatchService, RungsSwatchService>("rungs");
        builder.Services.AddKeyedTransient<IPatternSevice, Winchester>("winchester");
        builder.Services.AddKeyedTransient<IPatternSevice, Rungs>("rungs");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
            .WithStaticAssets();

        app.Run();
    }
}