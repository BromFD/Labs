namespace Labs.Lab2;

public class PolygonalLine
{
    private Point[]? _points;
    public Point[]? Points
    {
        get { return _points; }
        set
        {
            _points = value;
        }
    }
    private double? _length;
    public double? Length
    {
        get
        {
            Length = GetLength();
            return _length;
        }
        set { _length = value; }
    }

    public override string ToString()
    {
        return $"Ломаная: [ {(_points != null 
            ? string.Join(", ", _points) : "Пусто")} ] " +
               $"\nДлина: {(Length != null ? Length : 0)}";
    }

    public PolygonalLine(Point[]? points = null)
    {
        Points = points;
    }

    public void Connect(PolygonalLine other)
    {
        if (other?.Points == null || Points == null) { return; }
        
        other.Points[0] = Points[0];
        other.Points[^1] = Points[^1];
    }

    public void Add(Point point)
    {
        if (Points == null) { Points = []; }
        ArrayHelper ah = new ArrayHelper();
        Points = ah.Insert(Points, -1 ,point);
    }
    
    public void Insert(Point point, int index)
    {
        if (Points == null) { Points = []; }
        ArrayHelper ah = new ArrayHelper();
        Points = ah.Insert(Points, index ,point);
    }

    public void InsertMany(Point[] points, int index)
    {
        if (Points == null) { Points = []; }
        ArrayHelper ah = new ArrayHelper();
        Points = ah.InsertMany(Points, index, points);
    }
    
    private double? GetLength()
    {
        if (Points == null)
        {
            /*
            Console.WriteLine("У ломаной нет точек, " +
                              "посчитать длину нельзя");
            */
            return null;
        }
        double length = 0;
        for (int i = 1; i < Points.Length; i++)
        {
            double? x1, x2, y1, y2;
            x1 = Points[i - 1].X;
            x2 = Points[i].X;
            y1 = Points[i - 1].Y;
            y2 = Points[i].Y;
            if (x1 == null || x2 == null ||
                y1 == null || y2 == null)
            {
                Console.WriteLine("Координата точки не " +
                                  "указана, " +
                                  "посчитать длину нельзя");
                return null;
            }
            length += Math.Sqrt(
                (Math.Pow(double.Abs(x1.Value - x2.Value), 2) 
                 + Math.Pow(double.Abs(y1.Value - y2.Value), 2)));
        }

        return length;
    }
}