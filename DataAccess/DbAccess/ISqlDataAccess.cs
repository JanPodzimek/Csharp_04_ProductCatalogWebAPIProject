using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess;
public interface ISqlDataAccess
{
    IConfiguration _config { get; }

    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultConnection");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
}