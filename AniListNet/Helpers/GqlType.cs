using System.Runtime.Serialization;

namespace AniListNet.Helpers;

internal enum GqlType
{

    [EnumMember(Value = "query")] Query,
    [EnumMember(Value = "mutation")] Mutation

}