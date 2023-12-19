using System.Drawing;

namespace GameFramework.Tiles;

public static class ColorConverter
{
    public static int ConvertColorToTileId(Color color)
    {
        if (color == Color.Black)
        {
            return 0;
        }
        
        if (color == Color.White)
        {
            return 1;
        }
        
        if (color == Color.Red)
        {
            return 2;
        }
        
        if (color == Color.Green)
        {
            return 3;
        }
        
        if (color == Color.Blue)
        {
            return 4;
        }
        
        if (color == Color.Yellow)
        {
            return 5;
        }
        
        if (color == Color.Purple)
        {
            return 6;
        }
        
        if (color == Color.Orange)
        {
            return 7;
        }
        
        if (color == Color.Brown)
        {
            return 8;
        }
        
        if (color == Color.Gray)
        {
            return 9;
        }
        
        throw new ArgumentException("Color is not supported");
    }
    
    public static Color ConvertTileIdToColor(int id)
    {
        return id switch
        {
            0 => Color.Black,
            1 => Color.White,
            2 => Color.Red,
            3 => Color.Green,
            4 => Color.Blue,
            5 => Color.Yellow,
            6 => Color.Purple,
            7 => Color.Orange,
            8 => Color.Brown,
            9 => Color.Gray,
            _ => throw new ArgumentException("Id is not supported")
        };
    }
}