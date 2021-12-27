using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IAccountRepository _accountRepository;
        private IBankBranchRepository _bankBranchRepository;
        private IBankRepository _bankRepository;
        private ICardOwnerRepository _cardOwnerRepository;
        private ICardRepository _cardRepository;
        private IOwnerStatusRepository _ownerStatusRepository;
        private ISocialStatusRepository _socialStatusRepository;
        private ITownRepository _townRepository;

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

        public IBankBranchRepository BankBranch
        {
            get
            {
                if (_bankBranchRepository == null)
                    _bankBranchRepository = new BankBranchRepository(_repositoryContext);
                return _bankBranchRepository;
            }
        }

        public IBankRepository Bank
        {
            get
            {
                if (_bankRepository == null)
                    _bankRepository = new BankRepository(_repositoryContext);
                return _bankRepository;
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

        public ITownRepository Town
        {
            get
            {
                if (_townRepository == null)
                    _townRepository = new TownRepository(_repositoryContext);
                return _townRepository;
            }
        }

        public void SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
