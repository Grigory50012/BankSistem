using System;

namespace Entities.DataTransferObjects
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
    }
}
