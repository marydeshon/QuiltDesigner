using QuiltDesigner.Models;

namespace QuiltDesigner.Services;

public class Flag  : IPatternSevice
{
    int Ln = 40;
    public List<Shape> GetAll()
    {
        List<Shape> shapes = new List<Shape>();
        for (int row = 0; row < 9; row++)
        {
            for (int i = 0; i < 14; i++)
                shapes.Add(new Shape([
                    i * Ln, row * Ln,
                    i * Ln + Ln, row * Ln,
                    i * Ln + Ln, row * Ln + Ln,
                    i * Ln, row * Ln + Ln,
                ], "#797979"));
        }
    
        return shapes;
    }
}