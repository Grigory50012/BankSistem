using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Card
    {
        [Column("CardId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Card balance is required field.")]
        [Column(TypeName = "Money")]
        public decimal Balance { get; set; }

        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        [ForeignKey(nameof(Bank))]
        public Guid BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
