namespace MainLogic.Repository.Operations;

public interface IReadAllObjectsRepository<out T>
{
    IEnumerable<T> ReadObjects();
}