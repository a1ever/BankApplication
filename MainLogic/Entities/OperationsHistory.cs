using MainLogic.Models;

namespace MainLogic.Entities;

public class OperationsHistory
{
    private readonly List<Operation> _operations = new List<Operation>();
    public IReadOnlyList<Operation> Operations => _operations;

    public void AddOperation(Operation operation)
    {
        _operations.Add(operation);
    }
}