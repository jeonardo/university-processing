using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniversityProcessing.API.Infrastructure.Entities
{
    public class StudyGroupEntity : BaseEntity
    {
        public string SpecialtyAndQualification { get; set; } = string.Empty;
        
        public string GroupNumber { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
