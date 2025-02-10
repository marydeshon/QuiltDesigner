using QuiltDesigner.Models;
namespace QuiltDesigner.Services;

public class SwatchService :ISwatchService
{
    public List<Swatch> GetAll()
    {
        List<Swatch> swatches = new List<Swatch>{
            new Swatch{Id = 1, ImageName="img1.jpg"},
            new Swatch{Id = 2, ImageName="lgt1.jpg"},
            new Swatch{Id = 3, ImageName="lgt2.jpg"},
            new Swatch{Id = 4, ImageName="img2.jpg"},
            new Swatch{Id = 5, ImageName="img1.jpg"},
        };
        return swatches;
    }
}