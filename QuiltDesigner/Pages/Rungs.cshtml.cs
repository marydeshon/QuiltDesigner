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
    
    public void OnGet()
    {
        Shapes = patternService.GetAll();
        
        string tmpPath = Path.Combine(environment.WebRootPath, "images", "swatches");
        DirectoryInfo directory = new DirectoryInfo(tmpPath);
        FileInfo[] files = directory.GetFiles();
        var notHidden = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
        foreach (var fi in notHidden)
            Swatchfilenames.Add(fi.Name);
    }
}