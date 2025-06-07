namespace UniversityProcessing.Core.Entities;

public class GecSpecialty : EntityBase
{
    // Навигационные свойства
    public GraduationExaminationCommittee Gec { get; private set; }
    public Specialty Specialty { get; private set; }

    public GecSpecialty(
        GraduationExaminationCommittee gec,
        Specialty specialty)
    {
        Gec = gec;
        Specialty = specialty;
    }
}
