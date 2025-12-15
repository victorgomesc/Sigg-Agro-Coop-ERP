namespace SiggAgroCoop.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Atualiza a propriedade UpdatedAt para o horário atual em UTC.
    /// Método padrão para manter compatibilidade com o código existente.
    /// </summary>
    public void SetUpdatedNow()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Alias para SetUpdatedNow, usado em alguns contextos.
    /// </summary>
    public void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
