﻿using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Account> GetAllAccounts(bool trackChenges)
            => FindAll(trackChenges).ToList();

        public Account GetAccount(Guid idAccount, bool trackChenges)
            => FindByCondition(account => account.Id.Equals(idAccount), trackChenges).SingleOrDefault();
    }
}
