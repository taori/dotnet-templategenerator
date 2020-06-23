using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Generator.Domain.Services;

namespace Generator.Infrastructure
{
    public class RoamingPathService : IRoamingPathService
    {
        private readonly IFileSystem _fileSystem;
        private const string ApplicationName = "dotnet-new-template";
        
        public RoamingPathService(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string GetPath(params string[] subPaths)
        {
            var merged = new string[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ApplicationName
            }.Concat(subPaths).ToArray();
            
            return _fileSystem.Path.Combine(merged);
        }

        public void EnsureDirectoryExists(params string[] subPaths)
        {
            var path = GetPath(subPaths);
            if (Path.HasExtension(path))
            {
                var directoryInfo = _fileSystem.DirectoryInfo.FromDirectoryName(Path.GetDirectoryName(path));
                if(!directoryInfo.Exists)
                    directoryInfo.Create();
            }
            else
            {
                var directoryInfo = _fileSystem.DirectoryInfo.FromDirectoryName(path);
                if(!directoryInfo.Exists)
                    directoryInfo.Create();
            }
        }
    }
}