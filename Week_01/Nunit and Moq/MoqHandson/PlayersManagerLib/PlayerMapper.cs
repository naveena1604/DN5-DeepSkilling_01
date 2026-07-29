using System.Data.SqlClient;

namespace PlayersManagerLib;

public class PlayerMapper : IPlayerMapper
{
    private readonly string _connectionString =
        "Data Source=(local);Initial Catalog=GameDB;Integrated Security=True";

    public bool IsPlayerNameExistsInDb(string name)
    {
        // Database code is omitted because
        // Moq replaces this implementation during tests.
        return false;
    }

    public void AddNewPlayerIntoDb(string name)
    {
        // Database code is omitted because
        // Moq replaces this implementation during tests.
    }
}