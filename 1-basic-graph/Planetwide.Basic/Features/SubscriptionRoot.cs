using HotChocolate.Types;

namespace Planetwide.Basic;

public class SubscriptionRoot
{
    [Subscribe]
    public Person PersonAdded([EventMessage] Person person) => person;
}

