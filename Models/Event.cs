using System;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Event), nameof(ValidateDate))]
        public DateTime Date { get; set; }

        public static ValidationResult ValidateDate(DateTime date, ValidationContext context)
        {
            if (date < DateTime.Today)
                return new ValidationResult("Date cannot be in the past");
            return ValidationResult.Success;
        }
    }
}
