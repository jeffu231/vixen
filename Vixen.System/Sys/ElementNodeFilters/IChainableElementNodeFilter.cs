using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Vixen.Module.ElementNodeFilter;

namespace Vixen.Sys.ElementNodeFilters
{
	public interface IChainableElementNodeFilter: INotifyPropertyChanged
	{
		Guid Id { get; set; }
		ElementNodeFilterType Type { get; }

		string Name { get; set; }

		int ChainLevel { get; set; }

		string FilterName { get; }

		Guid FilterTypeId { get; set; }

		IElementNodeFilterInstance ElementNodeFilter { get; set; }

		IChainableElementNodeFilter Clone();
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
