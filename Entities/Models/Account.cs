using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Account
    {
        [Column("AccountId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Account name is required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Name is 40 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Account balance is required field.")]
        [Column(TypeName ="Money")]
        public decimal Balance { get; set; }

        [ForeignKey(nameof(SocialStatus))]
        public Guid SocialStatusId { get; set; }
        public SocialStatus SocialStatus { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
