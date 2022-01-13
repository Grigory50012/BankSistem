using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Account
    {
        [Column("IdAccount")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Account balance is required field.")]
        [Column(TypeName = "Money")]
        public decimal Balance { get; set; }

        [ForeignKey(nameof(CardOwner))]
        public Guid IdCardOwner { get; set; }
        public CardOwner CardOwner { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
