using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Universities;

public class Status : EntityBase, IAggregateRoot
{
    [StringLength(50, MinimumLength = 1)]
    public required string Name { get; set; }
}