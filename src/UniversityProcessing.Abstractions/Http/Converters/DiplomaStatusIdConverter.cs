using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.Domain.UniversityStructure.Enums;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class DiplomaStatusIdConverter
{
    public static DiplomaStatusDto ToDto(DiplomaStatusId input)
    {
        return input switch
        {
            DiplomaStatusId.Created => DiplomaStatusDto.Created,
            DiplomaStatusId.TopicSuggested => DiplomaStatusDto.TopicSuggested,
            DiplomaStatusId.TopicFrozen => DiplomaStatusDto.TopicFrozen,
            DiplomaStatusId.Finished => DiplomaStatusDto.Finished,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }

    public static DiplomaStatusId ToInternal(DiplomaStatusDto input)
    {
        return input switch
        {
            DiplomaStatusDto.Created => DiplomaStatusId.Created,
            DiplomaStatusDto.TopicSuggested => DiplomaStatusId.TopicSuggested,
            DiplomaStatusDto.TopicFrozen => DiplomaStatusId.TopicFrozen,
            DiplomaStatusDto.Finished => DiplomaStatusId.Finished,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}
