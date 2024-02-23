using Autoverleih_Backend.Db.Data;
using Autoverleih_Backend.Db.Repository;

namespace urlaubsplanungstool_backend.Db.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}