using Autoverleih_Backend.Db.Repository;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    int Complete();
}