using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.GenericSubdomain.Attributes;

public sealed class NotDefaultAttribute() : ValidationAttribute(DEFAULT_ERROR_MESSAGE)
{
    private const string DEFAULT_ERROR_MESSAGE = "The {0} field must not have the default value";

    public override bool IsValid(object? value)
    {
        //NotDefault doesn't necessarily mean required
        if (value is null)
        {
            return true;
        }

        var type = value.GetType();

        if (type.IsValueType)
        {
            var defaultValue = Activator.CreateInstance(type);
            return !value.Equals(defaultValue);
        }

        // non-null ref type
        return true;
    }
}
