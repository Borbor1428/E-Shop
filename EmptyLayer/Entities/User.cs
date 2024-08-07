using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Maksimum karakter sayısını geçtiniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Maksimum karakter sayısını geçtiniz")]
        public  string Surname { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "E-Posta")]
        [StringLength(50, ErrorMessage = "Maksimum karakter sayısını geçtiniz")]
        [EmailAddress(ErrorMessage ="E-Posta formatı şeklinde giriniz")]

        public string Mail { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50, ErrorMessage = "Maksimum karakter sayısını geçtiniz")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Şifre")]
        [StringLength(10, ErrorMessage = "Maksimum 10 karakter olmalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Şifre Tekrarı")]
        [StringLength(10, ErrorMessage = "Maksimum 10 karakter olmalıdır")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Hata!Girilen şifre ile uyuşmamaktadır")]

        public string RePassword { get; set; }

        public string Role { get; set; }


    }
}
