namespace Labs;
public static class Scanner
{
    public static bool Nothing<T>(T value) { return true; }
    public static bool NothingForArray<T>(T[] value) { return true; }
    
    public static T GenericInput<T>(
        string message, 
        string errorMessage,
        Func<T, bool>? condition = null
        )
        where T : struct, IParsable<T>
    {
        condition ??= Nothing;
        string input;
        T? converted;
        bool check;
        do
        {
            Console.Write(message);
            input = Console.ReadLine() ?? "";
            converted = T.TryParse(
                input, null, out T result
                ) ? result : null;
            check = converted == null 
                    || !condition(converted.Value);
            if (check)
            {
                Console.WriteLine (errorMessage);
            }
        } while (check);
        return converted!.Value;
    }

    public static T[] GenericArrayInput<T>(
        string separator,
        string message,
        string errorMessage,
        int? length = null,
        Func<T[], bool>? condition = null
        )
        where T : struct, IParsable<T>
    {
        condition ??= NothingForArray;
        string input;
        T[]? array;
        bool check;
        do
        {
            Console.Write(message);
            input = Console.ReadLine() ?? "";
            array = ArrayHelper.Split<T>(input, separator);
            check = array == null || !condition(array);
            if (check)
            {
                Console.WriteLine (errorMessage);
                continue;
            }
            if (length != null && array?.Length != length)
            {
                check = true;
                Console.WriteLine("Ошибка, длина " +
                                  "введённого массива " +
                                  "не соответствует указанной " +
                                  "длине!");
            }
        } while (check);
        return array!;
    }
    
    public static T? NullableInput<T>(
        string message, 
        string errorMessage,
        Func<T, bool>? condition = null
    )
        where T : struct, IParsable<T>
    {
        condition ??= Nothing;
        string? input;
        T? converted;
        bool check;
        Console.Write(message);
        input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }
        converted = T.TryParse(
            input, null, out T result
        ) ? result : null;
        check = converted == null || !condition(converted.Value);
        if (check)
        {
            Console.WriteLine (errorMessage);
        }
        return converted;
    }
    
    public static bool IsNatural(int value)
    {
        return value > 0;
    }
}