using System.Linq;
using HotChocolate.Types;

namespace Planetwide.Basic;

public class QueryRoot
{
    public IQueryable<Person> GetPeople() => Database.People.AsQueryable();

    public IQueryable<Car> GetCars() => Database.Cars.AsQueryable();
}

[InterfaceType]
public abstract record Car(string Model);

public record FastCar(string Model, decimal MaxKph) : Car(Model);

public record EfficientCar(string Model, decimal MaxRange) : Car(Model);
