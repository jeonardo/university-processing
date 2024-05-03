using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Universities;

public class GraduateWork : EntityBase, IAggregateRoot
{
    [StringLength(50, MinimumLength = 1)]
    public required string Title { get; set; }

    [AllowNull]
    [Range(0, 10)]
    public int? Grade { get; set; }

    public required Guid StatusId { get; set; }

    public required Status Status { get; set; }

    public required Guid StudentId { get; set; }

    public required Student Student { get; set; }

    public required Guid SupervisorId { get; set; }

    public required Employee Supervisor { get; set; }
}