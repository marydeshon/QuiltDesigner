using Microsoft.AspNetCore.Mvc.RazorPages;
using QuiltDesigner.Models;
using QuiltDesigner.Services;

namespace QuiltDesigner.Pages;

public class Rungs(
    IWebHostEnvironment environment,
    [FromKeyedServices("rungs")] IPatternSevice patternService,
    [FromKeyedServices("rungs")] ISwatchService swatchService)
    : PageModel
{
    public List<Shape> Shapes { get; set; } = new List<Shape>();
    public List<string> Swatchfilenames { get; set; } = new List<string>();
    
    public List<string> Swatchfilenames2 { get; set; } = new List<string>();
    
    public List<Swatch> Swatches { get; set; } = new List<Swatch>();
    
    public void OnGet()
    {
        Shapes = patternService.GetAll();
        
        string tmpPath = Path.Combine(environment.WebRootPath, "images", "swatches3");
        DirectoryInfo directory = new DirectoryInfo(tmpPath);
        FileInfo[] files = directory.GetFiles();
        var notHidden = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
        int id = 1;
        foreach (var fi in notHidden)
        {
            Swatchfilenames.Add(fi.Name);
            Swatchfilenames2.Add(@"/images/swatches3/"+fi.Name);
            Swatches.Add(new Swatch{Id = id++, ImageName=fi.Name});
        }
    }
}