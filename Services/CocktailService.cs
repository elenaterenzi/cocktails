using cocktails.Interfaces;
using cocktails.Models;
using cocktails.Data;
using System.Collections.Generic;
using System.Linq;

namespace cocktails.Services{

    public class CocktailService : ICocktailService {

        private readonly ApplicationDbContext _context;

        public CocktailService(ApplicationDbContext ctx){
            _context = ctx;
        }

        public List<Cocktail> GetCocktails(bool alcool = true){ 
            if (alcool)
                return _context.cocktails.ToList();
            else
                return _context.cocktails.Where(x=> !x.Alcool).ToList();
        }

    }
}