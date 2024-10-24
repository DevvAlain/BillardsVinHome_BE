using BilliardManagement.Entities;
using BilliardManagement.Models.Creates;
using BilliardManagement.Models.Updates;
using BilliardManagement.Models.Views;

namespace BilliardManagement.Services.Interfaces
{
    public interface IRoleService
    {
        ICollection<RoleViewsModel> GetRoles() ;
        RoleViewsModel? GetRoleById(Guid id); 
        void DeleteRole(Guid id);

        RoleViewsModel? CreateRole(RoleCreateModel model);
        RoleViewsModel? UpdateRole(Guid id, RolePropertiesUpdateModel model);
        RoleViewsModel? UpdateRole(RoleUpdateModel model);
    }
}