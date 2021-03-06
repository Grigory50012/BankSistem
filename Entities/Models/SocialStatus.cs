using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class SocialStatus
    {
        [Column("IdSocialStatus")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Social Status name is required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
        public string Name { get; set; }

        public ICollection<OwnerStatus> OwnerStatuses { get; set; }
    }
}
