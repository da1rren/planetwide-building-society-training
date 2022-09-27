namespace Planetwide.Basic;

public static class Database
{
    public static List<Person> People { get; private set; } = new();
}

public class Person
{
    public Guid Id { get; set; }

    public string Name { get; }

    public Person(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}

