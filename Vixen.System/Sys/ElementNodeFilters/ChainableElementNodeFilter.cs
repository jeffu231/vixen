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
	public abstract class ChainableElementNodeFilter: IChainableElementNodeFilter, IEquatable<ChainableElementNodeFilter>, IEqualityComparer<ChainableElementNodeFilter>, INotifyPropertyChanged
	{

		private IElementNodeFilterInstance _elementNodeFilter;
		private string __name;
		private ElementNodeFilterType _type;
		private int _chainLevel;

		public ChainableElementNodeFilter()
		{
			Id = Guid.NewGuid();
		}

		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public ElementNodeFilterType Type
		{
			get { return _type; }
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

		public string FilterName
		{
			get { return ElementNodeFilter != null ? ElementNodeFilter.Descriptor.TypeName : "None"; }
		}

		public Guid FilterTypeId
		{
			get => ElementNodeFilter?.Descriptor.TypeId ?? Guid.Empty;
			set => ElementNodeFilter = ElementNodeFilterService.Instance.GetInstance(value);
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
		public bool Equals(ChainableElementNodeFilter other)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IEqualityComparer<in ChainableElementNodeFilter>

		/// <inheritdoc />
		public bool Equals(ChainableElementNodeFilter x, ChainableElementNodeFilter y)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public int GetHashCode(ChainableElementNodeFilter obj)
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
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion



	}
}
