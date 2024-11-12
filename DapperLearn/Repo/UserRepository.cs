using Dapper;
using DapperLearn.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperLearn.Repo;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<User> GetUsers()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<User>("SELECT * FROM Users").ToList();
        }
    }

    public User Get(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @id", new { id });
        }
    }

    public void Create(User user)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            db.Execute("INSERT INTO Users (Name, Age) VALUES (@Name, @Age)", user);
        }
    }

    public void Update(User user)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            db.Execute("UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id", user);
        }
    }

    public void Delete(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            db.Execute("DELETE FROM Users WHERE Id = @id", new { id });
        }
    }
}
