using MainLogic.Models;
using MainLogic.Repository;
using Npgsql;

namespace Database.Entities;

public class UserRepository : IUserRepository
{
    private const string TableName = "users";
    private readonly string _conn;

    public UserRepository(string conn)
    {
        _conn = conn;
    }

    public void CreateObject(User value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));

        using var connection = new NpgsqlConnection(_conn);
        connection.Open();

        const string sqlRequest = $"INSERT INTO {TableName}  (Id, Password, Balance) VALUES (@id, @pin, 0)";

        using var npgsqlCommand = new NpgsqlCommand(sqlRequest, connection);
        npgsqlCommand.Parameters.AddWithValue("id", value.Id);
        npgsqlCommand.Parameters.AddWithValue("pin", value.Pin);
        npgsqlCommand.ExecuteNonQuery();
    }

    public User? ReadObject(string id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));

        using var connection = new NpgsqlConnection(_conn);
        connection.Open();

        const string sqlRequest = $"SELECT * FROM {TableName}  WHERE Id = @id";

        using var npgsqlCommand = new NpgsqlCommand(sqlRequest, connection);
        npgsqlCommand.Parameters.AddWithValue("id", id);
        using NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
        return !reader.Read() ? null : new User(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2));
    }

    public IEnumerable<User> ReadObjects()
    {
        using var connection = new NpgsqlConnection(_conn);
        connection.Open();

        const string sqlRequest = $"SELECT * FROM {TableName} ";

        using var npgsqlCommand = new NpgsqlCommand(sqlRequest, connection);
        using NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();

        while (reader.Read())
        {
            yield return new User(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2));
        }
    }

    public void UpdateObjectById(string id, User value)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        if (value is null) throw new ArgumentNullException(nameof(value));

        using var connection = new NpgsqlConnection(_conn);
        connection.Open();

        const string sqlRequest = $"UPDATE {TableName}  SET Id = @newId, Password = @newPassword, Balance = @newBalance WHERE Id = @id";

        using var npgsqlCommand = new NpgsqlCommand(sqlRequest, connection);
        npgsqlCommand.Parameters.AddWithValue("id", id);
        npgsqlCommand.Parameters.AddWithValue("newId", value.Id);
        npgsqlCommand.Parameters.AddWithValue("newPassword", value.Pin);
        npgsqlCommand.Parameters.AddWithValue("newBalance", value.Balance);

        npgsqlCommand.ExecuteNonQuery();
    }

    public void DeleteObjectById(string id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));

        using var connection = new NpgsqlConnection(_conn);
        connection.Open();

        const string sqlRequest = $"DELETE FROM {TableName}  WHERE Id = @id";

        using var npgsqlCommand = new NpgsqlCommand(sqlRequest, connection);
        npgsqlCommand.Parameters.AddWithValue("id", id);

        npgsqlCommand.ExecuteNonQuery();
    }
}