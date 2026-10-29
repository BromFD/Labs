namespace Labs.Lab2;

public class Name
{
    private string? _firstName;
    private string? _lastName;
    private string? _patronymic;
    
    public string? FirstName
    {
        get { return _firstName; }
        set 
        { 
            _firstName = !string.IsNullOrEmpty(value) 
            ? value : null; 
        }
    }
    public string? LastName
    {
        get { return _lastName; }
        set
        { 
            _lastName = !string.IsNullOrEmpty(value) 
            ? value : null; 
        }
    }
    public string? Patronymic
    {
        get { return _patronymic; }
        set 
        { 
            _patronymic = !string.IsNullOrEmpty(value) 
            ? value : null; 
        }
    }
    
    public Name(
        string? firstName = null, 
        string? lastName = null,
        string? patronymic = null
    ) 
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }
    
    public bool IsEmpty()
    {
        return string.IsNullOrEmpty(_firstName) 
               && string.IsNullOrEmpty(_lastName) 
               && string.IsNullOrEmpty(_patronymic);
    }
    
    public override string ToString()
    {
        return ((_lastName != null ? $"{_lastName} " : "") + 
                (_firstName != null ? $"{_firstName} " : "") + 
                (_patronymic!= null ? $"{_patronymic} " : "")
            ).TrimEnd();
    }
}