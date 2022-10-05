namespace Planetwide.Basic;

public static class Database
{
    public static List<Person> People { get; private set; } = new();

    public static List<Car> Cars { get; private set; } = new();

    static Database()
    {
        People.Add(new Person("Darren"));
        Cars.Add(new FastCar("Volvo", 180));
        Cars.Add(new EfficientCar("Bmw", 40));
    }
}

public class Person
{
    public string Name { get; }

    public Person(string name)
    {
        Name = name;
    }
}

