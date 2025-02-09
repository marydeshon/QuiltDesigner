using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuiltDesigner.Pages;

public class Winchester : PageModel
{
    [BindProperty]
    public int Radius {get; set;} = 100;
    public string Color { get; set; } = "#a0a";
    public void OnGet()
    {
        
    }
}