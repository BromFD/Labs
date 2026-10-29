namespace Labs.Lab3;

public class Matrix
{
    private int[,] _values;

    public int[,] Values
    {
        get { return _values; }
        set { _values = value; }
    }

    public Matrix(int[,] values)
    {
        Values = values;
    }
    
    public Matrix(int rows, int cols)
    {
        int[,] values = new int[rows, cols];
        for (int i = 0; i < cols; i++)
        {
            int[] colValues = Scanner.
                GenericArrayInput<int>
                (
                    " ", 
                    $"Введите элементы {i + 1} " +
                    $"столбца через пробел: ", 
                    "Ошибка ввода, массив " +
                    "должен состоять из данных типа int!",
                    rows
                );
            for (int j = 0; j < rows; j++)
            {
                values[j, i] = colValues[j];
            }
        }
        Values = values;
    }

    public Matrix(int n, string mode)
    {
        int[,] values = new int[n, n];
        if (mode == "chess")
        {
            Random rng = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int even = rng.Next(0, 50) * 2;
                    values[i, j] = (i + j) % 2 == 0 ? even : even + 1;
                };
            };
        }
        else if (mode == "pattern")
        {
            int row = 0;
            int col = 0;
            int switcher = 1;
            bool halfwayTrigger = false;
            int number = n * n;
            while (row != n && col != n)
            {
                values[row, col] = number;
                number -= 1;
                if (col == n - 1 || row == n - 1)
                {
                    halfwayTrigger = true;
                }

                if (!halfwayTrigger)
                {
                    if (row == 0)
                    {
                        col += 1;
                        switcher *= -1;
                        values[row, col] = number;
                        number -= 1;
                    }
                    else if (col == 0)
                    {
                        row += 1;
                        switcher *= -1;
                        values[row, col] = number;
                        number -= 1;
                    }
                }
                else
                {
                    if (row == n - 1)
                    {
                        col += 1;
                        switcher *= -1;
                        values[row, col] = number;
                        number -= 1;
                    }
                    else if (col == n - 1)
                    {
                        row += 1;
                        switcher *= -1;
                        values[row, col] = number;
                        number -= 1;
                    }
                }
                row -= switcher;
                col += switcher;
            }
        }
        Values = values;
    }
    
    public int[] Row(int index)
    {
        int[] row = new int[_values.GetLength(1)];
        for (int i = 0; i < _values.GetLength(1); i++)
        {
            row[i] = _values[index, i];
        }
        return row;
    }
    
    public int[] Col(int index)
    {
        int[] col = new int[_values.GetLength(0)];
        for (int i = 0; i < _values.GetLength(0); i++)
        {
            col[i] = _values[i, index];
        }
        return col;
    }
    
    public void UpdateRow(int[] row, int index)
    {
        int rows = _values.GetLength(0);
        int cols = _values.GetLength(1);
        if (row.Length != cols)
        {
            Console.WriteLine(
                "Не удалось вставить ряд, массив " +
                "не равен числу столбцов");
            return;
        }
        if (index > rows - 1)
        {
            Console.WriteLine(
                "Не удалось вставить ряд, индекс " +
                "больше числа рядов");
            return;
        }
        if (index < 0)
        {
            Console.WriteLine(
                "Не удалось вставить ряд, работа с " +
                "отрицательными индексами не поддерживается");
            return;
        }
        for (int i = 0; i < row.Length; i++)
        {
            _values[index, i] = row[i];
        }
    }

    public void UpdateCol(int[] col, int index)
    {
        int rows = _values.GetLength(0);
        int cols = _values.GetLength(1);
        if (col.Length != rows)
        {
            Console.WriteLine(
                "Не удалось вставить столбец, " +
                "массив не равен числу рядов");
            return;
        }
        if (index > cols - 1)
        {
            Console.WriteLine(
                "Не удалось вставить столбец, " +
                "индекс больше числа рядов");
            return;
        }
        if (index < 0)
        {
            Console.WriteLine(
                "Не удалось вставить столбец, работа " +
                "с отрицательными индексами не поддерживается");
            return;
        }
        for (int i = 0; i < col.Length; i++)
        {
            _values[i, index] = col[i];
        }
    }
    
    public Matrix Transpose()
    {
        int rows = _values.GetLength(0);
        int cols = _values.GetLength(1);
        int[,] values = new int[cols, rows];
        Matrix buffer = new Matrix(values);
        for (int i = 0; i < cols; i++)
        {
            buffer.UpdateRow(Col(i), i);
        }
        return buffer;
    }

    public int CountGreaterThenDiagonal()
    {
        int rows = Values.GetLength(0);
        int[] diagonal = new int[rows];
        for (int i = 0; i < rows; i++)
        {
            diagonal[i] = Values[i,i];
        }
        int max = ArrayHelper.Max(diagonal);
        int counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                counter += Values[i, j] > max ? 1 : 0;
            }
        }

        return counter;
    }
    
    public static Matrix? operator +(Matrix? a, Matrix? b)
    {
        if (a == null || b == null)
        {
            Console.WriteLine("Невозможно сложить пустые матрицы");
            return null;
        }
        
        int aRows = a.Values.GetLength(0);
        int bRows = b.Values.GetLength(0);
        int aCols = a.Values.GetLength(1);
        int bCols = b.Values.GetLength(1);
        if (aRows != bRows || aCols != bCols)
        {
            Console.WriteLine("Ошибка сложения, размерности " +
                              "матриц не совпадают!");
            return null;
        }
        int[,] buffer = new int[aRows, aCols]; 
        Matrix result = new Matrix(buffer);
        for (int i = 0; i < aRows; i++)
        {
            result.UpdateRow(ArrayHelper.SumArrays(a.Row(i), 
                b.Row(i))! ,i);
        }
        return result;
    }
    
    public static Matrix? operator *(Matrix? a, Matrix? b)
    {
        if (a == null || b == null)
        {
            Console.WriteLine("Невозможно умножить пустые матрицы");
            return null;
        }
        
        int aRows = a.Values.GetLength(0);
        int bRows = b.Values.GetLength(0);
        int aCols = a.Values.GetLength(1);
        int bCols = b.Values.GetLength(1);
        if (aCols != bRows)
        {
            Console.WriteLine("Ошибка умножения, " +
                              "столбцы первой матрицы " +
                              "не совпадают со строками второй!");
            return null;
        }
        int[,] buffer = new int[aRows, bCols]; 
        Matrix result = new Matrix(buffer);
        Matrix transposedB = b.Transpose();
        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < bCols; j++)
            {
                result.Values[i, j] = ArrayHelper.Sum(
                    ArrayHelper.MultiplyArrays(a.Row(i),
                        transposedB.Row(j))!
                );
            }
        }
        return result;
    }
    
    public override string ToString()
    {
        string matrix = string.Empty;
        for (int i = 0; i < _values.GetLength(0); i++)
        {
            string row = string.Empty;
            for (int j = 0; j < _values.GetLength(1); j++)
            {
                row += _values[i, j] + "\t";
            };
            matrix += row + "\n";
        };
        return matrix;
    }
}