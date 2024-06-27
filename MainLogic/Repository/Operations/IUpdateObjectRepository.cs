namespace MainLogic.Repository.Operations;

public interface IUpdateObjectRepository<in T>
{
    void UpdateObjectById(string id, T value);
}