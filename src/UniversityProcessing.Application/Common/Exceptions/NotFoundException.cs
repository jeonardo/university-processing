namespace UniversityProcessing.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entity, object key)
        : base($"Сущность '{entity}' с идентификатором {key} не найдена")
    {
    }
}
