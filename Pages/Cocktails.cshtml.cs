using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using cocktails.Data;
using cocktails.Models;

namespace cocktails.Pages
{
    [Authorize(Roles = "bartenders, alcolizzati, minorenne")]
    public class CocktailsModel : PageModel
    {
        private readonly ILogger<CocktailsModel> _logger;
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<IdentityUser> _userManager;


        public CocktailsModel(ILogger<CocktailsModel> logger, ApplicationDbContext context ) //, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            //_userManager = userManager;
        }

        public void OnGet(int? id)
        {   
            if(id != null)
            {
                _context.ordini.Add(new Order{ UserId= User.Identity.Name , CocktailId = id.Value, Dto = System.DateTime.Now, Stato = "New"});
                _context.SaveChanges();
            }

        }

        // public void OnGet(int id)
        // {
        //     _context.ordini.Add(new Order{CocktailId = id, Dto = System.DateTime.Now});
        // }
    }
}
