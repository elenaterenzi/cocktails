using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using cocktails.Data;

namespace cocktails.Pages
{
    [Authorize(Roles = "bartenders")]
    public class IngredientModel : PageModel
    {
        private readonly ILogger<IngredientModel> _logger;
        private readonly ApplicationDbContext _context;

        public IngredientModel(ILogger<IngredientModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet(int? id)
        {
            if(id != null)
            {
                var ingredientid = (int) id;
                var i = _context.ingredienti.Find(ingredientid);
                i.Available = !i.Available;
                _context.ingredienti.Update(i);
                _context.SaveChanges();
            }
        }
    }
}
