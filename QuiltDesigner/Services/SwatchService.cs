using QuiltDesigner.Models;
namespace QuiltDesigner.Services;

public class SwatchService : ISwatchService
{
    public List<Swatch> GetAll(string path, List<string> swatchfilenames)
    {
        DirectoryInfo directory = new DirectoryInfo(path);
        FileInfo[] files = directory.GetFiles();
        var notHidden = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));

        List<Swatch> swatches = new List<Swatch>();
        foreach (var fi in notHidden)
        {
            swatches.Add(new Swatch{Id = 1, ImageName=fi.Name });
            swatchfilenames.Add(fi.Name);
        }
        return swatches;
    }
}