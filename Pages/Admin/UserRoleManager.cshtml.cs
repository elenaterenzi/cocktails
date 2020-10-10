using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using cocktails.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace cocktails.Pages.Admin
{
    public class UserRoleManagerModel : AdminPageModel
    {
        private readonly ILogger<UserRoleManagerModel> _logger;

        public UserRoleManagerModel(
                    ILogger<UserRoleManagerModel> logger,
                    ApplicationDbContext context,
                    IAuthorizationService authorizationService,
                    UserManager<IdentityUser> userManager,
                    RoleManager<IdentityRole> roleManager) : base(context, authorizationService, userManager, roleManager)
        {
            _logger = logger;
            roleList = new Dictionary<string,string>();
            roleSelectList = new List<SelectListItem>();
            foreach (var r in roleManager.Roles)
            {
                roleList.Add(r.Id,r.Name);
                roleSelectList.Add(new SelectListItem{Value = r.Id, Text=r.Name});
            }
            userSelectList = new List<SelectListItem>();
            foreach (var u in userManager.Users)
            {
                var i = new SelectListItem{ Value = u.Id, Text = u.Email};
                userSelectList.Add(i);
            }
        }

        public void OnGet()
        {
            
        }

        [BindProperty]
        public string formRoleName {get; set;}

        public List<SelectListItem> userSelectList {get;set;}
        public List<SelectListItem> roleSelectList {get;set;}

        public Dictionary<string,string> roleList {get;set;}
        

        public async Task<IActionResult> OnPostDeleteRoleAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (id != null)
            {
                var role = await _roleManager.FindByIdAsync(id);
                var result = await _roleManager.DeleteAsync(role);
            }

            return RedirectToPage();
        }

        
        public async Task<IActionResult> OnPostAddUserToRoleAsync(string selectedUser, string selectedRole)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (selectedUser != null)
            {
                var user = await _userManager.FindByIdAsync(selectedUser);
                var result = await _userManager.AddToRoleAsync(user, selectedRole);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteUserAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (id != null)
            {
                var user = await _userManager.FindByIdAsync(id);
                var result = await _userManager.DeleteAsync(user);
            }

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (formRoleName != null)
            {
                bool roleExists = await _roleManager.RoleExistsAsync(formRoleName);
                if (!roleExists)
                {    
                    var role = new IdentityRole();
                    role.Name = formRoleName;
                    await _roleManager.CreateAsync(role);
                }
            }
            return RedirectToPage();
        }
    }
}
