using SiggAgroCoop.Domain.Common;

namespace SiggAgroCoop.Domain.Entities;

public class Employee : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Role { get; set; } = default!; // Cargo (ex: operador, técnico, tratorista)
    public string DocumentId { get; set; } = default!; // CPF ou ID interno

    public List<Tool> Tools { get; set; } = new(); // Relationship 1:N
}
