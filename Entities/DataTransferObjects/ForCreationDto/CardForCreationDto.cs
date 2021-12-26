using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.ForCreationDto
{
    public class CardForCreationDto
    {
        [Required(ErrorMessage = "Balance is a required field.")]
        public decimal Balance { get; set; }
        [Required(ErrorMessage = "Account is a required field.")]
        public Guid IdAccount { get; set; }
    }
}
