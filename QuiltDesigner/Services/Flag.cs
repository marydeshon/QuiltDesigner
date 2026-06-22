using Microsoft.EntityFrameworkCore.Query;
using QuiltDesigner.Models;

namespace QuiltDesigner.Services;

public class Flag  : IPatternSevice
{
    enum HSTType
    {
        TLBR,    // 0
        TRBL,    // 1
    }
    enum TriType
    {
        SQ,
        TL, 
        BR,
        TR,
        BL
    }
    const string Gray = "#b9b9b9";
    const string White = "#f7f7f7";
    const string Black = "#070707";
    const string Yellow = "#fadc55";
    const string Purple = "#9c5b86";
    const string Red = "#e64555";
    const string Orange = "#f98c4b";
    const string Pink = "#ee8ba8";
    const string Green = "#b2bd47";
    
    readonly(int row, int col)[][] _whitesquares = [
        [(0,0),(0,1),(0,2),(0,3),(0,4),(0,5),(0,6),(0,7),(0,8),(0,9),(0,10),(0,11),(0,12),(0,13)],
        [(1,11),(1,12), (1,13)]
    ];
    readonly (int row, int col)[][] _graysquares = [
        [(1,1),(1,2),(1,3)],
        [(2,0),(2,1),(2,2),(2,10)],
        [(3,0),(3,2),(3,10),(3,11)],
    ];
    readonly (int row, int col)[][] _yellowsquares = [
        [(1,4),(1,9), (2,4),(2,9),(3,4),(3,9),(4,4),(4,9)],
    ];
    readonly (int row, int col)[][] _purplesquares = [
        [(1,5),(3,6), (4,8)],
    ];
    readonly (int row, int col)[][] _redsquares = [
        [(1,6),(2,8), (4,5), (4,7)],
    ];
    readonly (int row, int col)[][] _orangesquares = [
        [(1,7),(2,5), (3,7)],
    ];
    readonly (int row, int col)[][] _pinksquares = [
        [(1,8),(2,6), (4,6)],
    ];
    readonly (int row, int col)[][] _greensquares = [
        [(2,7),(3,5), (3,8)],
    ];
    
    readonly (int row, int col, int type, string color1, string color2)[][] _hsts = [
        [(1,0,0, White, Gray)]
    ];
    
    readonly (int row, int col, int type, string color)[][] _grid = [
        //[(1,0,1, White), (1,0,2, Gray), (1,10,3, White), (1,10,4,Gray)],
        [(1,10,3, White), (1,10,4,Gray)],
        [(2,3,1, Black), (2,3,2, Gray)],
        [(3,0,0, Gray), (3,1,1, Black), (3,1,2, Gray)],
        [(4,0,0, Gray)]
    ];
    
    int Sz = 50;
    List<Shape> shapes = new List<Shape>();

    public List<Shape> GetAll()
    {
        FillSquares(_whitesquares, White);
        FillSquares(_graysquares, Gray);
        FillSquares(_yellowsquares, Yellow);
        FillSquares(_purplesquares, Purple);
        FillSquares(_redsquares, Red);
        FillSquares(_orangesquares, Orange);
        FillSquares(_pinksquares, Pink);
        FillSquares(_greensquares, Green);
        
        foreach (var row in _grid)
        {
            foreach (var item in row)
            {
                shapes.Add(MakeShape(item.row, item.col, (TriType)item.type, item.color));
            }
        }
        
        foreach (var row in _hsts)
        {
            foreach (var item in row)
            {
                MakeHST(item.row, item.col, (HSTType)item.type, item.color1, item.color2);
            }
        }
        return shapes;
    }

    void FillSquares((int row, int col)[][] squares, string color)
    {
        foreach (var row in  squares)
        {
            foreach (var item in row)
            {
                shapes.Add(MakeShape(item.row, item.col, 0, color));
            }
        }
    }
    
    Shape MakeShape(int row, int col, TriType type, string color)
    {
        Shape sh;
        
        switch (type)
        {
            case TriType.SQ:     // square
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
            case TriType.TL:     // top left triangle
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
            case TriType.BR:      // bottom right triangle
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
            case TriType.TR:     // top right triangle
                sh = new Shape
                {
                    Color = color,
                    Points =
                    [
                        col * Sz, row * Sz,
                        col * Sz+Sz, row * Sz,
                        col * Sz+Sz, row * Sz+Sz
                    ]
                };
                break;
            case TriType.BL:     // bottom left triangle
                sh = new Shape
                {
                    Color = color,
                    Points =
                    [
                        col * Sz, row * Sz,
                        col * Sz, row * Sz +Sz,
                        col * Sz+Sz, row * Sz + Sz
                    ]
                };
                break;
            default: // Executed if no matches are found
                sh = new Shape();
                Console.WriteLine("Unknown Error");
                break;
        }
        
        return sh;
    }

    void MakeHST(int row, int col, HSTType type, string color1, string color2)
    {
        Shape sh;
        
        switch (type)
        {
            case HSTType.TLBR:
                shapes.Add(MakeShape(row, col, TriType.TL, color1));
                shapes.Add(MakeShape(row, col, TriType.BR, color2));
                break;
            case HSTType.TRBL:
                shapes.Add(MakeShape(row, col, TriType.TR, color1));
                shapes.Add(MakeShape(row, col, TriType.BL, color2));
                break;
            default: // Executed if no matches are found
                sh = new Shape();
                Console.WriteLine("Unknown Error");
                break;
        }
        
    }
}