using Generator.Domain.Resources;
using Generator.Domain.Utility;

namespace Generator.Domain.Features.Template
{
	public class TemplateNotFoundException : WellKnownException
	{
		public string TemplateId { get; }

		public TemplateNotFoundException(string templateId) 
			: base(Constants.WellKnownErrorCodes.TemplateDoesNotExist)
		{
			TemplateId = templateId;
		}
	}
	
	public class TemplateAlreadyExistsException : WellKnownException
	{
		public string TemplateId { get; }

		public TemplateAlreadyExistsException(string templateId) 
			: base(Constants.WellKnownErrorCodes.TemplateAlreadyExists)
		{
			TemplateId = templateId;
		}
	}
}