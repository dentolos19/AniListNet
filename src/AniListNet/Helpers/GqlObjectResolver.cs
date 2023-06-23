using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AniListNet.Helpers;

internal class GqlObjectResolver : DefaultContractResolver
{
    protected override List<MemberInfo> GetSerializableMembers(Type objectType)
    {
        var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        var properties = objectType.GetProperties(flags).Where(property => property.CanWrite).Cast<MemberInfo>();
        var fields = objectType.GetFields(flags).Cast<MemberInfo>();
        return
            objectType.BaseType is null ?
                properties.Concat(fields).ToList() :
                properties.Concat(fields).Concat(GetSerializableMembers(objectType.BaseType)).ToList();
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);
        var attribute = member.GetCustomAttribute<GqlSelectionAttribute>();
        if (attribute is null)
        {
            property.Ignored = true;
            return property;
        }
        property.PropertyName = string.IsNullOrEmpty(attribute.Alias) ? attribute.Name : attribute.Alias;
        property.Writable = true;
        return property;
    }
}