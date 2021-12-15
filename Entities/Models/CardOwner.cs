using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CardOwner
    {
        [Column("IdCardOwner")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Account name is required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Name is 40 characters.")]
        public string Name { get; set; }

        public ICollection<OwnerStatus> OwnerStatuses { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
