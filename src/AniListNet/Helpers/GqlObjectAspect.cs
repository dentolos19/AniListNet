using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;

namespace AniListNet.Helpers;

[MulticastAttributeUsage(MulticastTargets.Property | MulticastTargets.Field)]
public class GqlObjectAspect : TypeLevelAspect
{

    public override void CompileTimeInitialize(Type targetType, AspectInfo aspectInfo)
    {
        foreach (var property in targetType.GetProperties())
        {
            if (property.GetCustomAttribute<MyAttribute>() != null)
            {
                var additionalAttribute = new AdditionalAttribute();
                property.att(additionalAttribute);
            }
        }
        foreach (var field in targetType.GetFields())
        {
            if (field.GetCustomAttribute<MyAttribute>() != null)
            {
                var additionalAttribute = new AdditionalAttribute();
                field.SetCustomAttribute(additionalAttribute);
            }
        }
    }
}