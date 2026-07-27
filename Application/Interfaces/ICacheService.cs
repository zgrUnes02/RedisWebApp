namespace Application.Interfaces;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string cachKey);
    Task SetAsync<T>(string cachKey, T value, TimeSpan? expiration = null);
}
