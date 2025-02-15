namespace QuiltDesigner.Models;

public class Shape
{
    public int[] Points { get; set; }
    public string Color { get; set; }

    public Shape(int[] pts, string color)
    {
        Points = pts;
        Color = color;
    }
}