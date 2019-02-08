using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Catel.Collections;
using Catel.Data;
using Catel.MVVM;
using Vixen.Sys;
using Vixen.Sys.ElementNodeFilters;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public class ElementPreviewViewModel:BaseTransformEditorViewModel
	{
		public ElementPreviewViewModel(ElementNodeTransformEditorViewModel editorViewModel)
		{
			Title = "Transform Preview";
			SelectedItems = new ObservableCollection<IChainableElementNodeFilter>();
			SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
			TargetNodes = new FastObservableCollection<ElementNode>(editorViewModel.EffectNode.Effect.UnFilteredTargetNodes);
			EditorViewModel = editorViewModel;
			Filters = editorViewModel.Filters;
			TransformedNodes = new FastObservableCollection<ElementNode>();
			editorViewModel.FiltersChanged += EditorViewModel_FiltersChanged;
			UpdateTransformedNodesAsync();
		}

		protected override void UninitializeModel(string modelProperty, object model, ModelCleanUpMode modelCleanUpMode)
		{
			EditorViewModel.FiltersChanged -= EditorViewModel_FiltersChanged;
			SelectedItems.CollectionChanged -= SelectedItems_CollectionChanged;
			base.UninitializeModel(modelProperty, model, modelCleanUpMode);
		}

		#region TargetNodes model property

		/// <summary>
		/// Gets or sets the TargetNodes value.
		/// </summary>
		[Model]
		public FastObservableCollection<ElementNode> TargetNodes
		{
			get { return GetValue<FastObservableCollection<ElementNode>>(TargetNodesProperty); }
			private set { SetValue(TargetNodesProperty, value); }
		}

		/// <summary>
		/// TargetNodes property data.
		/// </summary>
		public static readonly PropertyData TargetNodesProperty = RegisterProperty("TargetNodes", typeof(FastObservableCollection<ElementNode>));

		#endregion

		#region TransformedNodes model property

		/// <summary>
		/// Gets or sets the TransformedNodes value.
		/// </summary>
		[Model]
		public FastObservableCollection<ElementNode> TransformedNodes
		{
			get { return GetValue<FastObservableCollection<ElementNode>>(TransformedNodesProperty); }
			private set { SetValue(TransformedNodesProperty, value); }
		}

		/// <summary>
		/// TransformedNodes property data.
		/// </summary>
		public static readonly PropertyData TransformedNodesProperty = RegisterProperty("TransformedNodes", typeof(FastObservableCollection<ElementNode>));

		#endregion

		
		#region Filters property

		/// <summary>
		/// Gets or sets the Filters value.
		/// </summary>
		[Model]
		public FastObservableCollection<IChainableElementNodeFilter> Filters
		{
			get { return GetValue<FastObservableCollection<IChainableElementNodeFilter>>(FiltersProperty); }
			set { SetValue(FiltersProperty, value); }
		}

		/// <summary>
		/// Filters property data.
		/// </summary>
		public static readonly PropertyData FiltersProperty = RegisterProperty("Filters", typeof(FastObservableCollection<IChainableElementNodeFilter>));

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

		#region Events

		private async void EditorViewModel_FiltersChanged(object sender, EventArgs e)
		{
			await UpdateTransformedNodesAsync();
		}

		private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			var viewModelBase = this as ViewModelBase;
			var commandManager = viewModelBase.GetViewModelCommandManager();
			commandManager.InvalidateCommands();
		}

		internal override void OnFiltersChanged(EventArgs args)
		{
			EditorViewModel.OnFiltersChanged(args);
		}

		#endregion

		#endregion

		private async Task UpdateTransformedNodesAsync()
		{
			await Task.Factory.StartNew(() =>
			{
				var nodes = TargetNodes.ToArray();
				foreach (var transformer in Filters)
				{
					nodes = transformer.ElementNodeFilter.Filter(nodes);
				}

				TransformedNodes.Clear();
				TransformedNodes.AddItems(nodes);
				Console.Out.WriteLine("Transform Done!");
			});
		}
	}
}
