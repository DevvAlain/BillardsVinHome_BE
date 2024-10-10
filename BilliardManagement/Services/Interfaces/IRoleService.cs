using BilliardManagement.Entities;


namespace BilliardManagement.Services.Interfaces
{
    public interface IRoleService
    {
        ICollection<Role> GetRoles();
    }
}
