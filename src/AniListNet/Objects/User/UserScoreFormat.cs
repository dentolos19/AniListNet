using System.Runtime.Serialization;

namespace AniListNet.Objects;

public enum UserScoreFormat
{
    /// <summary>
    /// An integer from 0 to 100.
    /// </summary>
    [EnumMember(Value = "POINT_100")] Point100,

    /// <summary>
    /// A float from 0 to 10 with 1 decimal place.
    /// </summary>
    [EnumMember(Value = "POINT_10_DECIMAL")] Point10Decimal,

    /// <summary>
    /// An integer from 0 to 10.
    /// </summary>
    [EnumMember(Value = "POINT_10")] Point10,

    /// <summary>
    /// An integer from 0 to 5.
    /// </summary>
    /// <remarks>Should be represented in stars.</remarks>
    [EnumMember(Value = "POINT_5")] Point5,

    /// <summary>
    /// An integer from 0 to 3.
    /// </summary>
    /// <remarks>Should be represented in smileys.<br/> 0 = No Score<br/> 1 => :(<br/> 2 => :|<br/> 3 => :)</remarks>
    [EnumMember(Value = "POINT_3")] Point3
}