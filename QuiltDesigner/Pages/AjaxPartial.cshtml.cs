using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuiltDesigner.Services;
using QuiltDesigner.Models;

namespace QuiltDesigner.Pages;

public class AjaxPartialModel : PageModel
{
    private ISwatchService _swatchService;
    public AjaxPartialModel(ISwatchService swatchService)
    {
        _swatchService = swatchService;
    }
    public List<Swatch> Swatches { get; set; }
    public void OnGet()
    {
    }
    public PartialViewResult OnGetSwatchPartial()
    {
        Swatches = _swatchService.GetAll();
        return Partial("_SwatchPartial", Swatches);
    }
}