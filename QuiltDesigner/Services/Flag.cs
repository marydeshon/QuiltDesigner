using Microsoft.EntityFrameworkCore.Query;
using QuiltDesigner.Models;

namespace QuiltDesigner.Services;

public class Flag  : IPatternSevice
{
    (int row, int col)[][] whitesquares = [
        [(0,0),(0,1),(0,2),(0,3),(0,4),(0,5),(0,6),(0,7),(0,8),(0,9),(0,10),(0,11),(0,12),(0,13)],
        [(1,11),(1,12), (1,13)]
    ];
    
    (int row, int col)[][] graysquares = [
        [(1,1),(1,2), (1,3)],
        [(2,0),(2,1), (2,2)]
    ];
    
    (int row, int col, int type, string color)[][] grid = [
        [(1,0,1, "#edf1f0"), (1,0,2, "#728f8d")],
        [(3,0,0, "#d9c9c9"),  (3,1,0, "#c9c9e9"), (3,2,1, "#c949c9"), (3,2,2, "#c94949")],
        [(4,0,0, "#e9c9c9"), (4,1,0, "#c9c9f9"), (4,2,0, "#c9d959")]
    ];
    
    int Sz = 50;

    public List<Shape> GetAll()
    {
        List<Shape> shapes = new List<Shape>();
        foreach (var row in whitesquares)
        {
            foreach (var item in row)
            {
                shapes.Add(maketheshape(item.row, item.col, 0, "#edf1f0"));
            }
        }
        
        foreach (var row in  graysquares)
        {
            foreach (var item in row)
            {
                shapes.Add(maketheshape(item.row, item.col, 0, "#728f8d"));
            }
        }
        
        foreach (var row in grid)
        {
            foreach (var item in row)
            {
                shapes.Add(maketheshape(item.row, item.col, item.type, item.color));
            }
        }
        return shapes;
    }

    Shape maketheshape(int row, int col, int type, string color)
    {
        Shape sh;
        
        switch (type)
        {
            case 0:     // square
                sh = new Shape
                {
                    Color = color,
                    Points =
                    [
                        col * Sz, row * Sz,
                        col * Sz + Sz, row * Sz,
                        col * Sz + Sz, row * Sz + Sz,
                        col * Sz, row * Sz + Sz
                    ]
                };
                break;
            case 1:     // top left triangle
                sh = new Shape
                {
                    Color = color,
                    Points =
                    [
                        col * Sz, row * Sz,
                        col * Sz + Sz, row * Sz,
                        col * Sz, row * Sz + Sz
                    ]
                };
                break;
            case 2:      // bottom right triangle
                sh = new Shape
                {
                    Color = color,
                    Points =
                    [
                        col * Sz + Sz, row * Sz,
                        col * Sz + Sz, row * Sz + Sz,
                        col * Sz, row * Sz + Sz
                    ]
                };
                break;
            case 3:
                sh = new Shape();
                break;
            case 4:
                sh = new Shape();
                break;
            default: // Executed if no matches are found
                sh = new Shape();
                Console.WriteLine("Unknown Error");
                break;
        }
        
        return sh;

    }
}