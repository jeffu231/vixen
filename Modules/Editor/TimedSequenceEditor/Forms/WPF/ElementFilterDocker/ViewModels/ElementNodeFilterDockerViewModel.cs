﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Catel.Data;
using Catel.MVVM;
using Vixen.Module;
using Vixen.Module.ElementNodeFilter;
using Vixen.Services;
using Vixen.Sys.ElementNodeFilters;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public class ElementNodeFilterDockerViewModel : ViewModelBase
	{

		public event EventHandler<EventArgs> FiltersChanged;

		public ElementNodeFilterDockerViewModel()
		{
			Filters = new ObservableCollection<IChainableElementNodeFilter>();
			Filters.CollectionChanged += Filters_CollectionChanged;
			InitializeStandardFilters();
		}

		#region Filters model property

		/// <summary>
		/// Gets or sets the Filters value.
		/// </summary>
		[Model]
		public ObservableCollection<IChainableElementNodeFilter> Filters
		{
			get { return GetValue<ObservableCollection<IChainableElementNodeFilter>>(FiltersProperty); }
			set { SetValue(FiltersProperty, value); }
		}

		/// <summary>
		/// Filters property data.
		/// </summary>
		public static readonly PropertyData FiltersProperty = RegisterProperty("Filters", typeof(ObservableCollection<IChainableElementNodeFilter>));

		#endregion

		#region StandardFilters property

		/// <summary>
		/// Gets or sets the StandardFilters value.
		/// </summary>
		public ObservableCollection<IModuleDescriptor> StandardFilters
		{
			get { return GetValue<ObservableCollection<IModuleDescriptor>>(StandardFiltersProperty); }
			set { SetValue(StandardFiltersProperty, value); }
		}

		/// <summary>
		/// StandardFilters property data.
		/// </summary>
		public static readonly PropertyData StandardFiltersProperty = RegisterProperty("StandardFilters", typeof(ObservableCollection<IModuleDescriptor>));

		#endregion

		private void InitializeStandardFilters()
		{
			var descriptors = ApplicationServices.GetModuleDescriptors<IElementNodeFilterInstance>();
			StandardFilters = new ObservableCollection<IModuleDescriptor>(descriptors);
		}


		#region Commands

		#region AddFilter command

		private Command _addFilterCommand;

		/// <summary>
		/// Gets the AddFilter command.
		/// </summary>
		public Command AddFilterCommand
		{
			get { return _addFilterCommand ?? (_addFilterCommand = new Command(AddFilter, CanAddFilter)); }
		}

		/// <summary>
		/// Method to invoke when the AddFilter command is executed.
		/// </summary>
		private void AddFilter()
		{
			var filter = StandardFilters.FirstOrDefault();
			if (filter != null)
			{
				var index = Filters.Count;
				Filters.Add(new StandardElementNodeFilter
				{
					Name = filter.TypeName,
					ElementNodeFilter = ElementNodeFilterService.Instance.GetInstance(filter.TypeId),
					ChainLevel = index
				});

				OnFiltersChanged(new EventArgs());
			}
			
		}

		/// <summary>
		/// Method to check whether the AddFilter command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanAddFilter()
		{
			return StandardFilters.Any();
		}

		#endregion

		#region RemoveFilter command

		private Command<IChainableElementNodeFilter> _removeFilterCommand;

		/// <summary>
		/// Gets the RemoveFilter command.
		/// </summary>
		public Command<IChainableElementNodeFilter> RemoveFilterCommand
		{
			get { return _removeFilterCommand ?? (_removeFilterCommand = new Command<IChainableElementNodeFilter>(RemoveFilter, CanRemoveFilter)); }
		}

		/// <summary>
		/// Method to invoke when the RemoveFilter command is executed.
		/// </summary>
		private void RemoveFilter(IChainableElementNodeFilter filter)
		{
			Filters.Remove(filter);
			OnFiltersChanged(new EventArgs());
		}

		/// <summary>
		/// Method to check whether the RemoveFilter command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanRemoveFilter(IChainableElementNodeFilter filter)
		{
			return true;
		}

		#endregion


		#endregion

		#region Events

		internal void OnFiltersChanged(EventArgs args)
		{
			FiltersChanged?.Invoke(this, args);
		}

		private void Filters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnFiltersChanged(new EventArgs());
		}

		#endregion


	}
}
