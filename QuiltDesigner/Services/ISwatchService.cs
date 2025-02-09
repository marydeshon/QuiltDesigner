using QuiltDesigner.Models;
namespace QuiltDesigner.Services;

public interface ISwatchService
{
    List<Swatch> GetAll();
}