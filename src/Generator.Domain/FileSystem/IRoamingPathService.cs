namespace Generator.Domain.FileSystem
{
    public interface IRoamingPathService
    {
        string GetPath(params string[] subPaths);
        void EnsureDirectoryExists(params string[] subPaths);
    }
}