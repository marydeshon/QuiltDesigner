using QuiltDesigner.Data;
using QuiltDesigner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace QuiltDesigner.Pages;

public class IndexModel : PageModel
{
    private readonly BakeryContext context;
    public IndexModel(BakeryContext context) =>
        this.context = context;
    
    public List<Product> Products { get; set; } = new ();
    public async Task OnGetAsync() =>
        Products = await context.Products.ToListAsync();
}