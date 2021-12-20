using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetCards(Guid idAccount, bool trackChenges);
    }
}
