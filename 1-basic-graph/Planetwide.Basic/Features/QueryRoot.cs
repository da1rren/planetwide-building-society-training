using System.Linq;

namespace Planetwide.Basic;

public class QueryRoot
{
    public IQueryable<Person> GetPeople() => Database.People.AsQueryable();
}

