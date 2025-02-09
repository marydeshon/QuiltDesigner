using QuiltDesigner.Models;
namespace QuiltDesigner.Services;

public class SwatchService :ISwatchService
{
    public List<Swatch> GetAll()
    {
        List<Swatch> swatches = new List<Swatch>{
            new Swatch{Id = 1, Pattern="img1"},
            new Swatch{Id = 2, Pattern="img2"},
            new Swatch{Id = 3, Pattern="img1"},
            new Swatch{Id = 4, Pattern="img2"},
            new Swatch{Id = 5, Pattern="img1"},
        };
        return swatches;
    }
}