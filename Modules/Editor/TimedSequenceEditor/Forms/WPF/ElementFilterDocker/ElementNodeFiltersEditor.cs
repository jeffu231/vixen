using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Catel.IoC;
using Vixen.Sys;
using Vixen.Sys.ElementNodeFilters;
using VixenModules.Editor.EffectEditor;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Events;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Services;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Views;
using VixenModules.Editor.TimedSequenceEditor.Undo;
using WeifenLuo.WinFormsUI.Docking;
using Element = Common.Controls.Timeline.Element;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker
{
	public partial class ElementNodeFiltersEditor : DockContent
	{
		private static readonly NLog.Logger Logging = NLog.LogManager.GetCurrentClassLogger();
		private readonly List<Element> _elements = new List<Element>();
		private readonly TimedSequenceEditorForm _sequenceEditorForm;
		private readonly ElementNodeTransformEditorView _elementNodeFiltersEditorView;
		private ElementNodeTransformEditorViewModel _vm;
		
		public ElementNodeFiltersEditor(TimedSequenceEditorForm sequenceEditorForm)
		{
		
			InitializeComponent();
			var serviceLocator = ServiceLocator.Default;
			serviceLocator.RegisterType<IStandardTransformService, StandardTransformService>();
			_sequenceEditorForm = sequenceEditorForm;
			var host = new ElementHost { Dock = DockStyle.Fill };

			Controls.Add(host);

			_elementNodeFiltersEditorView = new ElementNodeTransformEditorView();
					
			host.Child = _elementNodeFiltersEditorView;

			_vm = _elementNodeFiltersEditorView.ViewModel as ElementNodeTransformEditorViewModel;
			_vm.FiltersChanged += _vm_FiltersChanged;
			_vm.IsActive = false;


			sequenceEditorForm.TimelineControl.SelectionChanged += TimelineControl_SelectionChanged;
			
			//_layerEditorView.CollectionChanged += LayerEditorViewCollectionChanged;
			//_layerEditorView.LayerChanged += LayerEditorViewOnLayerChanged;
		}

		internal IEnumerable<Element> Elements
		{
			get => _elements;
			set
			{
				_elements.Clear();
				_elements.AddRange(value);
				if (_elements.Any())
				{
					_vm.EffectNode = _elements.First().EffectNode;
					_vm.IsActive = true;
				}
				else
				{
					_vm.IsActive = false;
					_vm.EffectNode = null;
				}
			}
		}

		private void TimelineControl_SelectionChanged(object sender, EventArgs e)
		{
			Elements = _sequenceEditorForm.TimelineControl.SelectedElements.ToArray();
		}

		private async void _vm_FiltersChanged(object sender, FiltersChangedEvent e)
		{
			Dictionary<Element, Tuple<Object, PropertyDescriptor>> elementValues = new Dictionary<Element, Tuple<object, PropertyDescriptor>>();
			await Task.Factory.StartNew(() =>
			{
				//The undo portion of this needs further work because it will only work with the top level filters.
				//The internal data is modified in place before it gets to us and additional logic is required.
				foreach (var element in Elements)
				{
					var oldValue = CloneChainableElementNodeFilters(element.EffectNode.Effect.ElementNodeFilters);
					if (e.ChangeType != FilterChangeType.Update)
					{
						element.EffectNode.Effect.ElementNodeFilters.Clear();
						element.EffectNode.Effect.ElementNodeFilters.AddRange(_vm.Filters.ToList());
					}
					
					element.EffectNode.Effect.FilterNodes();
					var propertyData = MetadataRepository.GetProperties(element.EffectNode.Effect).FirstOrDefault(x => x.PropertyType == typeof(List<IChainableElementNodeFilter>));
					if (propertyData != null)
					{
						elementValues.Add(element, new Tuple<object, PropertyDescriptor>(oldValue, propertyData.Descriptor));
					}

					element.UpdateNotifyContentChanged();
				}
			});

			if (elementValues.Any())
			{
				var undo = new EffectsPropertyModifiedUndoAction(elementValues);
				_sequenceEditorForm.AddEffectsModifiedToUndo(undo);
			}

		}

		private List<IChainableElementNodeFilter> CloneChainableElementNodeFilters(List<IChainableElementNodeFilter> filters)
		{
			List<IChainableElementNodeFilter> newList = new List<IChainableElementNodeFilter>(filters.Count);
			newList.AddRange(filters.Select(x => x.Clone()));
			return newList;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			if (_elementNodeFiltersEditorView != null)
			{
				//_ElementNodeFiltersEditorView.CollectionChanged -= LayerEditorViewCollectionChanged;
				//_ElementNodeFiltersEditorView.LayerChanged -= LayerEditorViewOnLayerChanged;
			}
			base.Dispose(disposing);
		}
	}
}
