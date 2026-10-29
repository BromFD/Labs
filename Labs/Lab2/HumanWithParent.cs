namespace Labs.Lab2;

public class HumanWithParent : HumanWithName
{
    private HumanWithParent? _parent;
    public HumanWithParent? Parent
    {
        get { return  _parent; }
        set
        {
            _parent = value;
            if (Name?.LastName == null)
            {
                if (Name == null)
                {
                    Name = new Name();
                }
                Name.LastName = value?.Name?.LastName;
            };
            if (Name?.Patronymic == null)
            {
                if (Name == null)
                {
                    Name = new Name();
                }
                Name.Patronymic = value?.Name?.FirstName != null 
                    ? value?.Name?.FirstName + "ович" : null;
            };
        }
    }
    
    public HumanWithParent(Name? name = null, 
        int? height = null, 
        HumanWithParent? parent = null
        ) : base(name, height)
    {
        Parent = parent;
    }
    
    public override string ToString()
    {
        return base.ToString() +
               (_parent != null && _parent.Name != null 
                   ? $"\nРодитель: {_parent.Name}" : "");
    }
}