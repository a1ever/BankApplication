namespace Database.Entities;

public class DataBaseParameters
{
    private string _name;

    public DataBaseParameters(string name)
    {
        _name = name;
    }

    private static string MigrationsQuery()
    {
        return "CREATE TABLE users (Id VARCHAR PRIMARY KEY, Password INTEGER, Balance INTEGER);" +
               "CREATE TABLE history (Id VARCHAR, Amount INTEGER, IsRefill BOOLEAN, OperationId serial PRIMARY KEY);";
    }
}