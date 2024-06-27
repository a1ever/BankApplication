namespace MainLogic.Repository.Operations;

public interface ICreateObjectRepository<in T>
{
    void CreateObject(T value);
}