using BelvedereFood.DAL;
using ChatPractice.DAL;

namespace ChatPractice.BLL.Services;

public class ConfigurationService : IConfigurationService
{
    public long? UserId { get; set; }
}