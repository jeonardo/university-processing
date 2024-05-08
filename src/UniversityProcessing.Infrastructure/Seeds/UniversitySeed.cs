using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.Identity.Enums;
using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Infrastructure.Seeds;

public class UniversitySeed(
    IRepository<University> repositoryUniversity,
    IRepository<Faculty> repositoryFaculty,
    IRepository<Department> repositoryDepartment,
    IRepository<UniversityPosition> repositoryUniversityPosition,
    IRepository<Group> repositoryGroup,
    IRepository<Specialty> repositorySpecialty,
    UserManager<User> userManager,
    RoleManager<UserRole> roleManager)
{
    private List<University> UniversityValues { get; set; } = [];

    private List<Faculty> FacultyValues { get; set; } = [];

    private List<Department> DepartmentValues { get; set; } = [];

    private List<Student> StudentValues { get; set; } = [];

    private List<Employee> EmployeeValues { get; set; } = [];

    private List<UniversityPosition> UniversityPositionValues { get; set; } = [];

    private List<Group> GroupValues { get; set; } = [];

    private List<Specialty> SpecialtyValues { get; set; } = [];

    public async Task Seed()
    {
        var wasSeedBefore = await repositoryUniversity.AnyAsync();

        if (wasSeedBefore)
        {
            return;
        }

        var role1 = new UserRole(nameof(UserRoleId.ApplicationAdmin));
        await roleManager.CreateAsync(role1);
        var role2 = new UserRole(nameof(UserRoleId.Employee));
        await roleManager.CreateAsync(role2);
        var role3 = new UserRole(nameof(UserRoleId.Student));
        await roleManager.CreateAsync(role3);

        var bsu = await AddUniversity("Белорусский государственный университет", "БГУ");
        var bntu = await AddUniversity("Белорусский национальный технологический университет", "БНТУ");
        var bsuir = await AddUniversity("Белорусский государственный университет информатики и радиоэлектроники", "БГУИР");

        var bntu_pos_1 = await AddUniversityPosition("лаборант", bntu);
        var bntu_pos_2 = await AddUniversityPosition("старший лаборант", bntu);
        var bntu_pos_3 = await AddUniversityPosition("ассистент", bntu);
        var bntu_pos_4 = await AddUniversityPosition("преподаватель", bntu);
        var bntu_pos_5 = await AddUniversityPosition("старший преподаватель", bntu);
        var bntu_pos_6 = await AddUniversityPosition("доцент", bntu);
        var bntu_pos_7 = await AddUniversityPosition("профессор", bntu);
        var bntu_pos_8 = await AddUniversityPosition("завкафедрой", bntu);
        var bntu_pos_9 = await AddUniversityPosition("декан", bntu);
        var bntu_pos_10 = await AddUniversityPosition("проректор", bntu);
        var bntu_pos_11 = await AddUniversityPosition("ректор", bntu);

        var bntu_faculty_atf = await AddFaculty("Автотракторный факультет", "АТФ", bntu);
        var bntu_faculty_fgdie = await AddFaculty("Факультет горного дела и инженерной экологии", "ФГДИЭ", bntu);
        var bntu_faculty_msf = await AddFaculty("Машиностроительный факультет", "МСФ", bntu);
        var bntu_faculty_mtf = await AddFaculty("Механико-технологический факультет", "МТФ", bntu);
        var bntu_faculty_fmmp = await AddFaculty("Факультет маркетинга, менеджмента, предпринимательства", "ФММП", bntu);
        var bntu_faculty_ef = await AddFaculty("Энергетический факультет", "ЭФ", bntu);
        var bntu_faculty_fitr = await AddFaculty("Факультет информационных технологий и робототехники", "ФИТР", bntu);
        var bntu_faculty_ftug = await AddFaculty("Факультет технологий управления и гуманитаризации", "ФТУГ", bntu);
        var bntu_faculty_epf = await AddFaculty("Инженерно-педагогический факультет", "ИПФ", bntu);
        var bntu_faculty_fes = await AddFaculty("Факультет энергетического строительства", "ФЭС", bntu);
        var bntu_faculty_af = await AddFaculty("Архитектурный факультет", "АФ", bntu);
        var bntu_faculty_sf = await AddFaculty("Строительный факультет", "СФ", bntu);
        var bntu_faculty_psf = await AddFaculty("Приборостроительный факультет", "ПСФ", bntu);
        var bntu_faculty_ftk = await AddFaculty("Факультет транспортных коммуникаций", "ФТК", bntu);
        var bntu_faculty_wtf = await AddFaculty("Военно-технический факультет", "ВТФ", bntu);
        var bntu_faculty_stf = await AddFaculty("Спортивно-технический факультет", "СТФ", bntu);
        var bntu_faculty_fms = await AddFaculty("Факультет международного сотрудничества", "ФМС", bntu);

        //check if supervisor has a department

        var bntu_faculty_fitr_poisit = await AddDepartment(
            "Программное обеспечение информационных систем и технологий",
            "ПОИСиТ",
            bntu_faculty_fmmp);
        var bntu_faculty_fitr_zaputk = await AddDepartment(
            "Электропривод и автоматизация промышленных установок и технологических комплексов",
            "ЭАПУиТК",
            bntu_faculty_fmmp);
        var bntu_faculty_fitr_rts = await AddDepartment("Робототехнические системы", "РТС", bntu_faculty_fmmp);
        var bntu_faculty_fitr_tf = await AddDepartment("Техническая физика", "ТФ", bntu_faculty_fmmp);
        var bntu_faculty_fitr_vm = await AddDepartment("Высшая математика", "ВМ", bntu_faculty_fmmp);

        var bntu_faculty_fitr_sp1 = await AddSpecialty(
            "Автоматизация технологических процессов и производств в энергетике",
            "Short",
            "6-05-0713-04",
            bntu_faculty_fitr);
        var bntu_faculty_fitr_sp2 = await AddSpecialty(
            "Автоматизация технологических процессов и производств в приборостроении и радиоэлектронике",
            "Short",
            "6-05-0713-04",
            bntu_faculty_fitr);
        var bntu_faculty_fitr_sp3 = await AddSpecialty(
            "Автоматизированные электроприводы",
            "Short",
            "6-05-0713-04",
            bntu_faculty_fitr);
        var bntu_faculty_fitr_sp4 = await AddSpecialty(
            "Информационные системы и технологии в проектировании и производстве",
            "Short",
            "6-05-0611-01",
            bntu_faculty_fitr);
        var bntu_faculty_fitr_sp5 = await AddSpecialty("Программная инженерия", "Short", "6-05-0612-01", bntu_faculty_fitr);
        var bntu_faculty_fitr_sp6 = await AddSpecialty(
            "Промышленные роботы и робототехнические комплексы",
            "Short",
            "6-05-0713-05",
            bntu_faculty_fitr);

        var bntu_polozkov = await AddEmployee("Polozkov_Yuri_Vladimirovich", bntu_pos_8, bntu_faculty_fitr_poisit);
        var bntu_shchukin = await AddEmployee("Shchukin_Mikhail_Vladimirovich", bntu_pos_8, bntu_faculty_fitr_vm);
        var bntu_khorunzhiy = await AddEmployee("Khorunzhiy_Igor_Anatolievich", bntu_pos_8, bntu_faculty_fitr_tf);
        var bntu_borodulya = await AddEmployee("Borodulya_Alexey_Valentinovich", bntu_pos_8, bntu_faculty_fitr_rts);
        var bntu_pavlyukovets = await AddEmployee("Pavlyukovets_Sergey_Anatolievich", bntu_pos_8, bntu_faculty_fitr_zaputk);

        var bntu_prikhozhy = await AddEmployee("Prikhozhy_Anatoly_Alekseevich", bntu_pos_7, bntu_faculty_fitr_poisit);
        var bntu_gursky = await AddEmployee("Gursky_Nikolai_Nikolaevich", bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_kovaleva = await AddEmployee("Kovaleva_Irina_Lvovna", bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_kunkevich = await AddEmployee("Kunkevich_Dmitry_Petrovich", bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_kupriyanov = await AddEmployee("Kupriyanov_Andrey_Borisovich", bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_naprasnikov = await AddEmployee("Naprasnikov_Vladimir_Vladimirovich", bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_sidorik = await AddEmployee("Sidorik_Valery_Vladimirovich", bntu_pos_6, bntu_faculty_fitr_poisit);
        var bntu_yudenkov = await AddEmployee("Yudenkov_Viktor_Stepanovich", bntu_pos_6, bntu_faculty_fitr_poisit);

        var bntu_studyGroup1 = await AddGroup("1", bntu_faculty_fitr_sp1, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup2 = await AddGroup("2", bntu_faculty_fitr_sp2, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup3 = await AddGroup("3", bntu_faculty_fitr_sp3, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup4 = await AddGroup("4", bntu_faculty_fitr_sp4, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup5 = await AddGroup("5", bntu_faculty_fitr_sp5, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));
        var bntu_studyGroup6 = await AddGroup("6", bntu_faculty_fitr_sp6, new DateOnly(2023, 9, 1), new DateOnly(2027, 9, 1));

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"StudentUsername_{bntu_studyGroup1.Number + 100}_{i}", bntu_studyGroup1);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"StudentUsername_{bntu_studyGroup2.Number + 100}_{i}", bntu_studyGroup2);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"StudentUsername_{bntu_studyGroup3.Number + 100}_{i}", bntu_studyGroup3);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"StudentUsername_{bntu_studyGroup4.Number + 100}_{i}", bntu_studyGroup4);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"StudentUsername_{bntu_studyGroup5.Number + 100}_{i}", bntu_studyGroup5);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"StudentUsername_{bntu_studyGroup6.Number + 100}_{i}", bntu_studyGroup6);
        }
    }

    private async Task<University> AddUniversity(string name, string shortName)
    {
        var result = new University(name, shortName);
        UniversityValues.Add(result);
        await repositoryUniversity.AddAsync(result);
        return result;
    }

    private async Task<Faculty> AddFaculty(string name, string shortName, University university)
    {
        var result = new Faculty(name, shortName, university);
        FacultyValues.Add(result);
        await repositoryFaculty.AddAsync(result);
        return result;
    }

    private async Task<Department> AddDepartment(string name, string shortName, Faculty faculty)
    {
        var result = new Department(name, shortName, faculty);
        DepartmentValues.Add(result);
        await repositoryDepartment.AddAsync(result);
        return result;
    }

    private async Task<Specialty> AddSpecialty(string name, string shortName, string code, Faculty faculty)
    {
        var result = new Specialty(name, shortName, faculty, code);
        SpecialtyValues.Add(result);
        await repositorySpecialty.AddAsync(result);
        return result;
    }

    private async Task<Group> AddGroup(
        string groupNumber,
        Specialty specialty,
        DateOnly startDate,
        DateOnly endDate)
    {
        var result = new Group(groupNumber, startDate, endDate, specialty, specialty.Faculty);
        GroupValues.Add(result);
        await repositoryGroup.AddAsync(result);
        return result;
    }

    private async Task<Student> AddStudent(string username, Group group)
    {
        var result = new Student(group, username, username);
        StudentValues.Add(result);
        await userManager.CreateAsync(result);
        await userManager.AddToRoleAsync(result, nameof(UserRoleId.Student));
        return result;
    }

    private async Task<Employee> AddEmployee(
        string username,
        UniversityPosition position,
        Department department)
    {
        var result = new Employee(position, department, username, username);
        EmployeeValues.Add(result);
        await userManager.CreateAsync(result);
        await userManager.AddToRoleAsync(result, nameof(UserRoleId.Employee));
        return result;
    }

    private async Task<UniversityPosition> AddUniversityPosition(string name, University university)
    {
        var result = new UniversityPosition(name, university);
        UniversityPositionValues.Add(result);
        await repositoryUniversityPosition.AddAsync(result);
        return result;
    }
}