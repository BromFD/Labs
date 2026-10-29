namespace Labs.Lab3;

public class Lab3Manager : TaskManager
{
    private Dictionary<string, Action> _tasks;

    public Lab3Manager()
    {
        _tasks = new Dictionary<string, Action>()
        {
            ["110"] = Task110,
            ["210"] = Task210,
            ["310"] = Task310,
            ["410"] = Task410,
            ["510"] = Task510,
            ["610"] = Task610,
            ["710"] = Task710,
            ["810"] = Task810,
        };
    }
    
    public override void Call(int part, int task)
    {
        string taskNumber = part.ToString() + task.ToString();
        if (_tasks.TryGetValue(taskNumber, out Action? action))
        {
            action();
        }
        else 
        { 
            Console.WriteLine($"Такой задачи " +
                                 $"нет в менеджере"); 
        }
    }

    public void Task110()
    {
        Console.WriteLine("Вводим матрицу...");
        int rows = Scanner.GenericInput<int>(
            "Введите число строк матрицы: ",
            "Ошибка, число строк матрицы не натурально!",
            Scanner.IsNatural);
        int cols = Scanner.GenericInput<int>(
            "Введите число столбцов матрицы: ",
            "Ошибка, число столбцов матрицы не натурально!",
            Scanner.IsNatural);
        Matrix m1 = new Matrix(rows, cols);
        Console.WriteLine("\nВведённая матрица:\n");
        Console.WriteLine(m1);
        
        Console.WriteLine("Генерируем матрицу типа 2...");
        int n1 = Scanner.GenericInput<int>(
            "Введите размерность матрицы: ",
            "Ошибка, размерность матрицы не натуральна!",
            Scanner.IsNatural);
        Matrix m2 = new Matrix(n1, "chess");
        Console.WriteLine("\nСгенерированая матрица:\n");
        Console.WriteLine(m2);
        
        Console.WriteLine("Генерируем матрицу типа 3...");
        int n2 = Scanner.GenericInput<int>(
            "Введите размерность матрицы: ",
            "Ошибка, размерность матрицы не натуральна!",
            Scanner.IsNatural);
        Matrix m3 = new Matrix(n2, "pattern");
        Console.WriteLine("\nСгенерированая матрица:\n");
        Console.WriteLine(m3);
    }

    public void Task210()
    {
        Console.WriteLine("Вводим матрицу...");
        int rows = Scanner.GenericInput<int>(
            "Введите число строк матрицы: ",
            "Ошибка, число строк матрицы не натурально!",
            Scanner.IsNatural);
        int cols = Scanner.GenericInput<int>(
            "Введите число столбцов матрицы: ",
            "Ошибка, число столбцов матрицы не натурально!",
            Scanner.IsNatural);
        if (rows != cols)
        {
            Console.WriteLine("Число строк должно быть равно " +
                              "числу столбцов для этой задачи!");
            return;
        }
        Matrix m = new Matrix(rows, cols);
        Console.WriteLine("\nВведённая матрица:\n");
        Console.WriteLine(m);
        
        Console.WriteLine($"Количество элементов больше " +
                          $"любого из элементов главной " +
                          $"диагонали: " +
                          $"{m.CountGreaterThenDiagonal()}");
    }

    public void Task310()
    {
        Console.WriteLine("Введите матрицу A");
        int rowsA = Scanner.GenericInput<int>(
            "Введите число строк матрицы: ",
            "Ошибка, число строк матрицы не натурально!",
            Scanner.IsNatural);
        int colsA = Scanner.GenericInput<int>(
            "Введите число столбцов матрицы: ",
            "Ошибка, число столбцов матрицы не натурально!",
            Scanner.IsNatural);
        Matrix A = new Matrix(rowsA, colsA);
        Console.WriteLine("\nВведённая матрица A:\n");
        Console.WriteLine(A);
        
        Console.WriteLine("Введите матрицу B");
        int rowsB = Scanner.GenericInput<int>(
            "Введите число строк матрицы: ",
            "Ошибка, число строк матрицы не натурально!",
            Scanner.IsNatural);
        int colsB = Scanner.GenericInput<int>(
            "Введите число столбцов матрицы: ",
            "Ошибка, число столбцов матрицы не натурально!",
            Scanner.IsNatural);
        Matrix B = new Matrix(rowsB, colsB);
        Console.WriteLine("\nВведённая матрица B:\n");
        Console.WriteLine(B);
        
        Console.WriteLine("Введите матрицу C");
        int rowsC = Scanner.GenericInput<int>(
            "Введите число строк матрицы: ",
            "Ошибка, число строк матрицы не натурально!",
            Scanner.IsNatural);
        int colsC = Scanner.GenericInput<int>(
            "Введите число столбцов матрицы: ",
            "Ошибка, число столбцов матрицы не натурально!",
            Scanner.IsNatural);
        Matrix C = new Matrix(rowsC, colsC);
        Console.WriteLine("\nВведённая матрица C:\n");
        Console.WriteLine(C);
        
        Console.WriteLine("\nРезультат выполнения А*Ст+В*С:\n");
        Matrix? result = A * C.Transpose() + B * C;
        Console.WriteLine(result);
    }

    public void Task410()
    {
        Console.Write("Введите путь по которому " +
                      "будет создан файл: ");
        string? input = Console.ReadLine();
        string creationPath = !string.IsNullOrWhiteSpace(input) 
            ? input  :  
                              "/home/brom/RiderProjects/Labs/" + 
                              "Labs/Lab3/integers.bin";
        Console.WriteLine("Генерируем бинарный файл с числами...");
        FileManager.GenerateBinFile(
            FileManager.GenerateIntBin, 
            1024 * 1024, 
            creationPath
            );
        Console.WriteLine("Считаем удвоенные нечётные числа...");
        int counter = 0;
        int[]? numbers = FileManager.ReadBinFile<int>(
            creationPath);
        if (numbers == null)
        {
            Console.WriteLine("Ошибка чтения файла!");
            return;
        }
        foreach (var number in numbers)
        {
            if (number % 4 == 2)
            {
                counter++;
            }
        }
        Console.WriteLine($"Удвоенных нечётных чисел: {counter}");
    }

