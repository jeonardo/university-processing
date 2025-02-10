namespace UniversityProcessing.GenericSubdomain.Routing;

// ReSharper disable MemberCanBePrivate.Global
public static class NamespaceService
{
    private const string ENDPOINTS = "Endpoints";

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

        var endpointsIndex = Array.IndexOf(parentParts, ENDPOINTS);

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
        const string basePrefix = "api";
        var parentParts = GetEndpointsParentParts(type);
        var route = string.Join('/', basePrefix, string.Join('/', parentParts));
        return route;
    }

    public static string GetEndpointTags(Type type)
    {
        return GetEndpointsParentParts(type).FirstOrDefault() ?? string.Empty;
    }

    public static string GetDtoSchemaId(Type type)
    {
        var route = string.Join('.', type.FullName);

        var genericSubdomainRoot = typeof(NamespaceService).Assembly.GetName().Name!;

        if (!route.Contains(genericSubdomainRoot))
        {
            var schemaId = route[(route.IndexOf(ENDPOINTS, StringComparison.InvariantCulture) + ENDPOINTS.Length + 1)..];

            if (schemaId.EndsWith("RequestDto"))
            {
                schemaId = $"{schemaId[..schemaId.LastIndexOf('.')]}.Request";
            }
            else if (schemaId.EndsWith("ResponseDto"))
            {
                schemaId = $"{schemaId[..schemaId.LastIndexOf('.')]}.Response";
            }
            else if (schemaId.EndsWith("Dto"))
            {
                schemaId = $"{schemaId[..schemaId.LastIndexOf("Dto", StringComparison.InvariantCulture)]}";
            }

            return schemaId;
        }

        var dataType = new string(type.Name.Where(char.IsLetter).ToArray());

        if (type.GenericTypeArguments.Length == 0)
        {
            return dataType;
        }

        var typeFullName = type.GenericTypeArguments.First().FullName!;
        var schemaId2 = $"{typeFullName[(typeFullName.IndexOf(ENDPOINTS, StringComparison.InvariantCulture) + ENDPOINTS.Length + 1)..]}.{dataType}";
        return schemaId2.Replace("Dto.", ".");
    }
}
