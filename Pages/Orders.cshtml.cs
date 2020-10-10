using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using cocktails.Data;

namespace cocktails.Pages
{
    [Authorize(Roles = "bartenders")]
    public class OrdersModel : PageModel
    {
        private readonly ILogger<OrdersModel> _logger;
        private readonly ApplicationDbContext _context;

        public OrdersModel(ILogger<OrdersModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet(int? id)
        {
            if(id != null)
            {
                var orderid = (int) id;
                var o = _context.ordini.Find(orderid);
                o.Dto_Completato = System.DateTime.Now;
                o.Stato = "Fatto";
                _context.ordini.Update(o);
                _context.SaveChanges();
            }
        }
    }
}
