namespace SahafWebAPI.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string? Kullanici_Adi { get; set; }
        public DateTime? KitapOdüncAlma { get; set; } 
        public DateTime? KitapOdüncIade { get; set; } 
        public int? Kitap_Id { get; set; }
    }
}
