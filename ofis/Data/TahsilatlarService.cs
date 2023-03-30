using SQLite;
using System.Threading.Tasks;
namespace ofis.Data;


public class TahsilatlarService
{

    string _dbPath;
    public string StatusMessage { get; set; }
    private SQLiteAsyncConnection conn;

    public TahsilatlarService(string dbPath)
    {
        _dbPath = dbPath;
    }
    private async Task InitAsync()
    {
        // Don't Create database if it exists
        if (conn != null)
            return;
        // Create database and WeatherForecast Table
        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<Tahsilatlar>();
    }
    public async Task<List<Tahsilatlar>> GetForecastAsync(string selectedUnvan)
    {
        await InitAsync();
        return await conn.Table<Tahsilatlar>().Where(f => f.Unvan == selectedUnvan).OrderByDescending(f => f.Tarih).ToListAsync();
    }
    public async Task<Tahsilatlar> CreateTahsilatAsync(
        Tahsilatlar paramTahsilatTutar)
    {
        // Insert
        await conn.InsertAsync(paramTahsilatTutar);
        // return the object with the
        // auto incremented Id populated
        return paramTahsilatTutar;
    }

    public async Task<Tahsilatlar> UpdateTahsilatAsync(
       Tahsilatlar paramTahsilatTutar)
    {
        // Update
        await conn.UpdateAsync(paramTahsilatTutar);
        // Return the updated object
        return paramTahsilatTutar;
    }
    public async Task<Tahsilatlar> DeleteTahsilatAsync(
        Tahsilatlar paramTahsilatTutar)
    {
        // Delete
        await conn.DeleteAsync(paramTahsilatTutar);
        return paramTahsilatTutar;
    }

}
