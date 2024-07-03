using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerstaTest.DataAccess.Entities
{
     public class OrderEntity
    {
        public Guid Id { get; set; }
        public string RecipientCity { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;
        public string AddresserCity { get; set; } = string.Empty;
        public string AddresserAddress { get; set; } = string.Empty;
        public float CargoWeight { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
}
