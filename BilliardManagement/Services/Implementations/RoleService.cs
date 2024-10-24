using BilliardManagement.Entities;
using BilliardManagement.Models.Creates;
using BilliardManagement.Models.Updates;
using BilliardManagement.Models.Views;
using BilliardManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BilliardManagement.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly BilliardsManagementContext _context;

        public RoleService(BilliardsManagementContext context)
        {
            _context = context;
        }

        // Get all roles as view models
        public ICollection<RoleViewsModel> GetRoles()
        {
            var roles = _context.Roles
                .Select(x => new RoleViewsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreateAt = x.CreateAt,
                })
                .ToList();
            return roles;
        }

        // Get a specific role by ID as a view model
        public RoleViewsModel? GetRoleById(Guid id)
        {
            var role = _context.Roles
                .Select(x => new RoleViewsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreateAt = x.CreateAt,
                })
                .FirstOrDefault(x => x.Id.Equals(id));
            return role;
        }

        // Delete a role
        public void DeleteRole(Guid id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            if (role == null)
            {
                return;
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        // Create a new role and return the created role view
        public RoleViewsModel? CreateRole(RoleCreateModel model)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CreateAt = DateTime.UtcNow,
            };

            _context.Roles.Add(role);
            var result = _context.SaveChanges();

            return result == 1 ? GetRoleById(role.Id) : null;
        }

        // Partially update a role (PATCH) and return the updated role view
        public RoleViewsModel? UpdateRole(Guid id, RolePropertiesUpdateModel model)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            if (role == null)
            {
                return null;
            }

            // Update fields only if they are provided
            if (model.Name != null)
            {
                role.Name = model.Name;
            }

            _context.Roles.Update(role);
            var result = _context.SaveChanges();

            return result == 1 ? GetRoleById(role.Id) : null;
        }

        // Fully update a role (PUT) and return the updated role view
        public RoleViewsModel? UpdateRole(RoleUpdateModel model)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(model.Id));
            if (role == null)
            {
                return null;
            }

            // Full update of role
            role.Name = model.Name;
            role.CreateAt = model.CreateAt;

            _context.Roles.Update(role);
            var result = _context.SaveChanges();

            return result == 1 ? GetRoleById(role.Id) : null;
        }
    }
}
