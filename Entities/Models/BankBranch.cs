using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class BankBranch
    {
        [Column("IdBankBranch")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Town))]
        public Guid IdTown { get; set; }
        public Town Town { get; set; }

        [ForeignKey(nameof(Bank))]
        public Guid IdBank { get; set; }
        public Bank Bank { get; set; }
    }
}
