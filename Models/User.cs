using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HCServices.Models
{
    public class User : IValidatableObject
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public int Age { get; set; }
       
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Hobbies { get; set; }
        public bool IsActive { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Age.ToString().Length>3)
            {
                results.Add(new ValidationResult("Age cannot be greater than 3 digits"));
            }

            if (Phone.Length != 10)
            {
                results.Add(new ValidationResult("Phone must be 10 digits long"));
            }       

            return results;
        }
    }
}