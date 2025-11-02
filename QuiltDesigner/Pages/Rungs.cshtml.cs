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
    
    public void OnGet()
    {
        Shapes = patternService.GetAll();
    }
}