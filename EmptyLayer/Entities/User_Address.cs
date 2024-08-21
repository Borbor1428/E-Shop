using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyLayer.Entities
{
    public class User_Address
    {
        public int Id { get; set; }

        public int User_Id { get; set; }
        public virtual User User { get; set; }

        public string Address_Name { get; set; }

        public string Address_Line_1 { get; set; }

        public string Address_Line_2 { get; set; }

        public string City { get; set; }

        public string Postal_Code { get; set; }

        public int Telephone { get; set; }

        public int Mobile_Phone { get; set; }
    }
}
