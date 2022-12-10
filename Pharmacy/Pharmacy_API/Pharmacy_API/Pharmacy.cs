
using System.ComponentModel.DataAnnotations;

namespace Pharmacy_API
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}
