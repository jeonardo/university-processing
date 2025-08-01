﻿using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

// ReSharper disable All

namespace UniversityProcessing.Infrastructure.Seeds;

public class UniversitySeed(
    IEfRepository<Faculty> repositoryFaculty,
    IEfRepository<Department> repositoryDepartment,
    IEfRepository<UniversityPosition> repositoryUniversityPosition,
    IEfRepository<Group> repositoryGroup,
    IEfRepository<Specialty> repositorySpecialty,
    UserManager<User> userManager,
    RoleManager<UserRole> roleManager)
{
    private List<Faculty> FacultyValues { get; set; } = [];

    private List<Department> DepartmentValues { get; set; } = [];

    private List<User> StudentValues { get; set; } = [];

    private List<User> EmployeeValues { get; set; } = [];

    private List<User> AdminValues { get; set; } = [];

    private List<UniversityPosition> UniversityPositionValues { get; set; } = [];

    private List<Group> GroupValues { get; set; } = [];

    private List<Specialty> SpecialtyValues { get; set; } = [];

    public async Task Seed()
    {
        var wasSeedBefore = await repositoryFaculty.AnyAsync();

        if (wasSeedBefore)
        {
            return;
        }

        foreach (var variable in Enum.GetNames<UserRoleType>())
        {
            await roleManager.CreateAsync(UserRole.Create(variable));
        }

        var bntu_pos_1 = await AddUniversityPosition("лаборант");
        var bntu_pos_2 = await AddUniversityPosition("старший лаборант");
        var bntu_pos_3 = await AddUniversityPosition("ассистент");
        var bntu_pos_4 = await AddUniversityPosition("преподаватель");
        var bntu_pos_5 = await AddUniversityPosition("старший преподаватель");
        var bntu_pos_6 = await AddUniversityPosition("доцент");
        var bntu_pos_7 = await AddUniversityPosition("профессор");
        var bntu_pos_8 = await AddUniversityPosition("завкафедрой");
        var bntu_pos_9 = await AddUniversityPosition("декан");
        var bntu_pos_10 = await AddUniversityPosition("проректор");
        var bntu_pos_11 = await AddUniversityPosition("ректор");

        var bntu_faculty_atf = await AddFaculty("Автотракторный факультет", "АТФ");
        var bntu_faculty_fgdie = await AddFaculty("Факультет горного дела и инженерной экологии", "ФГДИЭ");
        var bntu_faculty_msf = await AddFaculty("Машиностроительный факультет", "МСФ");
        var bntu_faculty_mtf = await AddFaculty("Механико-технологический факультет", "МТФ");
        var bntu_faculty_fmmp = await AddFaculty("Факультет маркетинга, менеджмента, предпринимательства", "ФММП");
        var bntu_faculty_ef = await AddFaculty("Энергетический факультет", "ЭФ");
        var bntu_faculty_fitr = await AddFaculty("Факультет информационных технологий и робототехники", "ФИТР");
        var bntu_faculty_ftug = await AddFaculty("Факультет технологий управления и гуманитаризации", "ФТУГ");
        var bntu_faculty_epf = await AddFaculty("Инженерно-педагогический факультет", "ИПФ");
        var bntu_faculty_fes = await AddFaculty("Факультет энергетического строительства", "ФЭС");
        var bntu_faculty_af = await AddFaculty("Архитектурный факультет", "АФ");
        var bntu_faculty_sf = await AddFaculty("Строительный факультет", "СФ");
        var bntu_faculty_psf = await AddFaculty("Приборостроительный факультет", "ПСФ");
        var bntu_faculty_ftk = await AddFaculty("Факультет транспортных коммуникаций", "ФТК");
        var bntu_faculty_wtf = await AddFaculty("Военно-технический факультет", "ВТФ");
        var bntu_faculty_stf = await AddFaculty("Спортивно-технический факультет", "СТФ");
        var bntu_faculty_fms = await AddFaculty("Факультет международного сотрудничества", "ФМС");

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
            "6-05-0713-03",
            bntu_faculty_fitr_poisit);
        var bntu_faculty_fitr_sp2 = await AddSpecialty(
            "Автоматизация технологических процессов и производств в приборостроении и радиоэлектронике",
            "Short",
            "6-05-0713-02",
            bntu_faculty_fitr_poisit);
        var bntu_faculty_fitr_sp3 = await AddSpecialty(
            "Автоматизированные электроприводы",
            "Short",
            "6-05-0713-11",
            bntu_faculty_fitr_poisit);
        var bntu_faculty_fitr_sp4 = await AddSpecialty(
            "Информационные системы и технологии в проектировании и производстве",
            "Short",
            "6-05-0611-01",
            bntu_faculty_fitr_poisit);
        var bntu_faculty_fitr_sp5 = await AddSpecialty("Программная инженерия", "Short", "6-05-0612-01", bntu_faculty_fitr_poisit);
        var bntu_faculty_fitr_sp6 = await AddSpecialty(
            "Промышленные роботы и робототехнические комплексы",
            "Short",
            "6-05-0713-05",
            bntu_faculty_fitr_poisit);

        var bntu_polozkov = await AddTeacher("Polozkov_Yuri_Vladimirovich", bntu_pos_8, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_shchukin = await AddTeacher("Shchukin_Mikhail_Vladimirovich", bntu_pos_8, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_khorunzhiy = await AddTeacher("Khorunzhiy_Igor_Anatolievich", bntu_pos_8, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_borodulya = await AddTeacher("Borodulya_Alexey_Valentinovich", bntu_pos_8, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_pavlyukovets = await AddTeacher("Pavlyukovets_Sergey_Anatolievich", bntu_pos_8, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);

        var bntu_prikhozhy = await AddTeacher("Prikhozhy_Anatoly_Alekseevich", bntu_pos_7, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_gursky = await AddTeacher("Gursky_Nikolai_Nikolaevich", bntu_pos_6, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_kovaleva = await AddTeacher("Kovaleva_Irina_Lvovna", bntu_pos_6, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_kunkevich = await AddTeacher("Kunkevich_Dmitry_Petrovich", bntu_pos_6, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_kupriyanov = await AddTeacher("Kupriyanov_Andrey_Borisovich", bntu_pos_6, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_naprasnikov = await AddTeacher("Naprasnikov_Vladimir_Vladimirovich", bntu_pos_6, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_sidorik = await AddTeacher("Sidorik_Valery_Vladimirovich", bntu_pos_6, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
        var bntu_yudenkov = await AddTeacher("Yudenkov_Viktor_Stepanovich", bntu_pos_6, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);

        var bntu_studyGroup1 = await AddGroup("1", bntu_faculty_fitr_sp1, new DateTime(2023, 9, 1), new DateTime(2027, 9, 1));
        var bntu_studyGroup2 = await AddGroup("2", bntu_faculty_fitr_sp2, new DateTime(2023, 9, 1), new DateTime(2027, 9, 1));
        var bntu_studyGroup3 = await AddGroup("3", bntu_faculty_fitr_sp3, new DateTime(2023, 9, 1), new DateTime(2027, 9, 1));
        var bntu_studyGroup4 = await AddGroup("4", bntu_faculty_fitr_sp4, new DateTime(2023, 9, 1), new DateTime(2027, 9, 1));
        var bntu_studyGroup5 = await AddGroup("5", bntu_faculty_fitr_sp5, new DateTime(2023, 9, 1), new DateTime(2027, 9, 1));
        var bntu_studyGroup6 = await AddGroup("6", bntu_faculty_fitr_sp6, new DateTime(2023, 9, 1), new DateTime(2027, 9, 1));

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"Student_{bntu_studyGroup1.Number + 100}_{i}", bntu_studyGroup1);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"Student_{bntu_studyGroup2.Number + 100}_{i}", bntu_studyGroup2);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"Student_{bntu_studyGroup3.Number + 100}_{i}", bntu_studyGroup3);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"Student_{bntu_studyGroup4.Number + 100}_{i}", bntu_studyGroup4);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"Student_{bntu_studyGroup5.Number + 100}_{i}", bntu_studyGroup5);
        }

        for (var i = 0; i < 30; i++)
        {
            _ = await AddStudent($"Student_{bntu_studyGroup6.Number + 100}_{i}", bntu_studyGroup6);
        }

        await AddAdmin("test_admin");
        await AddStudent("test_student", bntu_studyGroup1);
        await AddTeacher("test_teacher", bntu_pos_1, bntu_faculty_fmmp.Id, bntu_faculty_fitr_poisit.Id);
    }

    private async Task<Faculty> AddFaculty(string name, string shortName)
    {
        var result = Faculty.Create(name, shortName);
        FacultyValues.Add(result);
        await repositoryFaculty.AddAsync(result);
        return result;
    }

    private async Task<Department> AddDepartment(string name, string shortName, Faculty faculty)
    {
        var result = Department.Create(name, shortName, faculty.Id);
        DepartmentValues.Add(result);
        await repositoryDepartment.AddAsync(result);
        return result;
    }

    private async Task<Specialty> AddSpecialty(string name, string shortName, string code, Department department)
    {
        var result = Specialty.Create(name, shortName, code, department.Id);
        SpecialtyValues.Add(result);
        await repositorySpecialty.AddAsync(result);
        return result;
    }

    private async Task<Group> AddGroup(
        string groupNumber,
        Specialty specialty,
        DateTime startDate,
        DateTime endDate)
    {
        var result = Group.Create(groupNumber, startDate, endDate, specialty.Id);
        GroupValues.Add(result);
        await repositoryGroup.AddAsync(result);
        return result;
    }

    private async Task<User> AddAdmin(string username)
    {
        var result = User.CreateAdmin(username, username, username);
        result.UpdateVerificationStatus(true);
        await userManager.CreateAsync(result, username);
        await userManager.AddToRoleAsync(result, nameof(UserRoleType.Admin));
        AdminValues.Add(result);
        return result;
    }

    private async Task<User> AddStudent(string username, Group group)
    {
        var result = User.CreateStudent(username, username, username, group.Department.FacultyId, group.DepartmentId, groupId: group.Id);
        result.UpdateVerificationStatus(true);
        await userManager.CreateAsync(result, username);
        await userManager.AddToRoleAsync(result, nameof(UserRoleType.Student));
        StudentValues.Add(result);
        return result;
    }

    private async Task<User> AddTeacher(
        string username,
        UniversityPosition universityPosition,
        Guid facultyId,
        Guid departmentId)
    {
        var result = User.CreateTeacher(username, username, username, facultyId, departmentId, universityPositionId: universityPosition.Id);
        result.UpdateVerificationStatus(true);
        await userManager.CreateAsync(result, username);
        await userManager.AddToRoleAsync(result, nameof(UserRoleType.Teacher));
        EmployeeValues.Add(result);
        return result;
    }

    private async Task<UniversityPosition> AddUniversityPosition(string name)
    {
        var result = UniversityPosition.Create(name);
        UniversityPositionValues.Add(result);
        await repositoryUniversityPosition.AddAsync(result);
        return result;
    }
}
