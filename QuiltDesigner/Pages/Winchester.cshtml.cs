using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuiltDesigner.Models;
using QuiltDesigner.Services;

namespace QuiltDesigner.Pages;

public class Winchester(
    IWebHostEnvironment environment,
    [FromKeyedServices("winchester")] IPatternSevice patternService,
    ISwatchService swatchService)
    : PageModel
{
    public List<Shape> Shapes { get; set; } = new List<Shape>();
    public List<string> Swatchfilenames { get; set; } = new List<string>();
    public List<Swatch> Swatches { get; set; } = new List<Swatch>();

    public void OnGet()
    {
        Shapes = patternService.GetAll();
        string tmpPath = Path.Combine(environment.WebRootPath, "images", "swatches");
        Swatches = swatchService.GetAll(tmpPath, Swatchfilenames);
    }
}