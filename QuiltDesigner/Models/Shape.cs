using System.Runtime.InteropServices.JavaScript;

namespace QuiltDesigner.Models;

public class Shape
{
    public int[] Points { get; set; }
    public string Color { get; set; }

    public Shape(int[] pts, string color)
    {
        Points = pts;
        Color = GetColor(color);
    }
    
    string GetColor(string color)
    {
        Random random = new Random();
        int rInt;
        if (color.Equals("#000000"))
        {
            rInt = random.Next(20, 90);
        }
        else if (color.Equals("#ffffff"))
        {
            rInt = random.Next(120, 255);
        }
        else
            return color;
        
        return String.Format("#{0:X2}{0:X2}{0:X2}", rInt, rInt, rInt);
    }
}