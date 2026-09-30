namespace Labs;

class ArrayHelper
{
    public int[]? Split(string s, string separator)
    {
        int[] result = [];
        string part = "";
        s += separator;
        foreach (var c in s)
        {
            if (c.ToString() == separator)
            {
                bool check = int.TryParse(part, out int intPart);
                if (!check)
                {
                    return null;
                }
                result = [.. result.Append(intPart)];
                part = "";
            }
            else
            {
                part += c;
            }
        }
        return result;
    }

    public string ArrayToString(int[] arr)
    {
        string result = "";
        foreach (var i in arr)
        {
            result += $"{i} ";
        }

        return result;
    }
}