using System.Numerics;

namespace Labs;

class ArrayHelper
{
    public static bool AddToFirstEmpty<T>(T[] arr, T item)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(arr[i], default))
            {
                arr[i] = item;
                return true;
            }
        }
        return false; 
    }
    
    public static T[]? Split<T>(string s, string separator)
        where T : IParsable<T>
    {
        T[] result = [];
        string part = "";

        s += separator;

        foreach (var c in s)
        {
            if (c.ToString() == separator)
            {
                if (T.TryParse(part, null, out T? value))
                {
                    result = [.. result, value];
                }
                else if (part == separator || part == string.Empty)
                {
                    continue;
                }
                else
                {
                    return null;
                }
                part = "";
            }
            else
            {
                part += c;
            }
        }
        if (result.Length == 0)
        {
            return null;
        }
        return result;
    }
    
    public static string ArrayToString<T>(T[] arr, string separator)
    {
        string result = "";
        foreach (var i in arr)
        {
            result += $"{i}{separator}";
        }

        return result;
    }
    
    public static T[] Insert<T>(T[] arr, int index, T item)
    {
        T[] result = new T[arr.Length + 1];
        if (index >= result.Length)
        {
            Console.WriteLine("Вставка на индекс превышающий " +
                              "длину списка запрещена");
            return arr;
        }
        index = index >= 0 ? index : result.Length + index;
        
        for (int i = 0; i < result.Length; i++)
        {
            if (i < index)
            {
                result[i] = arr[i];
            }
            else if (i == index)
            {
                result[i] = item;
            }
            else
            {
                result[i] = arr[i - 1];
            }
        }
        return result;
    }
    
    public static T[] InsertMany<T>(T[] arr1, int index, T[] arr2)
    {
        T[] result = new T[arr1.Length + arr2.Length];
        if (index > arr1.Length)
        {
            Console.WriteLine("Вставка на индекс превышающий " +
                              "длину списка запрещена");
            return arr1;
        }
        index = index >= 0 ? index : arr1.Length + 1 + index;
        
        for (int i = 0; i < result.Length; i++)
        {
            if (i < index)
            {
                result[i] = arr1[i];
            }
            else if (i < index + arr2.Length)
            {
                result[i] = arr2[i - index];
            }
            else
            {
                result[i] = arr1[i - arr2.Length];
            }
        }
        return result;
    }

    public static T Max<T>(T[] array)
        where T : IComparable<T>
    {
        T max = array[0];
        foreach (var el in array)
        {
            max = el.CompareTo(max) > 0 ? el : max;
        }
        return max;
    }
    
    public static T Min<T>(T[] array)
        where T : IComparable<T>
    {
        T min = array[0];
        foreach (var el in array)
        {
            min = el.CompareTo(min) < 0 ? el : min;
        }
        return min;
    }

    public static T[]? SumArrays<T>(T[] arr1, T[] arr2)
    where  T : IAdditionOperators<T,T,T>
    {
        if (arr1.Length != arr2.Length)
        {
            Console.WriteLine("Сложение массивов разных длин, " +
                              "не поддерживается!");
            return null;
        }
        T[] result = new T[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = arr1[i] + arr2[i];
        }
        return result;
    }
    
    public static T[]? MultiplyArrays<T>(T[] arr1, T[] arr2)
        where  T : IMultiplyOperators<T,T,T>
    {
        if (arr1.Length != arr2.Length)
        {
            Console.WriteLine("Умножение массивов разных длин, " +
                              "не поддерживается!");
            return null;
        }
        T[] result = new T[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = arr1[i] * arr2[i];
        }
        return result;
    }

    public static T? Sum<T>(T[] arr)
        where  T : IAdditionOperators<T,T,T>
    {
        T sum = default(T)!;
        foreach (var el in arr)
        {
            sum += el;
        }
        return sum;
    }
}