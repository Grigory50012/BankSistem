using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.ForUpdateDto
{
    public class CardForUpdateDto
    {
        [Required(ErrorMessage = "Balance is a required field.")]
        public decimal Balance { get; set; }
    }
}
