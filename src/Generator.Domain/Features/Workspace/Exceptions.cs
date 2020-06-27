using Generator.Domain.Resources;
using Generator.Domain.Utility;

namespace Generator.Domain.Features.Workspace
{
	public class WorkspaceNotFoundException : WellKnownException
	{
		public string WorkspaceName { get; set; }
		
		public WorkspaceNotFoundException(string workspaceName) 
			: base(Constants.WellKnownErrorCodes.WorkspaceDoesNotExist)
		{
			WorkspaceName = workspaceName;
		}
	}
	public class WorkspaceAlreadyExistsException : WellKnownException
	{
		public string WorkspaceName { get; set; }
		
		public WorkspaceAlreadyExistsException(string workspaceName) 
			: base(Constants.WellKnownErrorCodes.WorkspaceAlreadyExists)
		{
			WorkspaceName = workspaceName;
		}
	}
}