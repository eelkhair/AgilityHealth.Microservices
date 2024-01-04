using System.ComponentModel.DataAnnotations;

namespace AH.Company.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public Guid UId { get; set; }
}