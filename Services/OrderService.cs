using cocktails.Interfaces;
using cocktails.Models;
using cocktails.Data;
using System.Collections.Generic;
using System.Linq;

namespace cocktails.Services{

    public class OrderService : IOrderService {

        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext ctx){
            _context = ctx;
        }

        public List<OrderView> GetOrdersByUser(string username)
        {
            var orders = _context.v_ordini.Where(x=>x.UserName ==username & x.Dto_Completato==null).OrderBy(x=> x.Dto);
            return orders.ToList();
        }

        public List<OrderView> GetOrders(){ 
            var dafare = _context.v_ordini.Where(x => x.Dto_Completato == null).OrderBy(x=> x.Dto).ToList();
            var fatti = _context.v_ordini.Where(x => x.Dto_Completato != null).OrderByDescending(x => x.Dto_Completato);
            dafare.AddRange(fatti);
            return dafare;
        }

    }
}