namespace UniversityProcessing.API.Routing;

// ReSharper disable MemberCanBePrivate.Global
public static class NamespaceService
{
    private const string ENDPOINTS = "Endpoints";
    private const string BASE_PREFIX = "api";
    private const string SINGLE_FILE_ENDPOINT = "Endpoint";
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
        var parentParts = GetEndpointsParentParts(type);

        if (type.Name != SINGLE_FILE_ENDPOINT && parentParts.Last() != type.Name)
        {
            parentParts = parentParts.Append(type.Name).ToArray();
        }

        var route = string.Join('/', BASE_PREFIX, string.Join('/', parentParts));
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

        if (type.GenericTypeArguments.Length == 0)
        {
            var parentParts = GetEndpointsParentParts(type);

            if (type.Name != SINGLE_FILE_ENDPOINT && parentParts.Last() != type.Name)
            {
                parentParts = parentParts.Append(type.Name).ToArray();
            }

            var result = string.Concat(BASE_PREFIX, string.Concat(parentParts));
            return result;
        }

        var dataType = new string(type.Name.Where(char.IsLetter).ToArray());
        var typeFullName = type.GenericTypeArguments.First().FullName!;
        var schemaId2 = $"{typeFullName[(typeFullName.IndexOf(ENDPOINTS, StringComparison.InvariantCulture) + ENDPOINTS.Length + 1)..]}.{dataType}";
        return string.Concat(BASE_PREFIX, string.Concat(schemaId2.Split('.')));
    }
}
