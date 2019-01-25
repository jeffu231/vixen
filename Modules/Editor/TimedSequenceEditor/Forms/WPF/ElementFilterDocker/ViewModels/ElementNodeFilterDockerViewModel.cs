using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Catel.Data;
using Catel.MVVM;
using Vixen.Module.ElementNodeFilter;
using Vixen.Services;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public class ElementNodeFilterDockerViewModel : ViewModelBase
	{
		private List<IElementNodeFilterInstance> _standardFilters = new List<IElementNodeFilterInstance>();

		#region Filters model property

		/// <summary>
		/// Gets or sets the Filters value.
		/// </summary>
		[Model]
		public ObservableCollection<IElementNodeFilter> Filters
		{
			get { return GetValue<ObservableCollection<IElementNodeFilter>>(FiltersProperty); }
			private set { SetValue(FiltersProperty, value); }
		}

		/// <summary>
		/// Filters property data.
		/// </summary>
		public static readonly PropertyData FiltersProperty = RegisterProperty("Filters", typeof(ObservableCollection<IElementNodeFilter>));

		#endregion


		private void InitializeStandardFilters()
		{
			var descriptors = ApplicationServices.GetModuleDescriptors<IElementNodeFilterInstance>();
			_standardFilters = descriptors.Select(filterType => ApplicationServices.Get<IElementNodeFilterInstance>(filterType.TypeId)).ToList();
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
			// TODO: Handle command logic here
		}

		/// <summary>
		/// Method to check whether the AddFilter command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanAddFilter()
		{
			return true;
		}

		#endregion

		#region RemoveFilter command

		private Command _removeFilterCommand;

		/// <summary>
		/// Gets the RemoveFilter command.
		/// </summary>
		public Command RemoveFilterCommand
		{
			get { return _removeFilterCommand ?? (_removeFilterCommand = new Command(RemoveFilter, CanRemoveFilter)); }
		}

		/// <summary>
		/// Method to invoke when the RemoveFilter command is executed.
		/// </summary>
		private void RemoveFilter()
		{
			// TODO: Handle command logic here
		}

		/// <summary>
		/// Method to check whether the RemoveFilter command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanRemoveFilter()
		{
			return true;
		}

		#endregion
		
		
		#endregion

	}
}
