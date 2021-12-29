using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICardRepository
    {
        Task<Card> GetCardAsync(Guid idAccount, Guid idCard, bool trackChanges);
        Task<PagedList<Card>> GetCardsAsync(Guid idAccount, CardParameters employeeParameters, bool trackChanges);
        void CreateCard(Guid idAccount, Card card);
        void DeleteCard(Card card);
    }
}
