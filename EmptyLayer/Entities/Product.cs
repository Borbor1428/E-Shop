using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "İsim")]
        [StringLength(50, ErrorMessage = "Maksimum karakter sayısını geçtiniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = "Maksimum karakter sayısını geçtiniz")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Popüler")]

        public bool Popular { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Onay")]
        public bool IsApproved { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Resim")]

        public string Image { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Adet")]
        public int CategoryId { get; set; }
        public virtual List<Card> Cards { get; set; }
        public virtual List<Sales> Sales { get; set; }
        
    }
}
