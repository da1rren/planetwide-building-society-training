using HotChocolate.Subscriptions;

namespace Planetwide.Basic;

public class MutationRoot
{
    public async Task<Person> AddPerson([Service] ITopicEventSender sender, string name)
    {
        var person = new Person(name);
        Database.People.Add(person);
        await sender.SendAsync(nameof(SubscriptionRoot.PersonAdded), person);
        return person;
    }
}