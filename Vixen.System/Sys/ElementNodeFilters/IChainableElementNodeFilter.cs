using System;
using System.Runtime.Serialization;
using Vixen.Module.ElementNodeFilter;

namespace Vixen.Sys.ElementNodeFilters
{
	public class IChainableElementNodeFilter
	{
		Guid Id { get; set; }
		ElementNodeFilterType Type { get; }

		string Name { get; set; }

		int ChainLevel { get; set; }

		string FilterName { get; }

		Guid FilterTypeId { get; set; }

		IElementNodeFilterInstance ElementNodeFilter { get; set; }
	}

	[DataContract]
	public enum ElementNodeFilterType
	{
		[EnumMember]
		Default,
		[EnumMember]
		Standard
	}
}
