using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Vixen.Annotations;
using Vixen.Module.ElementNodeFilter;
using Vixen.Services;

namespace Vixen.Sys.ElementNodeFilters
{
	public abstract class ChainableElementNodeFilterBase: IChainableElementNodeFilter, IEquatable<ChainableElementNodeFilterBase>, IEqualityComparer<ChainableElementNodeFilterBase>, INotifyPropertyChanged
	{
		private IElementNodeFilterInstance _elementNodeFilter;
		private string __name;
		private ElementNodeFilterType _type;
		private int _chainLevel;

		protected ChainableElementNodeFilterBase()
		{
			Id = Guid.NewGuid();
		}

		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public ElementNodeFilterType Type
		{
			get => _type;
			protected set
			{
				if (value == _type) return;
				_type = value;
				OnPropertyChanged();
			}
		}

		[DataMember]
		public int ChainLevel
		{
			get => _chainLevel;
			set
			{
				if (value == _chainLevel) return;
				_chainLevel = value;
				OnPropertyChanged();
			}
		}

		[DataMember]
		public string Name
		{
			get => __name;
			set
			{
				if (value == __name) return;
				__name = value;
				OnPropertyChanged();
			}
		}

		public string FilterName => ElementNodeFilter != null ? ElementNodeFilter.Descriptor.TypeName : "None";

		public Guid FilterTypeId
		{
			get => ElementNodeFilter?.Descriptor.TypeId ?? Guid.Empty;
			set
			{
				if (ElementNodeFilter != null && ElementNodeFilter.Descriptor.TypeId != value)
				{
					ElementNodeFilter = ElementNodeFilterService.Instance.GetInstance(value);
				} 
			}
		}

		public IElementNodeFilterInstance ElementNodeFilter
		{
			get => _elementNodeFilter;
			set
			{
				if (Equals(value, _elementNodeFilter)) return;
				_elementNodeFilter = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FilterName));
				OnPropertyChanged(nameof(FilterTypeId));
			}
		}

		#region Implementation of IEquatable<ChainableElementNodeFilter>

		/// <inheritdoc />
		public bool Equals(ChainableElementNodeFilterBase other)
		{
			return Id == other?.Id;
		}

		#endregion

		#region Implementation of IEqualityComparer<in ChainableElementNodeFilter>

		/// <inheritdoc />
		public bool Equals(ChainableElementNodeFilterBase x, ChainableElementNodeFilterBase y)
		{
			if (x == null || y == null) return false;
			return x.Id == y.Id;
		}

		/// <inheritdoc />
		public int GetHashCode(ChainableElementNodeFilterBase obj)
		{
			return obj.Id.GetHashCode();
		}

		#endregion

		#region Implementation of INotifyPropertyChanged

		/// <inheritdoc />
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion



	}
}
