namespace Generator.Domain.Services
{
    public interface IRoamingPathService
    {
        string GetPath(params string[] subPaths);
        void EnsureDirectoryExists(params string[] subPaths);
    }
}