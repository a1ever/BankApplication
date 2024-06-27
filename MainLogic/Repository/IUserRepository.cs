using MainLogic.Models;
using MainLogic.Repository.Operations;

namespace MainLogic.Repository;

public interface IUserRepository : ICreateObjectRepository<User>, IReadObjectRepository<User>, IUpdateObjectRepository<User>, IDeleteObjectRepository, IReadAllObjectsRepository<User>
{
}