using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts(bool trackChenges);
    }
}
