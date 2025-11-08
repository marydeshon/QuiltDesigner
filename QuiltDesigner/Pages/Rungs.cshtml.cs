using Microsoft.AspNetCore.Mvc.RazorPages;
using QuiltDesigner.Models;
using QuiltDesigner.Services;

namespace QuiltDesigner.Pages;

public class Rungs(
    IWebHostEnvironment environment,
    [FromKeyedServices("rungs")] IPatternSevice patternService,
    ISwatchService swatchService)
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
        Swatches = swatchService.GetAll(tmpPath, Swatchfilenames);
    }
}