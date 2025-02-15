namespace QuiltDesigner.Models;

public class Triangle
{
    public int[] pts {get; set;}
    public string Color { get; set; }

    public Triangle(int i0, int i1, int i2, int i3, int i4, int i5, bool dark = true)
    {
        pts = new int[] { i0, i1, i2, i3, i4, i5 };
        
        var random = new Random();
      
        if (dark)
            Color = String.Format("#{0:X6}", random.Next(0x1000000) & 0x7F7F7F);
        else 
            Color = String.Format("#{0:X6}", random.Next(0x1000000));

        // if (dark)
        //     Color = String.Format("#1f1f1f");
        // else
        //     Color = String.Format("#e0e0e0");
    }
}