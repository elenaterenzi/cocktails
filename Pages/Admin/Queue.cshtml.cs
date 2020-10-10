
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using cocktails.Data;

namespace cocktails.Pages.Admin
{
    public class QueueModel : AdminPageModel
    {
        private readonly ILogger<QueueModel> _logger;

        public QueueModel(
                    ILogger<QueueModel> logger,
                    ApplicationDbContext context,
                    IAuthorizationService authorizationService,
                    UserManager<IdentityUser> userManager,
                    RoleManager<IdentityRole> roleManager) : base(context, authorizationService, userManager, roleManager)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
