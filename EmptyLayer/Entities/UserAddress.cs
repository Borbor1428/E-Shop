using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyLayer.Entities
{
    public class UserAddress
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string AddressName { get; set; }

        public string AddressLine1 { get; set; }
       
        public string AddressLine2 { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public string PostalCode { get; set; }

        public int Telephone { get; set; }

        public int MobilePhone { get; set; }
    }
}
