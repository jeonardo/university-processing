using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.Domain.UniversityStructure.Enums;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class DiplomaStatusIdConverter
{
    public static DiplomaStatusDto ToDto(DiplomaStatus input)
    {
        return input switch
        {
            DiplomaStatus.Created => DiplomaStatusDto.Created,
            DiplomaStatus.TopicSuggested => DiplomaStatusDto.TopicSuggested,
            DiplomaStatus.TopicFrozen => DiplomaStatusDto.TopicFrozen,
            DiplomaStatus.Finished => DiplomaStatusDto.Finished,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }

    public static DiplomaStatus ToInternal(DiplomaStatusDto input)
    {
        return input switch
        {
            DiplomaStatusDto.Created => DiplomaStatus.Created,
            DiplomaStatusDto.TopicSuggested => DiplomaStatus.TopicSuggested,
            DiplomaStatusDto.TopicFrozen => DiplomaStatus.TopicFrozen,
            DiplomaStatusDto.Finished => DiplomaStatus.Finished,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}
