using System.Collections.Immutable;

namespace UniversityProcessing.API;

public static class Policies
{
    public static readonly ImmutableDictionary<string, string> PermissionsByPolicy = new Dictionary<string, string>().ToImmutableDictionary();
}
