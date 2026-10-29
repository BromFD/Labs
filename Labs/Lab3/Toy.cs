namespace Labs.Lab3;

public struct Toy
{
    private string _name;
    private int _price;
    private int _minAge;
    private int _maxAge;
    
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Price
    {
        get { return _price; }
        set { _price = value; }
    }
    public int MinAge
    {
        get { return _minAge; }
        set { _minAge = value; }
    }
    public int MaxAge
    {
        get { return _maxAge; }
        set { _maxAge = value; }
    }

    public Toy()
    {
        string[] toys =
        [
            "Мишка", "Кукла", "Машинка", "Конструктор", "Пазл",
            "Мяч", "Юла", "Робот", "Паровозик", "Кубики",
            "Пирамидка", "Погремушка", "Заводной зайчик", "Лошадка-качалка", "Самолётик",
            "Барабан", "Дудочка", "Плюшевый слон", "Набор доктора", "Пластилин",
            "Мозаика", "Скакалка", "Волчок", "Матрёшка", "Кукольный домик",
            "Вертолёт", "Динозавр", "Танк", "Йо-йо", "Воздушный змей"
        ];
        Random rng = new Random();
        
        Name = toys[rng.Next(toys.Length)];
        Price = rng.Next(100, 5000);
        MinAge = rng.Next(0, 18);
        MaxAge = rng.Next(MinAge, 19);
    }

    public override string ToString()
    {
        return $"Игрушка\n" +
               $"Название: {Name}\n" +
               $"Цена: {Price}\n" +
               $"Для детей от {MinAge} до {MaxAge} лет";
    }
}