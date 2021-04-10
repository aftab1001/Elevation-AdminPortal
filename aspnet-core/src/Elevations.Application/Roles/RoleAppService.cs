namespace Elevations.Roles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.IdentityFramework;
    using Abp.Linq.Extensions;

    using Elevations.Authorization;
    using Elevations.Authorization.Roles;
    using Elevations.Authorization.Users;
    using Elevations.Roles.Dto;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [AbpAuthorize(PermissionNames.Pages_Roles)]
    public class RoleAppService :
        AsyncCrudAppService<Role, RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>,
        IRoleAppService
    {
        private readonly RoleManager _roleManager;

        private readonly UserManager _userManager;

        public RoleAppService(IRepository<Role> repository, RoleManager roleManager, UserManager userManager)
            : base(repository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public override async Task<RoleDto> CreateAsync(CreateRoleDto input)
        {
            CheckCreatePermission();

            Role role = ObjectMapper.Map<Role>(input);
            role.SetNormalizedName();

            CheckErrors(await _roleManager.CreateAsync(role));

            List<Permission> grantedPermissions = PermissionManager.GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name)).ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            Role role = await _roleManager.FindByIdAsync(input.Id.ToString());
            IList<User> users = await _userManager.GetUsersInRoleAsync(role.NormalizedName);

            foreach (User user in users)
            {
                CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.NormalizedName));
            }

            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        public Task<ListResultDto<PermissionDto>> GetAllPermissions()
        {
            IReadOnlyList<Permission> permissions = PermissionManager.GetAllPermissions();

            return Task.FromResult(
                new ListResultDto<PermissionDto>(
                    ObjectMapper.Map<List<PermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList()));
        }

        public async Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input)
        {
            IReadOnlyList<Permission> permissions = PermissionManager.GetAllPermissions();
            Role role = await _roleManager.GetRoleByIdAsync(input.Id);
            Permission[] grantedPermissions = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();
            RoleEditDto roleEditDto = ObjectMapper.Map<RoleEditDto>(role);

            return new GetRoleForEditOutput
                       {
                           Role = roleEditDto,
                           Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions)
                               .OrderBy(p => p.DisplayName).ToList(),
                           GrantedPermissionNames = grantedPermissions.Select(p => p.Name).ToList()
                       };
        }

        public async Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input)
        {
            List<Role> roles = await _roleManager.Roles.WhereIf(
                                       !input.Permission.IsNullOrWhiteSpace(),
                                       r => r.Permissions.Any(rp => rp.Name == input.Permission && rp.IsGranted))
                                   .ToListAsync();

            return new ListResultDto<RoleListDto>(ObjectMapper.Map<List<RoleListDto>>(roles));
        }

        public override async Task<RoleDto> UpdateAsync(RoleDto input)
        {
            CheckUpdatePermission();

            Role role = await _roleManager.GetRoleByIdAsync(input.Id);

            ObjectMapper.Map(input, role);

            CheckErrors(await _roleManager.UpdateAsync(role));

            List<Permission> grantedPermissions = PermissionManager.GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name)).ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }

        protected override IQueryable<Role> ApplySorting(IQueryable<Role> query, PagedRoleResultRequestDto input)
        {
            return query.OrderBy(r => r.DisplayName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected override IQueryable<Role> CreateFilteredQuery(PagedRoleResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Permissions).WhereIf(
                !input.Keyword.IsNullOrWhiteSpace(),
                x => x.Name.Contains(input.Keyword) || x.DisplayName.Contains(input.Keyword)
                                                    || x.Description.Contains(input.Keyword));
        }

        protected override async Task<Role> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAllIncluding(x => x.Permissions).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}