using MainLogic.Models;
using MainLogic.Repository.Operations;

namespace MainLogic.Repository;

public interface IHistoryRepository : ICreateObjectRepository<Operation>, IReadObjectRepository<Operation>, IReadAllObjectsRepository<Operation>
{
}