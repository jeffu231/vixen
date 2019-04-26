using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Catel.Collections;
using Catel.Data;
using Catel.MVVM;
using Vixen.Sys;
using Vixen.Sys.ElementNodeFilters;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Events;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public class ElementPreviewViewModel:BaseTransformEditorViewModel
	{
		public ElementPreviewViewModel(ElementNodeTransformEditorViewModel editorViewModel)
		{
			Title = "Transform Preview";
			SelectedItems = new ObservableCollection<IChainableElementNodeFilter>();
			SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
			TargetNodes = new FastObservableCollection<IElementNode>(editorViewModel.EffectNode.Effect.UnFilteredTargetNodes);
			EditorViewModel = editorViewModel;
			editorViewModel.EffectNode.Effect.PropertyChanged += EffectOnPropertyChanged;
			EditorViewModel.Filters.CollectionChanged += Filters_CollectionChanged;
			UpdateTransformedNodes();
		}

		#region Overrides of BaseTransformEditorViewModel
		
		internal override void OnFiltersChanged(FiltersChangedEvent e)
		{
			EditorViewModel.OnFiltersChanged(e);
		}

		#endregion

		#region Overrides of ViewModelBase

		/// <inheritdoc />
		protected override Task CloseAsync()
		{
			EditorViewModel.EffectNode.Effect.PropertyChanged -= EffectOnPropertyChanged;
			SelectedItems.CollectionChanged -= SelectedItems_CollectionChanged;
			EditorViewModel.Filters.CollectionChanged -= Filters_CollectionChanged;
			return base.CloseAsync();
		}

		#endregion

		
		#region TargetNodes model property

		/// <summary>
		/// Gets or sets the TargetNodes value.
		/// </summary>
		[Model]
		public FastObservableCollection<IElementNode> TargetNodes
		{
			get { return GetValue<FastObservableCollection<IElementNode>>(TargetNodesProperty); }
			private set { SetValue(TargetNodesProperty, value); }
		}

		/// <summary>
		/// TargetNodes property data.
		/// </summary>
		public static readonly PropertyData TargetNodesProperty = RegisterProperty("TargetNodes", typeof(FastObservableCollection<IElementNode>));

		#endregion

		#region TransformedNodes model property

		/// <summary>
		/// Gets or sets the TransformedNodes value.
		/// </summary>
		[Model]
		public FastObservableCollection<IElementNode> TransformedNodes
		{
			get { return GetValue<FastObservableCollection<IElementNode>>(TransformedNodesProperty); }
			private set { SetValue(TransformedNodesProperty, value); }
		}

		/// <summary>
		/// TransformedNodes property data.
		/// </summary>
		public static readonly PropertyData TransformedNodesProperty = RegisterProperty("TransformedNodes", typeof(FastObservableCollection<IElementNode>));

		#endregion
		
		#region Filters property

		/// <summary>
		/// Gets the Filters value.
		/// </summary>
		[Model]
		public FastObservableCollection<IChainableElementNodeFilter> Filters => EditorViewModel.Filters;

		#endregion

		#region EditorViewModel property

		/// <summary>
		/// Gets or sets the EditorViewModel value.
		/// </summary>
		public ElementNodeTransformEditorViewModel EditorViewModel
		{
			get { return GetValue<ElementNodeTransformEditorViewModel>(EditorViewModelProperty); }
			set { SetValue(EditorViewModelProperty, value); }
		}

		/// <summary>
		/// EditorViewModel property data.
		/// </summary>
		public static readonly PropertyData EditorViewModelProperty = RegisterProperty("EditorViewModel", typeof(ElementNodeTransformEditorViewModel));

		#endregion

		#region SelectedItems property

		/// <summary>
		/// Gets or sets the SelectedItems value.
		/// </summary>
		public ObservableCollection<IChainableElementNodeFilter> SelectedItems
		{
			get { return GetValue<ObservableCollection<IChainableElementNodeFilter>>(SelectedItemsProperty); }
			set { SetValue(SelectedItemsProperty, value); }
		}

		/// <summary>
		/// SelectedItems property data.
		/// </summary>
		public static readonly PropertyData SelectedItemsProperty = RegisterProperty("SelectedItems", typeof(ObservableCollection<IChainableElementNodeFilter>));

		#endregion

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
			EditorViewModel.AddFilter();
		}

		/// <summary>
		/// Method to check whether the AddFilter command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanAddFilter()
		{
			return EditorViewModel.StandardFilters.Any();
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
			EditorViewModel.RemoveFilter(filter);
		}

		/// <summary>
		/// Method to check whether the RemoveFilter command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanRemoveFilter(IChainableElementNodeFilter filter)
		{
			return SelectedItems.Any();
		}

		#endregion

		#region ClearTransforms command

		private Command _clearTransformsCommand;

		/// <summary>
		/// Gets the ClearTransforms command.
		/// </summary>
		public Command ClearTransformsCommand
		{
			get { return _clearTransformsCommand ?? (_clearTransformsCommand = new Command(ClearTransforms, CanClearTransforms)); }
		}

		/// <summary>
		/// Method to invoke when the ClearTransforms command is executed.
		/// </summary>
		private void ClearTransforms()
		{
			EditorViewModel.ClearTransforms();
		}

		/// <summary>
		/// Method to check whether the ClearTransforms command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanClearTransforms()
		{
			return Filters.Any();
		}

		#endregion

		#endregion

		#region Events

		private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			UpdateCommandStates();
		}

		private void Filters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			UpdateCommandStates();
		}

		private void EffectOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName.Equals("TargetNodes"))
			{
				UpdateTransformedNodes();
			}
		}

		#endregion



		private void UpdateTransformedNodes()
		{
			TransformedNodes = new FastObservableCollection<IElementNode>(EditorViewModel.EffectNode.Effect.TargetNodes);
		}
	}
}
