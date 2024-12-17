namespace UniversityProcessing.GenericSubdomain.Namespace;

// ReSharper disable MemberCanBePrivate.Global
public static class NamespaceService
{
    public static string[] GetParentParts(Type type)
    {
        var @namespace = type.Namespace;

        if (@namespace is null)
        {
            throw new ArgumentNullException();
        }

        return @namespace.Split('.');
    }

    public static string[] GetEndpointsParentParts(Type type)
    {
        var parentParts = GetParentParts(type);

        if (parentParts.Length == 0)
        {
            throw new InvalidOperationException("Type is not in the expected namespace");
        }

        const string endpoints = "Endpoints";
        var endpointsIndex = Array.IndexOf(parentParts, endpoints);

        if (endpointsIndex == -1)
        {
            throw new InvalidOperationException("Type is not in the expected namespace");
        }

        var skipCount = endpointsIndex + 1;
        var parts = parentParts
            .Skip(skipCount)
            .ToArray();

        return parts;
    }

    public static string GetEndpointRoute(Type type)
    {
        const string basePrefix = "api/v1";
        var parentParts = GetEndpointsParentParts(type);
        var route = string.Join('/', basePrefix, string.Join('/', parentParts));
        return route;
    }
}
