using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyLayer.Entities
{
    internal class Supplier
    {
        public int Id { get; set; }

        [Display(Name = "Firma İsmi")]
        public string Company_Name { get; set; }

        [Display(Name = "İletişim İsmi")]
        public string Contact_Name { get; set; }

        [Display(Name = "İletişim Başlığı")]
        public string Contact_Title { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        public int Email { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Posta Kodu")]
        public string PostalCode { get; set; }

        [Display(Name = "Web Sitesi")]
        public string Website { get; set; }

        [Display(Name = "Banka Bilgileri")]
        public string BankDetails { get; set; }

        [Display(Name = "Vergi Kimlik Numarası")]
        public string TaxId { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
