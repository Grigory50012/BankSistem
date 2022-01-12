using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync(bool trackChanges);
        Task<Account> GetAccountAsync(Guid idAccount, bool trackChanges);
        Task<IEnumerable<Account>> GetAccountsWithoutCardsAsync(bool trackChanges);
    }
}
