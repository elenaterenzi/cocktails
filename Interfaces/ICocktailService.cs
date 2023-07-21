namespace cocktails.Interfaces{
    using cocktails.Models;
    using System.Collections.Generic;
    public interface ICocktailService{
        List<CocktailView> GetCocktails(bool alcool = true);
    } 
}