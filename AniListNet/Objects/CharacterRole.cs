using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum CharacterRole
{

    [EnumMember(Value = "Main")] Main,
    [EnumMember(Value = "SUPPORTING")] Supporting,
    [EnumMember(Value = "BACKGROUND")] Background

}