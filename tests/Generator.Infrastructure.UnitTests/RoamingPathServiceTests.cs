using System;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using Shouldly;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
    public class RoamingPathServiceTests
    {
        public static readonly object[][] GetPathData = new object[][]
        {
            new object[]{new string[]{"test1", "test2"}, $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\dotnet-new-template\\test1\\test2"},
            new object[]{new string[]{"test1", "test3"}, $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\dotnet-new-template\\test1\\test3"},
            new object[]{new string[]{"test1", "test2", "test3"}, $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\dotnet-new-template\\test1\\test2\\test3"},
        };
        
        [Theory, MemberData(nameof(GetPathData))]
        public void VerifyGetPathAlgorithm(string[] paths, string expected)
        {
            var mockFileSystem = new MockFileSystem();
            var service = new RoamingPathService(mockFileSystem);
            var result = service.GetPath(paths);
            result.ShouldBe(expected);
        }

        [Fact]
        public void VerifyDirectoryCreationForFileWorks()
        {
            var mockFileSystem = new MockFileSystem();
            var service = new RoamingPathService(mockFileSystem);
            var ts = DateTime.Now.Ticks;
            service.EnsureDirectoryExists(ts.ToString(),"file.json");
            var expectedDirectory = $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\dotnet-new-template\\{ts}";
            mockFileSystem.Directory.Exists(expectedDirectory).ShouldBeTrue();
        }

        [Fact]
        public void VerifyDirectoryCreationForDirectoryWorks()
        {
            var mockFileSystem = new MockFileSystem();
            var service = new RoamingPathService(mockFileSystem);
            var ts = DateTime.Now.Ticks;
            service.EnsureDirectoryExists(ts.ToString());
            var expectedDirectory = $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\dotnet-new-template\\{ts}";
            mockFileSystem.Directory.Exists(expectedDirectory).ShouldBeTrue();
        }
    }
}