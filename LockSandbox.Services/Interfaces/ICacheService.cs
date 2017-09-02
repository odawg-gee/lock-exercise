namespace LockSandbox.Services.Interfaces
{
    internal interface ICacheService
    {
        void SetCache<TData>(TData data, string key, long seconds);
        TData GetCache<TData>(string key);
    }
}