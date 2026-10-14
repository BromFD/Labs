namespace Labs.Lab2;

public class Lab2Manager : TaskManager
{
    private Dictionary<string, Action> _tasks;

    public Lab2Manager()
    {
        _tasks = new Dictionary<string, Action>()
        {
            ["13"] = Task13,
            ["22"] = Task22,
            ["23"] = Task23,
            ["32"] = Task32,
            ["49"] = Task49,
            ["57"] = Task57,
        };
    }
    
    public override void Call(int part, int task)
    {
        string taskNumber = part.ToString() + task.ToString();
        if (_tasks.TryGetValue(taskNumber, out Action? action)) 
        { action(); }
        else { Console.WriteLine($"Такой задачи " +
                                 $"нет в менеджере"); }
    }

    public void Task13()
    {
        Console.Write("Введите фамилию: ");
        string? lastName = Console.ReadLine();
        Console.Write("Введите имя: ");
        string? firstName = Console.ReadLine();
        Console.Write("Введите отчество: ");
        string? patronymic  = Console.ReadLine();
        
        Name name = new Name(firstName, lastName, patronymic);
        Console.WriteLine(name);
    }
    
    public void Task22()
    {
        Console.Write("Введите фамилию: ");
        string? lastName = Console.ReadLine();
        Console.Write("Введите имя: ");
        string? firstName = Console.ReadLine();
        Console.Write("Введите отчество: ");
        string? patronymic  = Console.ReadLine();
        int? height = Scanner.NullableInput<int>(
            "Введите рост: ", 
            "Рост должен быть натуральным числом", 
            Scanner.IsNatural);
        Name name  = new Name(firstName, lastName, patronymic);
        HumanWithName human = new HumanWithName(name, height);
        
        Console.WriteLine(human);
    }
    
    public void Task23()
    {
        HumanWithParent[] humans = new HumanWithParent[3];
        ArrayHelper ah = new ArrayHelper();
        for (int i = 0; i < humans.Length; i++)
        {
            Console.WriteLine($"Введите данные человека " +
                              $"{i + 1}: ");
            Console.Write("Введите фамилию: ");
            string? lastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            string? firstName = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string? patronymic  = Console.ReadLine();
            Console.Write("Введите рост: ");
            int? height = Scanner.NullableInput<int>(
                "Введите рост: ", 
                "Рост должен быть натуральным числом", 
                Scanner.IsNatural);
            Name name  = new Name(
                firstName, 
                lastName, 
                patronymic
                );
            HumanWithParent human = new HumanWithParent(
                name, 
                height
                );
            humans[i] = human;
        }
        Console.WriteLine("Введённые люди: ");
        Console.WriteLine(ah.ArrayToString(
            humans, "\n"));
        
        humans[2].Parent = humans[1];
        humans[1].Parent = humans[0];
        Console.WriteLine("Обновлённые люди: ");
        Console.WriteLine(ah.ArrayToString(
            humans, "\n"));
    }
    
    public void Task32()
    {
        PolygonalLine l1 = new PolygonalLine();
        PolygonalLine l2 = new PolygonalLine();
        
        int? n1 = Scanner.NullableInput<int>(
            "Введите количество точек которое " +
            "вы хотите добавить в ломаную 1: ", 
            "Количество точек должно быть " +
            "натуральным числом", 
            Scanner.IsNatural);
        if (n1 == null) { return; }

        for (int i = 0; i < n1; i++)
        {
            Console.Write($"Введите координаты точки {i + 1} " +
                          "через пробел: ");
            string? cords1 = Console.ReadLine();
            Point p1 = new Point(cords1, " ");
            l1.Add(p1);
        }
        
        int? n2 = Scanner.NullableInput<int>(
            "Введите количество точек которое " +
            "вы хотите добавить в ломаную 1: ", 
            "Количество точек должно быть " +
            "натуральным числом", 
            Scanner.IsNatural);
        if (n2 == null) { return; }

        for (int j = 0; j < n2; j++)
        {
            Console.Write($"Введите координаты точки {j + 1} " +
                          "через пробел: ");
            string? cords2 = Console.ReadLine();
            Point p2 = new Point(cords2, " ");
            l2.Add(p2);
        }
        
        Console.WriteLine("\nПолучившиеся ломаные:");
        Console.WriteLine(l1);
        Console.WriteLine(l2);
        
        Console.WriteLine("\nСоединяем ломаные...");
        l1.Connect(l2);
        
        Console.Write("\nУкажите изменённые " +
                      "координаты начала: ");
        string? cords3 = Console.ReadLine();
        Point p3 = new Point(cords3, " ");
        
        Console.WriteLine("\nИзменяем координаты " +
                          "начала у любой ломаной... ");
        l1.Points?[0].X = p3.X;
        l1.Points?[0].Y = p3.Y;
        
        Console.WriteLine("\nНовые ломаные:");
        Console.WriteLine(l1);
        Console.WriteLine(l2);
    }
    
