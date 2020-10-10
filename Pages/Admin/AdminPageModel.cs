using cocktails.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cocktails.Pages.Admin
{
    public class AdminPageModel : PageModel
    {
        protected ApplicationDbContext _context { get; }
        protected IAuthorizationService _authorizationService { get; }
        protected UserManager<IdentityUser> _userManager { get; }
        protected RoleManager<IdentityRole> _roleManager { get; }

        public AdminPageModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager) : base()
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _roleManager = roleManager;
        } 
    }
}