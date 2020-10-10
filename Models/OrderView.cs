namespace cocktails.Models{
    public class OrderView{
        public int Id {get;set;}
        public string Stato {get;set;}
        public System.DateTime Dto {get;set;}
        public System.DateTime? Dto_Completato {get;set;}
        public string UserName {get;set;}
        public string Cocktail {get;set;}
    }
}