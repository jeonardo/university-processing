using UniversityProcessing.Infrastructure.Entities;

namespace UniversityProcessing.Infrastructure.Seeds;

public class UniversitySeed
{
    public List<UniversityEntity> UniversityValues { get; set; } = [];

    public List<FacultyEntity> FacultyValues { get; set; } = [];

    public List<DepartmentEntity> DepartmentValues { get; set; } = [];

    public List<StudentEntity> StudentValues { get; set; } = [];

    public List<EmployeeEntity> EmployeeValues { get; set; } = [];

    public List<UniversityPositionEntity> UniversityPositionValues { get; set; } = [];

    public List<StudyGroupEntity> StudyGroupValues { get; set; } = [];

    public List<SpecialtyEntity> SpecialtyValues { get; set; } = [];

    public void Seed()
    {
        var bsu = AddUniversity("Белорусский государственный университет", "БГУ");
        var bntu = AddUniversity("Белорусский национальный технологический университет", "БНТУ");
        var bsuir = AddUniversity("Белорусский государственный университет информатики и радиоэлектроники", "БГУИР");

        var bntu_pos_1 = AddUniversityPosition("лаборант", bntu);
        var bntu_pos_2 = AddUniversityPosition("старший лаборант", bntu);
        var bntu_pos_3 = AddUniversityPosition("ассистент", bntu);
        var bntu_pos_4 = AddUniversityPosition("преподаватель", bntu);
        var bntu_pos_5 = AddUniversityPosition("старший преподаватель", bntu);
        var bntu_pos_6 = AddUniversityPosition("доцент", bntu);
        var bntu_pos_7 = AddUniversityPosition("профессор", bntu);
        var bntu_pos_8 = AddUniversityPosition("завкафедрой", bntu);
        var bntu_pos_9 = AddUniversityPosition("декан", bntu);
        var bntu_pos_10 = AddUniversityPosition("проректор", bntu);
        var bntu_pos_11 = AddUniversityPosition("ректор", bntu);

        var bntu_faculty_atf = AddFaculty("Автотракторный факультет", "АТФ", bntu);
        var bntu_faculty_fgdie = AddFaculty("Факультет горного дела и инженерной экологии", "ФГДИЭ", bntu);
        var bntu_faculty_msf = AddFaculty("Машиностроительный факультет", "МСФ", bntu);
        var bntu_faculty_mtf = AddFaculty("Механико-технологический факультет", "МТФ", bntu);
        var bntu_faculty_fmmp = AddFaculty("Факультет маркетинга, менеджмента, предпринимательства", "ФММП", bntu);
        var bntu_faculty_ef = AddFaculty("Энергетический факультет", "ЭФ", bntu);
        var bntu_faculty_fitr = AddFaculty("Факультет информационных технологий и робототехники", "ФИТР", bntu);
        var bntu_faculty_ftug = AddFaculty("Факультет технологий управления и гуманитаризации", "ФТУГ", bntu);
        var bntu_faculty_epf = AddFaculty("Инженерно-педагогический факультет", "ИПФ", bntu);
        var bntu_faculty_fes = AddFaculty("Факультет энергетического строительства", "ФЭС", bntu);
        var bntu_faculty_af = AddFaculty("Архитектурный факультет", "АФ", bntu);
        var bntu_faculty_sf = AddFaculty("Строительный факультет", "СФ", bntu);
        var bntu_faculty_psf = AddFaculty("Приборостроительный факультет", "ПСФ", bntu);
        var bntu_faculty_ftk = AddFaculty("Факультет транспортных коммуникаций", "ФТК", bntu);
        var bntu_faculty_wtf = AddFaculty("Военно-технический факультет", "ВТФ", bntu);
        var bntu_faculty_stf = AddFaculty("Спортивно-технический факультет", "СТФ", bntu);
        var bntu_faculty_fms = AddFaculty("Факультет международного сотрудничества", "ФМС", bntu);

        //check if supervisor has a department

        var bntu_faculty_fitr_poisit = AddDepartment(
            "Программное обеспечение информационных систем и технологий",
            "ПОИСиТ",
            bntu_faculty_fmmp);
        var bntu_faculty_fitr_zaputk = AddDepartment(
            "Электропривод и автоматизация промышленных установок и технологических комплексов",
            "ЭАПУиТК",
            bntu_faculty_fmmp);
        var bntu_faculty_fitr_rts = AddDepartment("Робототехнические системы", "РТС", bntu_faculty_fmmp);
        var bntu_faculty_fitr_tf = AddDepartment("Техническая физика", "ТФ", bntu_faculty_fmmp);
        var bntu_faculty_fitr_vm = AddDepartment("Высшая математика", "ВМ", bntu_faculty_fmmp);

        var bntu_faculty_fitr_sp1 = AddSpecialty(
            "Автоматизация технологических процессов и производств в энергетике",
            "Short",
            "6-05-0713-04",
            bntu_faculty_fitr);
        var bntu_faculty_fitr_sp2 = AddSpecialty(
            "Автоматизация технологических процессов и производств в приборостроении и радиоэлектронике",
            "Short",
            "6-05-0713-04",
            bntu_faculty_fitr);
        var bntu_faculty_fitr_sp3 = AddSpecialty(
            "Автоматизированные электроприводы",
            "Short",
            "6-05-0713-04",
            bntu_faculty_fitr);
        var bntu_faculty_fitr_sp4 = AddSpecialty(
            "Информационные системы и технологии в проектировании и производстве",
            "Short",
            "6-05-0611-01",
            bntu_faculty_fitr);
        var bntu_faculty_fitr_sp5 = AddSpecialty("Программная инженерия", "Short", "6-05-0612-01", bntu_faculty_fitr);
        var bntu_faculty_fitr_sp6 = AddSpecialty(
            "Промышленные роботы и робототехнические комплексы",
            "Short",
            "6-05-0713-05",
            bntu_faculty_fitr);

        var bntu_polozkov = AddEmployee("Polozkov_Yuri_Vladimirovich", bntu, bntu_pos_8, bntu_faculty_fitr_poisit);
        var bntu_shchukin = AddEmployee("Shchukin_Mikhail_Vladimirovich", bntu, bntu_pos_8, bntu_faculty_fitr_vm);
        var bntu_khorunzhiy = AddEmployee("Khorunzhiy_Igor_Anatolievich", bntu, bntu_pos_8, bntu_faculty_fitr_tf);
        var bntu_borodulya = AddEmployee("Borodulya_Alexey_Valentinovich", bntu, bntu_pos_8, bntu_faculty_fitr_rts);
        var bntu_pavlyukovets = AddEmployee("Pavlyukovets_Sergey_Anatolievich", bntu, bntu_pos_8, bntu_faculty_fitr_zaputk);

        var bntu_prikhozhy = AddEmployee("Prikhozhy_Anatoly_Alekseevich", bntu, bntu_pos_7, bntu_faculty_fitr_poisit);
        var bntu_gursky = AddEmployee("Gursky_Nikolai_Nikolaevich", bntu, bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_kovaleva = AddEmployee("Kovaleva_Irina_Lvovna", bntu, bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_kunkevich = AddEmployee("Kunkevich_Dmitry_Petrovich", bntu, bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_kupriyanov = AddEmployee("Kupriyanov_Andrey_Borisovich", bntu, bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_naprasnikov = AddEmployee("Naprasnikov_Vladimir_Vladimirovich", bntu, bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_sidorik = AddEmployee("Sidorik_Valery_Vladimirovich", bntu, bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_yudenkov = AddEmployee("Yudenkov_Viktor_Stepanovich", bntu, bntu_pos_6, bntu_faculty_fitr_poisit);

        var bntu_studyGroup1 = AddStudyGroup("1", bntu_faculty_fitr_sp1, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup2 = AddStudyGroup("2", bntu_faculty_fitr_sp2, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup3 = AddStudyGroup("3", bntu_faculty_fitr_sp3, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup4 = AddStudyGroup("4", bntu_faculty_fitr_sp4, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup5 = AddStudyGroup("5", bntu_faculty_fitr_sp5, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup6 = AddStudyGroup("6", bntu_faculty_fitr_sp6, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));

        for (var i = 0; i < 30; i++)
        {
            _ = AddStudent($"StudentUsername_{bntu_studyGroup1.GroupNumber + 100}_{i}", bntu_studyGroup1);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = AddStudent($"StudentUsername_{bntu_studyGroup2.GroupNumber + 100}_{i}", bntu_studyGroup2);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = AddStudent($"StudentUsername_{bntu_studyGroup3.GroupNumber + 100}_{i}", bntu_studyGroup3);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = AddStudent($"StudentUsername_{bntu_studyGroup4.GroupNumber + 100}_{i}", bntu_studyGroup4);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = AddStudent($"StudentUsername_{bntu_studyGroup5.GroupNumber + 100}_{i}", bntu_studyGroup5);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = AddStudent($"StudentUsername_{bntu_studyGroup6.GroupNumber + 100}_{i}", bntu_studyGroup6);
        }
    }

    private UniversityEntity AddUniversity(string name, string shortName)
    {
        var result = new UniversityEntity
        {
            Name = name,
            ShortName = shortName
        };
        UniversityValues.Add(result);
        return result;
    }

    private FacultyEntity AddFaculty(string name, string shortName, UniversityEntity university)
    {
        var result = new FacultyEntity
        {
            Name = name,
            ShortName = shortName,
            University = university,
            UniversityId = university.Id
        };
        FacultyValues.Add(result);
        return result;
    }

    private DepartmentEntity AddDepartment(string name, string shortName, FacultyEntity faculty)
    {
        var result = new DepartmentEntity
        {
            Name = name,
            ShortName = shortName,
            Faculty = faculty,
            FacultyId = faculty.Id
        };
        DepartmentValues.Add(result);
        return result;
    }

    private SpecialtyEntity AddSpecialty(string name, string shortName, string code, FacultyEntity faculty)
    {
        var result = new SpecialtyEntity
        {
            Faculty = faculty,
            FacultyId = faculty.Id,
            Name = name,
            ShortName = shortName,
            Code = code
        };
        SpecialtyValues.Add(result);
        return result;
    }

    private StudyGroupEntity AddStudyGroup(
        string groupNumber,
        SpecialtyEntity specialty,
        DateOnly startDate,
        DateOnly endDate)
    {
        var result = new StudyGroupEntity
        {
            GroupNumber = groupNumber,
            StartDate = startDate,
            EndDate = endDate,
            Specialty = specialty,
            SpecialtyId = specialty.Id
        };
        StudyGroupValues.Add(result);
        return result;
    }

    private StudentEntity AddStudent(string username, StudyGroupEntity studyGroup)
    {
        var result = new StudentEntity
        {
            Email = username + "@gmail.com",
            UserName = username,
            FirstName = username,
            LastName = username,
            MiddleName = username,
            StudyGroup = studyGroup
        };
        StudentValues.Add(result);
        return result;
    }

    private EmployeeEntity AddEmployee(
        string username,
        UniversityEntity employer,
        UniversityPositionEntity position,
        DepartmentEntity? department = null)
    {
        var result = new EmployeeEntity
        {
            Email = username + "@gmail.com",
            UserName = username,
            FirstName = username,
            LastName = username,
            MiddleName = username,
            Employer = employer,
            EmployerId = employer.Id,
            UniversityPosition = position,
            UniversityPositionId = position.Id,
            Department = department ?? null,
            DepartmentId = department?.Id ?? null
        };
        EmployeeValues.Add(result);
        return result;
    }

    private UniversityPositionEntity AddUniversityPosition(string name, UniversityEntity university)
    {
        var result = new UniversityPositionEntity
        {
            Name = name,
            University = university,
            UniversityId = university.Id
        };
        UniversityPositionValues.Add(result);
        return result;
    }
}