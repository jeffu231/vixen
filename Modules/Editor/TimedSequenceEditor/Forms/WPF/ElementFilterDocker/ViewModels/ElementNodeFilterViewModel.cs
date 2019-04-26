using System;
using System.Collections.Generic;
using System.Linq;
using Catel.Data;
using Catel.MVVM;
using Vixen.Module;
using Vixen.Sys.ElementNodeFilters;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Events;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Services;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public class ElementNodeFilterViewModel : ViewModelBase
	{
		private readonly IStandardTransformService _transformService;
		public ElementNodeFilterViewModel(IChainableElementNodeFilter filter, IStandardTransformService transformService)
		{
			_transformService = transformService;
			Filter = filter;
			filter.PropertyChanged += Filter_PropertyChanged;
		}

		private void Filter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			//I should not have to do this, but for some reason Catel refuses to keep two view modesl in sync with the 
			//same model
			RaisePropertyChanged(e.PropertyName);
		}

		#region Overrides of ViewModelBase

		/// <inheritdoc />
		protected override void UninitializeModel(string modelProperty, object model, ModelCleanUpMode modelCleanUpMode)
		{
			Filter.PropertyChanged -= Filter_PropertyChanged;
			base.UninitializeModel(modelProperty, model, modelCleanUpMode);
			
		}

		#endregion

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
		/// Gets the StandardFilters value.
		/// </summary>
		public List<IModuleDescriptor> StandardFilters => _transformService.StandardDescriptors;

		#endregion

		#region Name property

		///// <summary>
		///// Gets or sets the Name value.
		///// </summary>
		public string Name
		{
			get => Filter.Name;
			set
			{
				if (Filter.Name != value)
				{
					Filter.Name = value;
					//RaisePropertyChanged(nameof(Name)); //Not needed because we are listening to the model
				}
			}
		}

		#endregion

		#region FilterTypeId property

		/// <summary>
		/// Gets or sets the FilterTypeId value.
		/// </summary>
		public Guid FilterTypeId
		{
			get => Filter.FilterTypeId;
			set
			{
				if (Filter.FilterTypeId != value)
				{
					Filter.FilterTypeId = value;
					//RaisePropertyChanged(nameof(FilterTypeId)); //Not needed because we are listening to the model
					FilterChanged();
				}
				
			}
		}

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
			if (ParentViewModel is BaseTransformEditorViewModel pm)
			{
				pm.OnFiltersChanged(new FiltersChangedEvent(FilterChangeType.Update));
			}
		}
	}
}
