using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IAccountRepository _accountRepository;
        private ICardOwnerRepository _cardOwnerRepository;
        private ICardRepository _cardRepository;
        private IOwnerStatusRepository _ownerStatusRepository;
        private ISocialStatusRepository _socialStatusRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_repositoryContext);
                return _accountRepository;
            }
        }

        public ICardOwnerRepository CardOwner
        {
            get
            {
                if (_cardOwnerRepository == null)
                    _cardOwnerRepository = new CardOwnerRepository(_repositoryContext);
                return _cardOwnerRepository;
            }
        }

        public ICardRepository Card
        {
            get
            {
                if (_cardRepository == null)
                    _cardRepository = new CardRepository(_repositoryContext);
                return _cardRepository;
            }
        }

        public IOwnerStatusRepository OwnerStatus
        {
            get
            {
                if (_ownerStatusRepository == null)
                    _ownerStatusRepository = new OwnerStatusRepository(_repositoryContext);
                return _ownerStatusRepository;
            }
        }

        public ISocialStatusRepository SocialStatus
        {
            get
            {
                if (_socialStatusRepository == null)
                    _socialStatusRepository = new SocialStatusRepository(_repositoryContext);
                return _socialStatusRepository;
            }
        }

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
