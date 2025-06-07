namespace UniversityProcessing.Core.Entities;

public class GecMember : EntityBase
{
    // Навигационные свойства
    public GraduationExaminationCommittee Gec { get; private set; }
    public Employee Employee { get; private set; }

    public GecMember(
        GraduationExaminationCommittee gec,
        Employee employee)
    {
        Gec = gec;
        Employee = employee;
    }
}
