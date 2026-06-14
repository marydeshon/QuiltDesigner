using QuiltDesigner.Models;

namespace QuiltDesigner.Services;

public class Flag  : IPatternSevice
{
    int Ln = 50;
    public List<Shape> GetAllx()
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
    public List<Shape> GetAll()
    {
        List<Shape> shapes = new List<Shape>();
        // row 1
        int row = 0;
        for (int i = 0; i < 14; i++)
            shapes.Add(new Shape
            {
                Color = "#f2f0ef",
                Points =
                [
                    i * Ln, row * Ln,
                    i * Ln + Ln, row * Ln,
                    i * Ln + Ln, row * Ln + Ln,
                    i * Ln, row * Ln + Ln
                ]
            });
        
        // row 2
        row++;
        int c = 0;
        shapes.Add(new Shape
        {
            Color = "#efefef",
            Points = [0, Ln, Ln, Ln, 0, Ln + Ln]
        });

    
        return shapes;
    }
}