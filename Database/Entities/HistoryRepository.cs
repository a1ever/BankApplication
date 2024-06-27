using MainLogic.Models;
using MainLogic.Repository;
using Npgsql;

namespace Database.Entities;

public class HistoryRepository : IHistoryRepository
{
    private const string TableName = "history";
    private readonly string _conn;

    public HistoryRepository(string conn)
    {
        _conn = conn;
    }

    public void CreateObject(Operation value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));

        using var connection = new NpgsqlConnection(_conn);
        connection.Open();

        const string sqlRequest = $"INSERT INTO {TableName} (Id, Amount, IsRefill) VALUES (@id, @amount, @isRefill)";

        using var npgsqlCommand = new NpgsqlCommand(sqlRequest, connection);
        npgsqlCommand.Parameters.AddWithValue("id", value.Id);
        npgsqlCommand.Parameters.AddWithValue("amount", value.Amount);
        npgsqlCommand.Parameters.AddWithValue("isRefill", value.IsRefill);
        npgsqlCommand.ExecuteNonQuery();
    }

    public Operation? ReadObject(string id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));

        using var connection = new NpgsqlConnection(_conn);
        connection.Open();

        const string sqlRequest = $"SELECT * FROM {TableName} WHERE Id = @id";

        using var npgsqlCommand = new NpgsqlCommand(sqlRequest, connection);
        npgsqlCommand.Parameters.AddWithValue("id", id);
        using NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
        return !reader.Read() ? null : new Operation(reader.GetString(0), reader.GetInt32(1), reader.GetBoolean(2));
    }

    public IEnumerable<Operation> ReadObjects()
    {
        using var connection = new NpgsqlConnection(_conn);
        connection.Open();

        const string sqlRequest = $"SELECT * FROM {TableName}";

        using var npgsqlCommand = new NpgsqlCommand(sqlRequest, connection);
        using NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();

        while (reader.Read())
        {
            yield return new Operation(reader.GetString(0), reader.GetInt32(1), reader.GetBoolean(2));
        }
    }
}