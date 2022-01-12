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
            => await FindAll(trackChanges).ToListAsync();

        public async Task<Account> GetAccountAsync(Guid idAccount, bool trackChanges)
            => await FindByCondition(account => account.Id.Equals(idAccount), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Account>> GetAccountsWithoutCardsAsync(bool trackChanges)
            => await ExecQuery("EXEC GetAccountsWithoutCards", trackChanges).ToListAsync();
    }
}
