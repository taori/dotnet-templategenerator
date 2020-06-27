using System.IO;
using System.IO.Abstractions;

namespace Generator.Domain.Extensions
{
	public static class FileExtensions
	{
		public static void EnsureDirectoryExists(this IFile source, string filePath)
		{
			var directoryName = Path.HasExtension(filePath)
				? Path.GetDirectoryName(filePath)
				: filePath;
			
			var directoryInfo = source.FileSystem.DirectoryInfo.FromDirectoryName(directoryName);
			if (!directoryInfo.Exists)
				directoryInfo.Create();
		}
	}
}