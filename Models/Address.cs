
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HCServices.Models
{
    public class Address : IValidatableObject 
    {
        [Key]
        public int AddressID { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        
        public string Zip { get; set; }
        public string Country { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Zip.Length != 5)
            {
                results.Add(new ValidationResult("Zip must be 5 digits long"));
            }

            return results;
        }
    }
}