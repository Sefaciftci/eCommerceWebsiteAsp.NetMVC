
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Entities
{
    public class Satis : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ürün")]
        public int AracId { get; set; }
        [Display(Name = "Müşteri")]
        public int MusteriId { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyati { get; set; }
        [Display(Name = "Satış Tarihi")]
        public DateTime SatisTarihi { get; set; }
        public virtual Urun? Arac { get; set; }
        [Display(Name = "Müşteri")]
        public virtual Musteri? Musteri { get; set; }

    }
}
