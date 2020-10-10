namespace cocktails.Models{
    public class Order{
        public int Id {get;set;}
        public string UserId {get;set;}
        public int CocktailId {get;set;}
        public string Stato {get;set;}
        public System.DateTime Dto {get;set;}
        public System.DateTime? Dto_Completato {get;set;}
        public int Id_Evento {get;set;}
    }
}