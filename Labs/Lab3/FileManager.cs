using System.Text;
using System.Xml.Serialization;

namespace Labs.Lab3;

public class FileManager
{
    public static void GenerateBinFile<T>(
        Func<int, T[]> generator, int size, string path)
    {
        T[] elements = generator(size);
        try
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(Toy));
            using (BinaryWriter writer =
                   new BinaryWriter(File.Open(path,
                       FileMode.Create)))
            {
                foreach (var element in elements)
                {
                    switch (element)
                    {
                        case int i:
                            writer.Write(i);
                            break;
                        case string s:
                            writer.Write(s);
                            break;
                        case Toy t:
                            using (var ms = new MemoryStream())
                            {
                                serializer.Serialize(ms, t);
                                writer.Write((int)ms.Length);
                                writer.Write(ms.ToArray());
                            }
                            break;
                        case null:
                            writer.Write("");
                            break;
                        default:
                            throw new NotSupportedException(
                                $"Тип {typeof(T).Name} не " +
                                $"поддерживается");
                    }
                }   
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Нет доступа к файлу");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Папка не найдена");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
    }

    public static T[]? ReadBinFile<T>(string path)
    {
        try
        {
            using (BinaryReader reader = new BinaryReader
                       (File.Open(path, FileMode.Open)))
            {
                if (typeof(T) == typeof(int))
                {
                    List<int> elements = [];
                    while (reader.BaseStream.Position < 
                           reader.BaseStream.Length)
                    {
                        int value = reader.ReadInt32();
                        elements.Add(value);
                    }
                    return (T[])(object)(elements.ToArray());
                }
                if (typeof(T) == typeof(string))
                {
                    List<string> elements = [];
                    while (reader.BaseStream.Position < 
                           reader.BaseStream.Length)
                    {
                        string value = reader.ReadString();
                        elements.Add(value);
                    }
                    return (T[])(object)(elements.ToArray());
                }
                if (typeof(T) == typeof(Toy))
                {
                    List<Toy> elements = [];
                    XmlSerializer serializer = new XmlSerializer(typeof(Toy));
                    while (reader.BaseStream.Position < 
                           reader.BaseStream.Length)
                    {
                        int length = reader.ReadInt32();
                        byte[] data = reader.ReadBytes(length);
                        using var ms = new MemoryStream(data);
                        elements.Add(((Toy)serializer.Deserialize(ms)!));
                    }
                    return (T[])(object)(elements.ToArray());
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Нет доступа к файлу");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Папка не найдена");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
        return null;
    }
    
    public static void GenerateTextFile<T>(
        Func<int, T[]> generator,
        int size, 
        string path, 
        bool inlineInt = false
        )
    {
        T[] elements = generator(size);
        try
        {
            using (StreamWriter writer =
                   new StreamWriter(File.Open(path,
                       FileMode.Create)))
            {
                foreach (var element in elements)
                {
                    switch (element)
                    {
                        case int i:
                            if (inlineInt)
                            {
                                writer.Write(i + " ");
                            }
                            else
                            {
                                writer.WriteLine(i);
                            }
                            break;
                        case string s:
                            writer.WriteLine(s);
                            break;
                        case null:
                            writer.Write("");
                            break;
                        default:
                            throw new NotSupportedException(
                                $"Тип {typeof(T).Name} не " +
                                $"поддерживается");
                    }
                }   
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Нет доступа к файлу");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Папка не найдена");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
    }
    
    public static void WriteTextFile<T>(
        T[] content, string path, bool inlineInt = false)
    {
        try
        {
            using (StreamWriter writer =
                   new StreamWriter(File.Open(path,
                       FileMode.Create)))
            {
                foreach (var element in content)
                {
                    switch (element)
                    {
                        case int i:
                            if (inlineInt)
                            {
                                writer.Write(i + " ");
                            }
                            else
                            {
                                writer.WriteLine(i);
                            }
                            break;
                        case string s:
                            writer.WriteLine(s);
                            break;
                        case null:
                            writer.Write("");
                            break;
                        default:
                            throw new NotSupportedException(
                                $"Тип {typeof(T).Name} не " +
                                $"поддерживается");
                    }
                }   
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Нет доступа к файлу");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Папка не найдена");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
    }
    
    public static T[]? ReadTextFile<T>(string path, bool inlineInt = false)
    {
        try
        {
            using (StreamReader reader = new StreamReader
                       (File.Open(path, FileMode.Open)))
            {
                if (typeof(T) == typeof(int))
                {
                    List<int> elements = [];
                    string? line;
                    if (inlineInt)
                    {
                        line = reader.ReadLine();
                        elements =
                            ArrayHelper.Split<int>(line ?? "",
                                " ")?.ToList() ?? [];
                    }
                    else
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            elements.Add(int.Parse(line));
                        } 
                    }
                    return (T[])(object)(elements.ToArray());
                }
                if (typeof(T) == typeof(string))
                {
                    List<string> elements = [];
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        elements.Add(line);
                    }
                    return (T[])(object)(elements.ToArray());
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Нет доступа к файлу");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Папка не найдена");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
        return null;
    }
    
    public static int[] GenerateIntBin(int size)
    {
        int[] integers = new int[size / 4];
        Random rng = new Random();
        for (int i = 0; i < size / 4; i++)
        {
            integers[i] = rng.Next();
        }
        return integers;
    }

    public static int[] GenerateIntText(int size)
    {
        var rng = new Random();
        var list = new List<int>();
        int total = 0;

        while (total < size)
        {
            int value = rng.Next();
            list.Add(value);
            total += value.ToString().Length + Environment.NewLine.Length;
        }
        return list.ToArray();
    }

    public static string[]? GenerateString(int size)
    {
        string path = "/home/brom/RiderProjects/Labs/" +
                      "Labs/Lab3/warandpeace.txt";
        try
        {
            int fileSize = (int)(new FileInfo(path).Length);
            if (size > fileSize)
            {
                Console.WriteLine("Генерация файла такого " +
                                  "размера не поддерживается!");
                return null;
            }
            Random rng = new Random();
            int start = rng.Next(0, fileSize - size + 1);
            using (var reader = new BinaryReader(
                       File.Open(path, FileMode.Open)))
            {
                reader.BaseStream.Seek(start, SeekOrigin.Begin);   
                byte[] bytes = reader.ReadBytes(size);
                string text = Encoding.UTF8.GetString(bytes);
                return [text];
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Нет доступа к файлу");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Папка не найдена");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
        return null;
    }

    public static Toy[] GenerateToy(int size)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Toy));
        List<Toy> toys = new List<Toy>();
        int total = 0;
        while (total < size)
        {
            using (var ms = new MemoryStream())
            {
                Toy toy = new Toy();
                serializer.Serialize(ms, toy);
                total += 4 + (int)ms.Length;
                toys.Add(toy);
            }
        }
        return toys.ToArray();
    }
}