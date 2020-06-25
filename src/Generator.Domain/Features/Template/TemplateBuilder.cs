using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Generator.Domain.Entities;

namespace Generator.Domain.Features.Template
{
	public class TemplateBuilder
	{
		[ExcludeFromCodeCoverage]
		private TemplateBuilder(){}
		
		private TemplateBuilder(TemplateContainer container)
		{
			_container = container;
		}

		private TemplateContainer _container;

		public Entities.Template ToTemplate() => _container.Template;

		public static TemplateBuilder FromContainer(TemplateContainer container)
		{
			if (container.Template == null)
				container.Template = new Entities.Template();
			
			return new TemplateBuilder(container);
		}

		public TemplateBuilder WithAuthor(string author)
		{
			_container.Template.Author = author;
			return this;
		}

		public TemplateBuilder WithDescription(string description)
		{
			_container.Template.Description = description;
			return this;
		}

		public TemplateBuilder WithIdentity(string identity)
		{
			_container.Template.Identity = identity;
			return this;
		}

		public TemplateBuilder WithName(string name)
		{
			_container.Template.Name = name;
			return this;
		}

		public TemplateBuilder WithSchema(string schema)
		{
			_container.Template.Schema = schema;
			return this;
		}

		public TemplateBuilder WithPrecedence(int precedence)
		{
			_container.Template.Precedence = precedence;
			return this;
		}

		public TemplateBuilder WithDefaultName(string defaultName)
		{
			_container.Template.DefaultName = defaultName;
			return this;
		}

		public TemplateBuilder WithGroupIdentity(string groupIdentity)
		{
			_container.Template.GroupIdentity = groupIdentity;
			return this;
		}

		public TemplateBuilder WithShortName(string shortName)
		{
			_container.Template.ShortName = shortName;
			return this;
		}

		public TemplateBuilder WithSourceName(string sourceName)
		{
			_container.Template.SourceName = sourceName;
			return this;
		}

		public TemplateBuilder WithPlaceholderFileName(string placeholderFileName)
		{
			_container.Template.PlaceholderFileName = placeholderFileName;
			return this;
		}

		public TemplateBuilder WithPreferNameDirectory(bool preferNameDirectory)
		{
			_container.Template.PreferNameDirectory = preferNameDirectory;
			return this;
		}

		public TemplateBuilder WithThirdPartyNotices(string thirdPartyNotices)
		{
			_container.Template.ThirdPartyNotices = thirdPartyNotices;
			return this;
		}

		public TemplateBuilder WithCodeLanguage(string language)
		{
			_container.Template.Tags.Language = language;
			return this;
		}

		public TemplateBuilder WithClassification(string classification)
		{
			var list = _container.Template.Classifications.ToList();
			list.Add(classification);
			_container.Template.Classifications = list.ToArray();
			return this;
		}

		public TemplateBuilder WithGuid(Guid guid)
		{
			var list = _container.Template.Guids.ToList();
			list.Add(guid);
			_container.Template.Guids = list.ToArray();
			return this;
		}

		public TemplateBuilder WithSource(SourceValue sourceValue)
		{
			var list = _container.Template.Sources.ToList();
			list.Add(sourceValue);
			_container.Template.Sources = list.ToArray();
			return this;
		}

		public TemplateBuilder WithSymbol(string key, BaseSymbol symbol)
		{
			if (_container.Template.Symbols.TryGetValue(key, out _))
			{
				_container.Template.Symbols[key] = symbol;
			}
			else
			{
				_container.Template.Symbols.Add(key, symbol);
			}
			
			return this;
		}
		
		/// <summary>
		/// Sets Tags.Type 
		/// </summary>
		/// <param name="type">Project/Item</param>
		/// <returns>builder instance</returns>
		public TemplateBuilder WithTemplateType(string type)
		{
			_container.Template.Tags.Type = type;
			return this;
		}
	}
}