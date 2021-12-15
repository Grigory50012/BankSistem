using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class OwnerStatus
    {
        [Column("IdOwnerStatus")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(SocialStatus))]
        public Guid IdSocialStatus { get; set; }
        public SocialStatus SocialStatus { get; set; }

        [ForeignKey(nameof(CardOwner))]
        public Guid IdCardOwner { get; set; }
        public CardOwner CardOwner { get; set; }
    }
}
