using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IAccountRepository Account { get; }
        ICardOwnerRepository CardOwner { get; }
        ICardRepository Card { get; }
        IOwnerStatusRepository OwnerStatus { get; }
        ISocialStatusRepository SocialStatus { get; }
        Task SaveAsync();
    }
}
