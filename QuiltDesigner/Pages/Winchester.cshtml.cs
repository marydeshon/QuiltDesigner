using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuiltDesigner.Models;
using QuiltDesigner.Services;

namespace QuiltDesigner.Pages;

public class Winchester : PageModel
{
    IWebHostEnvironment _environment;
    private IPatternSevice _patternService;
    private ISwatchService _swatchService;
    public Winchester(IWebHostEnvironment environment, IPatternSevice patternSevice,ISwatchService swatchService)
    {
        _environment = environment;
        _patternService = patternSevice;
        _swatchService = swatchService;
    }
    [BindProperty]
    public int Radius {get; set;} = 100;
    public string Color { get; set; } = "#a0a";

    public List<Shape> Shapes { get; set; } = new List<Shape>();
    public List<string> swatchfilenames { get; set; } = new List<string>();
    public List<Swatch> Swatches { get; set; } = new List<Swatch>();
    public void OnGet()
    {
        Shapes = _patternService.GetAll();
        
        string tmpPath = Path.Combine(_environment.WebRootPath, "images", "swatches");
        DirectoryInfo directory = new DirectoryInfo(tmpPath);
        FileInfo[] files = directory.GetFiles();
        var notHidden = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
        foreach (var fi in notHidden)
            swatchfilenames.Add(fi.Name);
        Swatches = _swatchService.GetAll();
    }
}