using FridgeManager.Database.Repositories;
using FridgeManager.Interfaces;
using FridgeManager.Interfaces.Repositories;

namespace FridgeManager.Database
{
    public class RepositoryManager : IRepositoryManager
    {
        private FridgeManagerDbContext _dbContext;

        private IFridgeRepository _fridgeRepository;
        private IProductRepository _productRepository;
        private IFridgeModelRepository _modelRepository;
        private IFridgeProductRepository _fridgeProductRepository;
        private IUserRepository _userRepository;

        public RepositoryManager(FridgeManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IFridgeRepository FridgeRepository
        {
            get
            {
                if (_fridgeRepository == null)
                {
                    _fridgeRepository = new FridgeRepository(_dbContext);
                }
                return _fridgeRepository;
            }
        }


        public IFridgeModelRepository FridgeModelRepository
        {
            get
            {
                if (_modelRepository == null)
                {
                    _modelRepository = new FridgeModelRepository(_dbContext);
                }
                return _modelRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }
                return _productRepository;
            }
        }

        public IFridgeProductRepository FridgeProductRepository
        {
            get
            {
                if (_fridgeProductRepository == null)
                {
                    _fridgeProductRepository = new FridgeProductRepository(_dbContext);
                }
                return _fridgeProductRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public void Save() => _dbContext.SaveChanges();
    }
}

