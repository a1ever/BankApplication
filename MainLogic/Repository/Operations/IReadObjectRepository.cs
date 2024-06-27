namespace MainLogic.Repository.Operations;

public interface IReadObjectRepository<out T>
{
    T? ReadObject(string id);
}