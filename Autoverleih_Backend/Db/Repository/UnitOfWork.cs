using Autoverleih_Backend.Db.Data;
using Autoverleih_Backend.Db.Repository;

namespace urlaubsplanungstool_backend.Db.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public IUserRepository Users { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}