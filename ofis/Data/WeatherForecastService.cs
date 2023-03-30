using SQLite;
using System.Threading.Tasks;

namespace ofis.Data;
public class WeatherForecastService
{
    string _dbPath;
    public string StatusMessage { get; set; }
    private SQLiteAsyncConnection conn;
    public WeatherForecastService(string dbPath)
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
        await conn.CreateTableAsync<WeatherForecast>();
        await conn.CreateTableAsync<Tahsilatlar>();
    }
    public async Task<List<WeatherForecast>> GetForecastAsync()
    {
        await InitAsync();
        return await conn.Table<WeatherForecast>().OrderBy(f =>f.Unvan).ToListAsync();
    }
    public async Task<WeatherForecast> CreateForecastAsync(
        WeatherForecast paramWeatherForecast)
    {
        // Insert
        await conn.InsertAsync(paramWeatherForecast);
        // return the object with the
        // auto incremented Id populated
        return paramWeatherForecast;
    }
    public async Task<WeatherForecast> UpdateForecastAsync(
        WeatherForecast paramWeatherForecast)
    {
        // Update
        await conn.UpdateAsync(paramWeatherForecast);
        // Return the updated object
        return paramWeatherForecast;
    }
    public async Task<WeatherForecast> DeleteForecastAsync(
        WeatherForecast paramWeatherForecast)
    {
        // Delete
        await conn.DeleteAsync(paramWeatherForecast);
        return paramWeatherForecast;
    }


    public async Task<List<Tahsilatlar>> GetTahsilatAsync(string selectedUnvan)
    {
        await InitAsync();
        return await conn.Table<Tahsilatlar>().Where(f => f.Unvan == selectedUnvan).OrderByDescending(f => f.Tarih).ToListAsync();
    }
    public async Task<List<Tahsilatlar>> GetTahsilatTUMAsync()
    {
        await InitAsync();
        return await conn.Table<Tahsilatlar>().OrderByDescending(f => f.Tarih).ToListAsync();
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