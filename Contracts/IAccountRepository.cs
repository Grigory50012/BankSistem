using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts(bool trackChenges);
        Account GetAccount(Guid idAccount, bool trackChenges);
    }
}
