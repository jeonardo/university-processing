namespace UniversityProcessing.Core.Entities;

public class Grade : EntityBase
{
    public decimal Value { get; private set; }
    public decimal Percentage { get; private set; }
    public string? Comment { get; private set; }

    // Навигационные свойства
    public Defense Defense { get; private set; }
    public Employee GecMember { get; private set; }

    public Grade(
        Employee gecMember,
        Defense defense,
        decimal value,
        decimal percentage,
        string? comment = null)
    {
        if (value < 0 || value > 100)
        {
            throw new ArgumentException("Grade must be between 0 and 100");
        }

        GecMember = gecMember;
        Defense = defense;
        Value = value;
        Percentage = percentage;
        Comment = comment;
    }
}
