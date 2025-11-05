using QuiltDesigner.Models;

namespace QuiltDesigner.Services;

public class Rungs : IPatternSevice
{
    public List<Shape> GetAll()
    {
        List<Shape> shapes = new List<Shape>()
        {

        };
        double scale = 20;
        double one = scale * 1;
        double one_pt_five = scale * 1.5;
        double two = scale * 2;
        double three = scale * 3;
        double five = scale * 5;
        
        double[,] rowHeights = {
            {one_pt_five, one, three, five, two},// 1.5 1 3 5 2
            {one, two, five, one_pt_five, one_pt_five},// 1 2 5 1.5 1.5
        };

        double[] colWidths = [three, 11*scale, three];     // 3" 11" 3"
        int curX = 0;
        int curY = 0;
        string yellow = "#d9d21c";
        string purp1 = "#9380a9";
        string purp2 = "#7f718e";
        string purp3 = "#2c1f77";
        string grn1 = "#babe1e";
        string grn2 = "#acbc47";
        string[] colors = [yellow, purp2, grn2, purp3, grn1,
            "#ffffff", "#000000", "#ff0000","#00ff00","#0000ff"];
        
        string[,] colors2 = new string[10, 3] {
            { purp3, yellow, purp2},
            { grn2, purp2, grn2},
            { purp1, grn2, purp3},
            { yellow, purp3, grn2 },
            { purp2, grn1, purp1},
            
            { purp1, grn2, purp3},
            { grn1, purp3, grn2},
            { purp2, yellow, purp1},
            { grn1, purp2, yellow },
            { purp1, grn2, purp3},
        };
        
        int colorcount= 0;
        
        for (int panel = 0; panel < rowHeights.GetLength(0); panel++)
        {
            for (int row = 0; row < rowHeights.GetLength(1); row++)
            {
                for (int col = 0; col < colWidths.Length; col++)
                {
                    shapes.Add(new Shape([
                            curX, curY,
                            curX, (int)(curY + rowHeights[panel,row]),
                            (int)(curX + colWidths[col]), (int)(curY + rowHeights[panel,row]),
                            (int)(curX + colWidths[col]), curY
                        ],
                        colors2[row,col]));
                    curX += (int)colWidths[col];
                }

                colorcount++;
                curX = 0;
                curY += (int)rowHeights[panel,row];
            }
        }
        return shapes;
    }
}