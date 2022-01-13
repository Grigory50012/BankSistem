using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync(bool trackChanges)
            => await FindAll(trackChanges)
            .Include(account => account.CardOwner)
            .ToListAsync();

        public async Task<Account> GetAccountAsync(Guid idAccount, bool trackChanges)
            => await FindByCondition(account => account.Id.Equals(idAccount), trackChanges)
            .Include(account => account.CardOwner)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Account>> GetAccountsWithoutCardsAsync(bool trackChanges)
        {
            List<Account> accounts = await ExecQuery("EXEC GetAccountsWithoutCards", trackChanges)
                       .ToListAsync();

            List<Account> accountsResult = new List<Account>();
            for(int i = 0; i < accounts.Count; i++)
            {
                Guid idAccount = accounts[i].Id;
                Account currentAccount = await GetAccountAsync(idAccount, false);
                accountsResult.Add(currentAccount);
            }

            return accountsResult;
        }
    }
}
