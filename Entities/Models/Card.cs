using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Card
    {
        [Column("IdCard")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Card balance is required field.")]
        [Column(TypeName = "Money")]
        public decimal Balance { get; set; }

        [ForeignKey(nameof(Account))]
        public Guid IdAccount { get; set; }
        public Account Account { get; set; }
    }
}
