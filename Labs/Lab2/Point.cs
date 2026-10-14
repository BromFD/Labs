namespace Labs.Lab2;

public class Point
{
    private double? _x;
    private double? _y;
    
    public double? X
    {
        get { return _x; }
        set { _x = value; }
    }
    public double? Y
    {
        get { return _y; }
        set { _y = value; }
    }
    
    public Point(
        double? x = null, 
        double? y = null
        )
    {
        X = x;
        Y = y;
    }

    public Point(string? cords, string? separator)
    {
        if (cords == null || separator == null)
        {
            Console.WriteLine("Не удалось " +
                              "создать точку из строки");
            X = null;
            Y = null;
            return;
        }
        ArrayHelper ah = new ArrayHelper();
        double[]? arrCords = ah.Split<double>(cords, separator);
        if (arrCords == null || arrCords.Length != 2)
        { 
            Console.WriteLine("Не удалось " +
                              "создать точку из строки");
            X = null;
            Y = null;
            return;
        }
        X = arrCords[0];
        Y = arrCords[^1];
    }
    
    public override string ToString()
    {
        return  "( " + (_x == null ? "Неизвестно" : _x.ToString()) + 
                " : " + 
                (_y == null ? "Неизвестно" :  _y.ToString()) + " )";
    }
}