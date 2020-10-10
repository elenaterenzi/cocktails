namespace cocktails.Interfaces{
    using cocktails.Models;
    using System.Collections.Generic;
    public interface ICocktailService{
        List<Cocktail> GetCocktails(bool alcool = true);
    } 
}