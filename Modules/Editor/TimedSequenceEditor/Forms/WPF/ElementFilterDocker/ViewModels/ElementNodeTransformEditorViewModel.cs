using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Catel.Collections;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using Vixen.Module;
using Vixen.Module.ElementNodeFilter;
using Vixen.Services;
using Vixen.Sys.ElementNodeFilters;
using Common.WPFCommon.Utils;
using Vixen.Sys;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Services;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Views;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public class ElementNodeTransformEditorViewModel : BaseTransformEditorViewModel, IDropTarget, IDragSource
	{
		public event EventHandler<EventArgs> FiltersChanged;
		private const string InfoLink = @"http://www.vixenlights.com";
		private const string DefaultMessage = @"Select an Effect to edit";
		private ElementPreviewWindow _previewWindow;
		private EffectNode _effectNode;
		private readonly IStandardTransformService _transformService;

		public ElementNodeTransformEditorViewModel()
		{
			_transformService = this.GetServiceLocator().TryResolveType<IStandardTransformService>();
			Filters = new FastObservableCollection<IChainableElementNodeFilter>();
			SelectedItems = new ObservableCollection<IChainableElementNodeFilter>();
			SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
			InformationLink = InfoLink;
			Information = DefaultMessage;
			IsActive = true;
		}

		private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			var viewModelBase = this as ViewModelBase;
			var commandManager = viewModelBase.GetViewModelCommandManager();
			commandManager.InvalidateCommands();
		}

		#region EffectNode property

		/// <summary>
		/// Gets or sets the TargetNodes value.
		/// </summary>
		public EffectNode EffectNode
		{
			get => _effectNode;
			set
			{
				if (_effectNode != value)
				{
					_effectNode = value;
					if (_previewWindow !=null && _previewWindow.IsVisible)
					{
						_previewWindow.Close();
					}
					
					Filters = _effectNode != null ? new FastObservableCollection<IChainableElementNodeFilter>(_effectNode.Effect.ElementNodeFilters) 
						: new FastObservableCollection<IChainableElementNodeFilter>();
					
				}
				
			}
		}


		#endregion
		
		#region Filters model property

		/// <summary>
		/// Gets or sets the Filters value.
		/// </summary>
		public FastObservableCollection<IChainableElementNodeFilter> Filters
		{
			get { return GetValue<FastObservableCollection<IChainableElementNodeFilter>>(FiltersProperty); }
			set
			{
				var oldValue = GetValue<FastObservableCollection<IChainableElementNodeFilter>>(FiltersProperty);
				if (oldValue != null)
				{
					oldValue.CollectionChanged -= Filters_CollectionChanged;
				}
				SetValue(FiltersProperty, value);
				if (value != null)
				{
					value.CollectionChanged += Filters_CollectionChanged;
				}
				
			}
		}

		/// <summary>
		/// Filters property data.
		/// </summary>
		public static readonly PropertyData FiltersProperty = RegisterProperty("Filters", typeof(FastObservableCollection<IChainableElementNodeFilter>));

		#endregion

		#region StandardFilters property

		#region StandardFilters property

		/// <summary>
		/// Gets the StandardFilters value.
		/// </summary>
		public List<IModuleDescriptor> StandardFilters => _transformService.StandardDescriptors;

		#endregion

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

		#region IsActive property

		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive
		{
			get { return GetValue<bool>(IsActiveProperty); }
			set { SetValue(IsActiveProperty, value); }
		}

		/// <summary>
		/// IsActive property data.
		/// </summary>
		public static readonly PropertyData IsActiveProperty = RegisterProperty("IsActive", typeof(bool));

		#endregion

		#region Information property

		/// <summary>
		/// Gets or sets the Information value.
		/// </summary>
		public string Information
		{
			get { return GetValue<string>(InformationProperty); }
			set { SetValue(InformationProperty, value); }
		}

		/// <summary>
		/// Information property data.
		/// </summary>
		public static readonly PropertyData InformationProperty = RegisterProperty("Information", typeof(string));

		#endregion

		#region InformationLink property

		/// <summary>
		/// Gets or sets the InformationLink value.
		/// </summary>
		public string InformationLink
		{
			get { return GetValue<string>(InformationLinkProperty); }
			set { SetValue(InformationLinkProperty, value); }
		}

		/// <summary>
		/// InformationLink property data.
		/// </summary>
		public static readonly PropertyData InformationLinkProperty = RegisterProperty("InformationLink", typeof(string));

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
		internal void AddFilter()
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

				//OnFiltersChanged(new EventArgs());
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
		internal void RemoveFilter(IChainableElementNodeFilter filter)
		{
			Filters.Remove(filter);
			//OnFiltersChanged(new EventArgs());
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

		#region Preview command

		private Command _previewCommand;

		/// <summary>
		/// Gets the Preview command.
		/// </summary>
		public Command PreviewCommand
		{
			get { return _previewCommand ?? (_previewCommand = new Command(Preview, CanPreview)); }
		}

		/// <summary>
		/// Method to invoke when the Preview command is executed.
		/// </summary>
		private void Preview()
		{
			_previewWindow = new ElementPreviewWindow(this);
			_previewWindow.ShowDialog();
		}

		/// <summary>
		/// Method to check whether the Preview command can be executed.
		/// </summary>
		/// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
		private bool CanPreview()
		{
			return EffectNode!=null;
		}

		#endregion

		#endregion

		#region Events

		internal override void OnFiltersChanged(EventArgs args)
		{
			FiltersChanged?.Invoke(this, args);
		}

		private void Filters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			//ConfigureViewModels();
			OnFiltersChanged(new EventArgs());
		}

		#endregion


		#region Implementation of IDropTarget

		/// <summary>
		/// Determines whether the data of the drag drop action should be copied otherwise moved.
		/// </summary>
		/// <param name="dropInfo">The DropInfo with a valid DragInfo.</param>
		public static bool ShouldCopyData(IDropInfo dropInfo)
		{
			// default should always the move action/effect
			if (dropInfo?.DragInfo == null)
			{
				return false;
			}

			return true;
		}
		public static bool CanAcceptData(IDropInfo dropInfo)
		{
			if (dropInfo?.DragInfo == null)
			{
				return false;
			}

			if (!dropInfo.IsSameDragDropContextAsSource)
			{
				return false;
			}

			var isListBoxItem = dropInfo.InsertPosition.HasFlag(RelativeInsertPosition.TargetItemCenter)
								 && dropInfo.VisualTargetItem is ListBoxItem;
			if (isListBoxItem && dropInfo.VisualTargetItem == dropInfo.DragInfo.VisualSourceItem)
			{
				return false;
			}

			IList<IChainableElementNodeFilter> chainableElementNodeFilters = dropInfo.Data as IList<IChainableElementNodeFilter>;
			var evmTarget = dropInfo.TargetItem as IChainableElementNodeFilter;
			if (evmTarget == null)
			{
				return false;
			}

			if (chainableElementNodeFilters != null)
			{
				if (isListBoxItem && dropInfo.InsertPosition.HasFlag(RelativeInsertPosition.TargetItemCenter))
				{

					return false;
				}
			}

			if (dropInfo.DragInfo.SourceCollection == dropInfo.TargetCollection)
			{
				var targetList = dropInfo.TargetCollection.TryGetList();
				return targetList != null;
			}

			if (dropInfo.TargetCollection == null)
			{
				return false;
			}

			if (TestCompatibleTypes(dropInfo.TargetCollection, dropInfo.Data))
			{
				var isChildOf = dropInfo.VisualTargetItem.IsChildOf(dropInfo.DragInfo.VisualSourceItem);
				return !isChildOf;
			}

			return false;
		}

		/// <inheritdoc />
		public void DragOver(IDropInfo dropInfo)
		{
			if (CanAcceptData(dropInfo))
			{
				dropInfo.Effects = DragDropEffects.Move;

				if (dropInfo.InsertPosition == RelativeInsertPosition.None || dropInfo.InsertPosition == RelativeInsertPosition.TargetItemCenter)
				{
					dropInfo.DropTargetAdorner = null;
					return;
				}

				dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
			}
			else
			{
				dropInfo.DropTargetAdorner = null;
			}
		}

		/// <inheritdoc />
		public void Drop(IDropInfo dropInfo)
		{
			if (dropInfo.Data is IChainableElementNodeFilter model)
			{
				var insertIndex = dropInfo.InsertPosition==RelativeInsertPosition.BeforeTargetItem?dropInfo.InsertIndex:dropInfo.InsertIndex+1;
				var removeIndex = Filters.IndexOf(model);

				if (removeIndex < insertIndex)
				{
					Filters.Insert(insertIndex, model);
					Filters.RemoveAt(removeIndex);
				}
				else
				{
					removeIndex++;
					if (Filters.Count + 1 > removeIndex)
					{
						Filters.Insert(insertIndex, model);
						Filters.RemoveAt(removeIndex);
					}
				}

				OnFiltersChanged(new EventArgs());
			}
		}

		private static bool TestCompatibleTypes(IEnumerable target, object data)
		{
			TypeFilter filter = (t, o) => { return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)); };

			var enumerableInterfaces = target.GetType().FindInterfaces(filter, null);
			var enumerableTypes = from i in enumerableInterfaces
				select i.GetGenericArguments().Single();

			if (enumerableTypes.Any())
			{
				var dataType = TypeUtilities.GetCommonBaseClass(ExtractData(data));
				return enumerableTypes.Any(t => t.IsAssignableFrom(dataType));
			}
			else
			{
				return target is IList;
			}
		}

		public static IEnumerable ExtractData(object data)
		{
			if (data is IEnumerable && !(data is string))
			{
				return (IEnumerable)data;
			}
			else
			{
				return Enumerable.Repeat(data, 1);
			}
		}

		#endregion

		#region Implementation of IDragSource

		/// <inheritdoc />
		public void StartDrag(IDragInfo dragInfo)
		{
			var itemCount = dragInfo.SourceItems.Cast<object>().Count();
			dragInfo.Data = null;

			if (itemCount > 0)
			{
				if (dragInfo.SourceItems.Cast<object>().First() is IChainableElementNodeFilter dragItem)
				{
					dragInfo.Data = dragItem;
				}
			}
			
			dragInfo.Effects = (dragInfo.Data != null) ? DragDropEffects.Move : DragDropEffects.None;
		}

		/// <inheritdoc />
		public bool CanStartDrag(IDragInfo dragInfo)
		{
			return Filters?.Count > 0;
		}

		/// <inheritdoc />
		public void Dropped(IDropInfo dropInfo)
		{
			
		}

		/// <inheritdoc />
		public void DragCancelled()
		{
			
		}

		/// <inheritdoc />
		public bool TryCatchOccurredException(Exception exception)
		{
			return false;
		}

		#endregion
	}
}
