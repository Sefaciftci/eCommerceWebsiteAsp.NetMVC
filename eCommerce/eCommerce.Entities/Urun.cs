
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eCommerce.Entities
{
    //codeFirst yöntemi ile db oluşturulur
    public class Urun : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public int MarkaId { get; set; }

        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public string Formu { get; set; }
        [Display(Name = "Fıyatı")]
        public decimal Fiyat { get; set; }
        public int Miktari { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public string Aromasi { get; set; }
        [Display(Name = "Üretim yılı")]
        public int UretimYili  { get; set; }
        [Display(Name = "Satışta mı?")]
        public bool SatistaMi{ get; set; }
        [Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public string Notlar { get; set; }
        
        [StringLength(100)]
        public string Resim1 { get; set; }
        public  virtual Marka? Marka { get; set; }

    }
}
