using System.ComponentModel.DataAnnotations;

namespace BlazorAppServerDB.Models
{
	public class Person
	{
        public int ID { get; set; }
		[Required(ErrorMessage = "Name is required.")]
		[StringLength(50, ErrorMessage = "Name must be no more than 50 characters.")]
		public string? FirstName { get; set; }
		[Required(ErrorMessage = "Name is required.")]
		[StringLength(50, ErrorMessage = "Name must be no more than 50 characters.")]
		public string? LastName { get; set; }
        [Range(1, 120, ErrorMessage = "Age should be 1 to 120.")]
        public int Age { get; set; }
        [EmailAddress(ErrorMessage = "Email is not a valid email address.")]
        [StringLength(100, ErrorMessage = "Email must be no more than 100 characters.")]
        public string? Email { get; set; }
        public int? CountryID { get; set; }
		// Navigation
		public Country? Country { get; set; }
    }
}