    public void Task49()
    {
        Console.WriteLine("Создаём и выводим пустую ломаную: ");
        PolygonalLine l1 = new PolygonalLine();
        Console.WriteLine(l1);
        
        Console.WriteLine("\nЗаполняем массив точками:");
        int? n1 = Scanner.NullableInput<int>(
            "Введите количество точек которое " +
            "вы хотите добавить в ломаную: ", 
            "Количество точек должно быть " +
            "натуральным числом", 
            Scanner.IsNatural);
        if (n1 == null) { return; }
        Point[] points = new Point[n1.Value];
        for (int i = 0; i < n1; i++)
        {
            Console.Write($"Введите координаты точки {i + 1} " +
                          "через пробел: ");
            string? cords1 = Console.ReadLine();
            Point p1 = new Point(cords1, " ");
            points[i] = p1;
        }
        
        Console.WriteLine("\nСоздаём ломаную из массива...");
        PolygonalLine l2 = new PolygonalLine(points);
        
        Console.WriteLine("Наша ломаная: ");
        Console.WriteLine(l2);
        
    }
    
    public void Task57()
    {
        PolygonalLine l1 = new PolygonalLine();
        
        int? n1 = Scanner.NullableInput<int>(
            "Введите количество точек которое " +
            "вы хотите добавить в ломаную: ", 
            "Количество точек должно быть " +
            "натуральным числом", 
            Scanner.IsNatural);
        if (n1 == null) { return; }

        for (int i = 0; i < n1; i++)
        {
            Console.Write($"Введите координаты точки {i + 1} " +
                          "через пробел: ");
            string? cords1 = Console.ReadLine();
            Point p1 = new Point(cords1, " ");
            l1.Add(p1);
        }
        
        Console.WriteLine("\nПолучившаяся ломаная:");
        Console.WriteLine(l1);
        
        Console.WriteLine("\nДавайте вставим точку в ломаную: ");
        Console.Write("Введите координаты точки " +
                      "через пробел: ");
        string? cords2 = Console.ReadLine();
        Point p2 = new Point(cords2, " ");
        Console.Write("Введите позицию для вставки: ");
        int? pos1 = Scanner.NullableInput<int>(
            "Введите позицию для вставки: ", 
            "Позиция для вставки должна быть " +
            "целым числом");
        if (pos1 == null) { return; }
        l1.Insert(p2, pos1.Value);
        
        Console.WriteLine("\nПолучившаяся ломаная:");
        Console.WriteLine(l1);
        
        Console.WriteLine("\nДавайте вставим массив точек " +
                          "в ломаную: ");
        Console.WriteLine("Заполняем массив точками:");
        int? n3 = Scanner.NullableInput<int>(
            "Введите количество точек которое " +
            "вы хотите добавить в ломаную: ", 
            "Количество точек должно быть " +
            "натуральным числом", 
            Scanner.IsNatural);
        if (n3 == null) { return; }
        Point[] points = new Point[n3.Value];
        for (int j = 0; j < n3; j++)
        {
            Console.Write($"Введите координаты точки {j + 1} " +
                          "через пробел: ");
            string? cords3 = Console.ReadLine();
            Point p3 = new Point(cords3, " ");
            points[j] = p3;
        }
        int? pos2 = Scanner.NullableInput<int>(
            "Введите позицию для вставки: ", 
            "Позиция для вставки должна быть " +
            "целым числом");
        if (pos2 == null) { return; }
        l1.InsertMany(points, pos2.Value);
        
        Console.WriteLine("\nПолучившаяся ломаная:");
        Console.WriteLine(l1);
    }
}