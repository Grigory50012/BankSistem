using System;

namespace Entities.DataTransferObjects.ForCreationDto
{
    public class CardForCreationDto
    {
        public decimal Balance { get; set; }
        public Guid IdAccount { get; set; }
    }
}
