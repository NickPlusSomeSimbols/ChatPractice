namespace ChatPractice.BLL.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SkipPermissionCheckAttribute : Attribute
{
}
