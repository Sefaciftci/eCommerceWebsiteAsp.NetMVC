
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eCommerce.Entities
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Required(ErrorMessage ="{0} Boş bırakılamaz")]
        [Display(Name = "Ad")]
        public string Adi { get; set; }
        [StringLength(50)  , Display(Name = "Soyad"), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public string Soyadi { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public string Email { get; set; }
        [StringLength(20)]
        public string? TelefonNo { get; set; }
        [StringLength(50)]
        public string? KullaniciAdi { get; set; }
        [Display(Name = "Şifre"), StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public string Sifre { get; set; }
        [Display(Name ="Eklenme tarihi") , ScaffoldColumn(false)]
        public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;
        [Display(Name = "Kullanıcı Rolü"), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        public int  RolId { get; set; }
        [Display(Name = "Kullanıcı Rolü")]
        public virtual Rol? Rol { get; set; }
    }
}
