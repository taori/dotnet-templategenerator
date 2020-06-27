namespace Generator.Domain.Resources
{
	public class Constants
	{
		public class Paths
		{
			public const string Workspace = "workspace";
			public const string Templates = "templates";
			public const string SettingsFile = "settings.json";
		}
		
		public class WellKnownErrorCodes
		{
			public const int WorkspaceAlreadyExists = 2;
			public const int WorkspaceDoesNotExist = 3;
			public const int TemplateDoesNotExist = 4;
			public const int TemplateAlreadyExists = 5;
		}
	}
}