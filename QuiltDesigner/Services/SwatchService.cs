using QuiltDesigner.Models;
namespace QuiltDesigner.Services;

public class SwatchService :ISwatchService
{
    public List<Swatch> GetAll()
    {
        List<Swatch> swatches = new List<Swatch>{
            new Swatch{Id = 1, ImageName="lgt1.jpg"},
            new Swatch{Id = 2, ImageName="lgt2.jpg"},
            new Swatch{Id = 3, ImageName="lgt3.jpg"},
            new Swatch{Id = 4, ImageName="lgt4.jpg"},
            new Swatch{Id = 5, ImageName="drk1.jpg"},
            new Swatch{Id = 6, ImageName="drk2.jpg"},
            new Swatch{Id = 7, ImageName="drk3.jpg"},
            new Swatch{Id = 8, ImageName="drk4.jpg"},
        };
        return swatches;
    }
}