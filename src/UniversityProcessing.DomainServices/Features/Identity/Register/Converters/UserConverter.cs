using UniversityProcessing.Domain;
using UniversityProcessing.DomainServices.Features.Identity.Register.Contracts;

namespace UniversityProcessing.DomainServices.Features.Identity.Register.Converters;

internal static class UserConverter
{
    public static User ToDomain(RegisterCommandRequest input)
    {
        return new User();
    }
}