using System;
using System.Collections.ObjectModel;
using System.Linq;
using Catel.Data;
using Catel.MVVM;
using Vixen.Module;
using Vixen.Module.ElementNodeFilter;
using Vixen.Sys.ElementNodeFilters;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public class ElementNodeFilterViewModel : ViewModelBase
	{

		public ElementNodeFilterViewModel(IChainableElementNodeFilter filter)
		{
			Filter = filter;
		}

		#region Filter model property

		/// <summary>
		/// Gets or sets the Filter value.
		/// </summary>
		[Model]
		public IChainableElementNodeFilter Filter
		{
			get { return GetValue<IChainableElementNodeFilter>(FilterProperty); }
			private set { SetValue(FilterProperty, value); }
		}

		/// <summary>
		/// Filter property data.
		/// </summary>
		public static readonly PropertyData FilterProperty = RegisterProperty("Filter", typeof(IChainableElementNodeFilter));

		#endregion

		#region StandardFilters property

		/// <summary>
		/// Gets or sets the StandardFilters value.
		/// </summary>
		public ObservableCollection<IModuleDescriptor> StandardFilters
		{
			get
			{
				if (ParentViewModel is ElementNodeFilterDockerViewModel pm)
				{
					return pm.StandardFilters;
				}

				return new ObservableCollection<IModuleDescriptor>();
			}
		
		}

		#endregion

		#region Name property

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		[ViewModelToModel("Filter")]
		public string Name
		{
			get { return GetValue<string>(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		/// <summary>
		/// Name property data.
		/// </summary>
		public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string), null);

		#endregion

		#region FilterTypeId property

		/// <summary>
		/// Gets or sets the FilterTypeId value.
		/// </summary>
		[ViewModelToModel("Filter")]
		public Guid FilterTypeId
		{
			get { return GetValue<Guid>(FilterTypeIdProperty); }
			set
			{
				SetValue(FilterTypeIdProperty, value);
				FilterChanged();
			}
		}

		/// <summary>
		/// FilterTypeId property data.
		/// </summary>
		public static readonly PropertyData FilterTypeIdProperty = RegisterProperty("FilterTypeId", typeof(Guid), null);

		#endregion
		
		#region ConfigureFilter command

		private Command _configureFilterCommand;

		/// <summary>
		/// Gets the ConfigureFilter command.
		/// </summary>
		public Command ConfigureFilterCommand
		{
			get { return _configureFilterCommand ?? (_configureFilterCommand = new Command(ConfigureFilter, CanConfigureFilter)); }
		}

		/// <summary>
		/// Method to invoke when the ConfigureFilter command is executed.
		/// </summary>
		private void ConfigureFilter()
		{
			if (Filter.ElementNodeFilter.HasSetup)
			{
				if (Filter.ElementNodeFilter.Setup())
				{
					OnFilterUpdated();
				}
			}
		}

		/// <summary>
		/// Method to check whether the ConfigureFilter command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanConfigureFilter()
		{
			return true;
		}

		#endregion

		private bool IsStandardName()
		{
			return StandardFilters.Any(x => x.TypeName.Equals(Name));
		}

		private void FilterChanged()
		{
			if (IsStandardName())
			{
				Name = Filter.ElementNodeFilter.Descriptor.TypeName;
			}
			OnFilterUpdated();
		}


		private void OnFilterUpdated()
		{
			if (ParentViewModel is ElementNodeFilterDockerViewModel pm)
			{
				pm.OnFiltersChanged(new EventArgs());
			}
		}
	}
}
