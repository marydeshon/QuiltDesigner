using QuiltDesigner.Models;
namespace QuiltDesigner.Services;

public interface ISwatchService
{
    List<Swatch> GetAll(string path, List<string> swatchfilenames);
}