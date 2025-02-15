using QuiltDesigner.Models;

namespace QuiltDesigner.Services;

public class Winchester : IPatternSevice
{
    int Ln = 100;
    public List<Shape> GetAll()
    {
        List<Shape> shapes = new List<Shape>()
        {

        };
        
        string[][] darks = [
            ["#000000", "#ffffff", "#ffffff", "#000000", "#000000", "#ffffff"],
            ["#ffffff", "#000000", "#000000", "#ffffff", "#ffffff", "#000000"]];

        for (int row = 0; row < 4; row++)
        {
            int a = row % 2;
            int brow = row + 4;
            for (int i = 0; i < 3; i++)
            {
                shapes.Add(new Shape ([ i*Ln, row*Ln, i*Ln+Ln, row*Ln, i*Ln, row*Ln+Ln],darks[a][i*2]));
                shapes.Add(new Shape ([ i*Ln+Ln, row*Ln+Ln, i*Ln+Ln, row*Ln, i*Ln, row*Ln+Ln],darks[a][i*2+1]));
                shapes.Add(new Shape ([ i*Ln, brow*Ln, i*Ln+Ln, brow*Ln+Ln, i*Ln, brow*Ln+Ln],darks[a][i*2+1]));
                shapes.Add(new Shape ([ i*Ln, brow*Ln, i*Ln+Ln, brow*Ln, i*Ln+Ln, brow*Ln+Ln],darks[a][i*2]));
            }
            for (int i = 3; i < 6; i++)
            {
                int t = i - 3;
                shapes.Add(new Shape ([ i*Ln, row*Ln, i*Ln+Ln, row*Ln+Ln, i*Ln, row*Ln+Ln],darks[a][t*2+1]));
                shapes.Add(new Shape ([ i*Ln, row*Ln, i*Ln+Ln, row*Ln, i*Ln+Ln, row*Ln+Ln],darks[a][t*2]));
                shapes.Add(new Shape ([ i*Ln, brow*Ln, i*Ln+Ln, brow*Ln, i*Ln, brow*Ln+Ln],darks[a][t*2]));
                shapes.Add(new Shape ([ i*Ln+Ln, brow*Ln+Ln, i*Ln+Ln, brow*Ln, i*Ln, brow*Ln+Ln],darks[a][t*2+1]));
            }
        }
        return shapes;
    }
}