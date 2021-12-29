using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IAccountRepository Account { get; }
        IBankBranchRepository BankBranch { get; }
        IBankRepository Bank { get; }
        ICardOwnerRepository CardOwner { get; }
        ICardRepository Card { get; }
        IOwnerStatusRepository OwnerStatus { get; }
        ISocialStatusRepository SocialStatus { get; }
        ITownRepository Town { get; }
        Task SaveAsync();
    }
}
