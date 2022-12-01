using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MiniSite.Models
{
    public class UserDataModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [MaxLength(20)]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last name")]
        [MaxLength(20)]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter date of birth")]
        [Display(Name = "Date of birth")]
        [MaxLength(12)]
        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }


        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email address")]
        [MaxLength(25)]
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        [Display(Name = "Address")]
        [MaxLength(100)]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        [Display(Name = "City")]
        [MaxLength(50)]
        [JsonProperty("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter country")]
        [Display(Name = "Country")]
        [MaxLength(50)]
        [JsonProperty("country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter zip code")]
        [Display(Name = "Zip code")]
        [MaxLength(10)]
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

    }
}

