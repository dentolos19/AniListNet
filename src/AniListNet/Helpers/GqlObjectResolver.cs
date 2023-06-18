using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AniListNet.Helpers;

internal class GqlObjectResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);
        var attribute = member.GetCustomAttribute<GqlSelectionAttribute>();
        if (attribute is null)
            return property;
        property.PropertyName = string.IsNullOrEmpty(attribute.Alias) ? attribute.Name : attribute.Alias;
        property.Writable = true;
        return property;
    }
}