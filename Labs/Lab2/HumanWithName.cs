namespace Labs.Lab2;

public class HumanWithName
{
    private Name? _name;

    public Name? Name
    {
        get { return _name; }
        set { _name = value; }

    }
    private int? _height;
    public int? Height
    {
        get { return _height; }
        set
        {
            if (value == null)
            {
                _height = null;
                return;
            }
            if (value > 0) { _height = value; }
            else
            {
                _height = null;
                Console.WriteLine("Не удалось присвоить рост");
            }
        }
    }
    
    public override string ToString()
    {
        return $"Человек" +
               (!_name?.IsEmpty() ?? false 
                   ? $"\nИмя: {_name}" : "") +
               (_height != null ? $"\nРост: {_height}" : "");
    }
    
    public HumanWithName(
        Name? name = null,
        int? height = null
    ) 
    {
        Name = name;
        Height = height;
    }
}
