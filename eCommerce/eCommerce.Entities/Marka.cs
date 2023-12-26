
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Entities
{
    public class Marka : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz")]
        [Display(Name = "Adı")]
        public string Adi { get; set; }
    }
}