    public void Task510()
    {
        Console.Write("Введите путь по которому " +
                      "будет создан файл: ");
        string? input = Console.ReadLine();
        string creationPath = !string.IsNullOrWhiteSpace(input) 
            ? input  :  
                              "/home/brom/RiderProjects/Labs/" + 
                              "Labs/Lab3/toys.bin";
        Console.WriteLine("Генерируем бинарный файл игрушками... ");
        FileManager.GenerateBinFile(
            FileManager.GenerateToy, 
            1024 * 1024, 
            creationPath
        );
        Console.WriteLine("Ищем игрушку с минимальной ценой...");
        Toy[]? toys = FileManager.ReadBinFile<Toy>(
            creationPath);
        if (toys == null)
        {
            Console.WriteLine("Ошибка чтения файла!");
            return;
        }
        int minPrice = toys[0].Price;
        int minIndex = 0;
        for (int i = 0; i < toys.Length; i++)
        {
            if (toys[i].Price < minPrice)
            {
                minPrice = toys[i].Price;
                minIndex = i;
            }
        }
        Console.WriteLine($"Игрушка с наименьшей ценой:\n" +
                          $"{toys[minIndex]}");
    }

    public void Task610()
    {
        Console.Write("Введите путь по которому " +
                      "будет создан файл: ");
        string? input = Console.ReadLine();
        string creationPath = !string.IsNullOrWhiteSpace(input) 
            ? input  :  
                              "/home/brom/RiderProjects/Labs/" + 
                              "Labs/Lab3/integers.txt";
        Console.WriteLine("Генерируем текстовый файл числами... ");
        FileManager.GenerateTextFile(
            FileManager.GenerateIntText, 
            1024 * 1024, 
            creationPath
        );
        Console.WriteLine("Ищем квадрат разности максимального " +
                          "и минимального элементов....");
        int[]? numbers = FileManager.ReadTextFile<int>(
            creationPath);
        if (numbers == null)
        {
            Console.WriteLine("Ошибка чтения файла!");
            return;
        }
        int min = ArrayHelper.Min(numbers);
        int max = ArrayHelper.Max(numbers);
        Console.WriteLine($"Квадрат разности максимального " +
                          $"и минимального элементов равен: " +
                          $"{Math.Pow(max - min, 2)}");
    }

    public void Task710()
    {
        Console.Write("Введите путь по которому " +
                      "будет создан файл: ");
        string? input = Console.ReadLine();
        string creationPath = !string.IsNullOrWhiteSpace(input) 
            ? input  :  
                              "/home/brom/RiderProjects/Labs/" + 
                              "Labs/Lab3/inlineIntegers.txt";
        Console.WriteLine("Генерируем текстовый файл числами... ");
        FileManager.GenerateTextFile(
            FileManager.GenerateIntText, 
            1024 * 1024, 
            creationPath,
            true
        );
        Console.WriteLine("Ищем cумму нечётных элементов...");
        int[]? numbers = FileManager.ReadTextFile<int>(
            creationPath, true);
        if (numbers == null)
        {
            Console.WriteLine("Ошибка чтения файла!");
            return;
        }
        long sum = 0;
        foreach (var number in numbers)
        {
            sum += number % 2 == 1 ? number : 0;
        }
        Console.WriteLine($"Сумма нечётных элементов равна: {sum}");
        
    }

    public void Task810()
    {
        Console.Write("Введите путь по которому " +
                      "будет создан первый файл: ");
        string? input1 = Console.ReadLine();
        string creationPath1 = !string.IsNullOrWhiteSpace(input1) 
            ? input1  :  
                              "/home/brom/RiderProjects/Labs/" + 
                              "Labs/Lab3/strings.txt";
        Console.Write("Введите путь по которому " +
                      "будет создан второй файл: ");
        string? input2 = Console.ReadLine();
        string creationPath2 = !string.IsNullOrWhiteSpace(input2) 
            ? input2  :  
                               "/home/brom/RiderProjects/Labs/" + 
                               "Labs/Lab3/chars.txt";
        Console.WriteLine("Генерируем текстовый файл... ");
        FileManager.GenerateTextFile(
            FileManager.GenerateString!, 
            1024 * 1024, 
            creationPath1
        );
        Console.WriteLine("Считываем файл и заполняем другой " +
                          "файл последними символами строк... ");
        string[]? text = FileManager.ReadTextFile<string>(
            creationPath1);
        if (text == null)
        {
            Console.WriteLine("Ошибка чтения файла!");
            return;
        }
        string[] lastChars = new string[text.Length];
        for (int i = 0; i < lastChars.Length; i++)
        {
            lastChars[i] = text[i].Length > 0 ? 
                text[i][^1].ToString() : "";
        }
        FileManager.WriteTextFile(lastChars, 
            creationPath2);
        
        Console.WriteLine("Сверяем...");
        Console.WriteLine("Первые 10 строк исходного файла:\n");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i + 1}. {text[i]}\n");
        }
        Console.WriteLine("Первые 10 строк нового файла:\n");
        string[]? charsFromFile = FileManager.ReadTextFile<string>(
            creationPath2);
        if (charsFromFile == null)
        {
            Console.WriteLine("Ошибка чтения файла!");
            return;
        }
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i + 1}. {charsFromFile[i]}\n");
        }
    }
}