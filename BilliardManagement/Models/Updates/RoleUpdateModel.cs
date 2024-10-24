namespace BilliardManagement.Models.Updates;

public class RoleUpdateModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateAt { get; set; }
}