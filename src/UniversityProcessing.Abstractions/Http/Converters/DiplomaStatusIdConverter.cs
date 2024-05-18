using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.Domain.UniversityStructure.Enums;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class DiplomaStatusIdConverter
{
    public static DiplomaStatusIdDto ToDto(DiplomaStatusId input)
    {
        return input switch
        {
            DiplomaStatusId.Created => DiplomaStatusIdDto.Created,
            DiplomaStatusId.TopicSuggested => DiplomaStatusIdDto.TopicSuggested,
            DiplomaStatusId.TopicFrozen => DiplomaStatusIdDto.TopicFrozen,
            DiplomaStatusId.Finished => DiplomaStatusIdDto.Finished,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }

    public static DiplomaStatusId ToInternal(DiplomaStatusIdDto input)
    {
        return input switch
        {
            DiplomaStatusIdDto.Created => DiplomaStatusId.Created,
            DiplomaStatusIdDto.TopicSuggested => DiplomaStatusId.TopicSuggested,
            DiplomaStatusIdDto.TopicFrozen => DiplomaStatusId.TopicFrozen,
            DiplomaStatusIdDto.Finished => DiplomaStatusId.Finished,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}