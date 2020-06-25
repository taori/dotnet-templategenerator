namespace Generator.Domain.Features.Workspace
{
	public class Workspace : IWorkspace
	{
		public Workspace(string directory)
		{
			Directory = directory;
		}

		public string Directory { get; set; }
	}
}