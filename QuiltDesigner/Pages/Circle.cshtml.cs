using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.AspNetCore.Hosting;
using QuiltDesigner.Models;

namespace QuiltDesigner.Pages;

public class Circle : PageModel
{
    private Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment;
    public Circle(Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    [BindProperty]
    public IFormFile Upload { get; set; }
    public List<Triangle> triangles { get; set; } = new List<Triangle>();
    public List<string> swatchfilenames { get; set; } = new List<string>();
    
    [BindProperty]
    public int Radius {get; set;} = 100;
    public string Color { get; set; } = "#a0a";
    
    public int Ln { get; set; } = 100;
    public void OnGet()
    {
        bool[][] darks = [
            [true, false, false, true, true, false],
            [false, true, true, false, false, true]];

        for (int row = 0; row < 4; row++)
        {
            int a = row % 2;
            int brow = row + 4;
            for (int i = 0; i < 3; i++)
            {
                triangles.Add(new Triangle(i*Ln, row*Ln, i*Ln+Ln, row*Ln, i*Ln, row*Ln+Ln,darks[a][i*2]));
                triangles.Add(new Triangle(i*Ln+Ln, row*Ln+Ln, i*Ln+Ln, row*Ln, i*Ln, row*Ln+Ln,darks[a][i*2+1]));
                
                triangles.Add(new Triangle(i*Ln, brow*Ln, i*Ln+Ln, brow*Ln+Ln, i*Ln, brow*Ln+Ln,darks[a][i*2+1]));
                triangles.Add(new Triangle(i*Ln, brow*Ln, i*Ln+Ln, brow*Ln, i*Ln+Ln, brow*Ln+Ln,darks[a][i*2]));
            }
            for (int i = 3; i < 6; i++)
            {
                int t = i - 3;
                triangles.Add(new Triangle(i*Ln, row*Ln, i*Ln+Ln, row*Ln+Ln, i*Ln, row*Ln+Ln,darks[a][t*2+1]));
                triangles.Add(new Triangle(i*Ln, row*Ln, i*Ln+Ln, row*Ln, i*Ln+Ln, row*Ln+Ln,darks[a][t*2]));
                
                triangles.Add(new Triangle(i*Ln, brow*Ln, i*Ln+Ln, brow*Ln, i*Ln, brow*Ln+Ln,darks[a][t*2]));
                triangles.Add(new Triangle(i*Ln+Ln, brow*Ln+Ln, i*Ln+Ln, brow*Ln, i*Ln, brow*Ln+Ln,darks[a][t*2+1]));
            }
        }

        string tmpPath = Path.Combine(_environment.WebRootPath, "images", "swatches");
        DirectoryInfo directory = new DirectoryInfo(tmpPath);
        FileInfo[] files = directory.GetFiles();
        var notHidden = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
        foreach (var fi in notHidden)
            swatchfilenames.Add(fi.Name);
    }
    
    // public async Task<IActionResult> OnPostAsync()
    // {
    //     var random = new Random();
    //     Color = String.Format("#{0:X6}", random.Next(0x1000000));
    //     return Page();
    // }
    
    public async Task OnPostAsync()
    {
        var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/swatches", Upload.FileName);
        using (var fileStream = new FileStream(file, FileMode.Create))
        {
            await Upload.CopyToAsync(fileStream);
        }
    }
}

public class Triangle
{
    public int[] pts {get; set;}
    public string Color { get; set; }

    public Triangle(int i0, int i1, int i2, int i3, int i4, int i5, bool dark = true)
    {
        pts = new int[] { i0, i1, i2, i3, i4, i5 };
        
        var random = new Random();
      
        if (dark)
            Color = String.Format("#{0:X6}", random.Next(0x1000000) & 0x7F7F7F);
        else 
            Color = String.Format("#{0:X6}", random.Next(0x1000000));

        // if (dark)
        //     Color = String.Format("#1f1f1f");
        // else
        //     Color = String.Format("#e0e0e0");
    }
}