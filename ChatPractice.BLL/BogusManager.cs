using Bogus;
using ChatPractice.DAL.Models;

namespace ChatPractice.BLL;
public static class BogusManager
{
    public static User GenerateRandomUser()
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Age, f => f.Random.Int(18, 80));

        return faker.Generate();
    }
    public static Message GenerateRandomMessage()
    {
        var faker = new Faker();

        var textLength = faker.Random.Int(10, 500);
        var text = faker.Lorem.Paragraph(textLength);

        var message = new Message
        {
            UserId = faker.Random.Long(1, 100),
            Text = text
        };

        return message;
    }
}