using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICardRepository
    {
        Task<Card> GetCardAsync(Guid idAccount, Guid idCard, bool trackChenges);
        Task<IEnumerable<Card>> GetCardsAsync(Guid idAccount, bool trackChenges);
        void CreateCard(Guid idAccount, Card card);
        void DeleteCard(Card card);
    }
}
