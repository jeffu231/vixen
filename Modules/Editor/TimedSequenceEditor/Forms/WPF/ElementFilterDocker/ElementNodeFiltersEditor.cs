using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Common.Controls.Timeline;
using Vixen.Sys.ElementNodeFilters;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Views;
using WeifenLuo.WinFormsUI.Docking;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker
{
	public partial class ElementNodeFiltersEditor : DockContent
	{
		private static readonly NLog.Logger Logging = NLog.LogManager.GetCurrentClassLogger();
		private readonly List<Element> _elements = new List<Element>();
		private readonly TimedSequenceEditorForm _sequenceEditorForm;
		private readonly ElementNodeFilterDockerView _ElementNodeFiltersEditorView;
		private ElementNodeFilterDockerViewModel _vm;
		
		public ElementNodeFiltersEditor(TimedSequenceEditorForm sequenceEditorForm)
		{
		
			InitializeComponent();
			_sequenceEditorForm = sequenceEditorForm;
			var host = new ElementHost { Dock = DockStyle.Fill };

			Controls.Add(host);

			_vm = new ElementNodeFilterDockerViewModel();
			_vm.FiltersChanged += _vm_FiltersChanged;
			_ElementNodeFiltersEditorView = new ElementNodeFilterDockerView(_vm);

			host.Child = _ElementNodeFiltersEditorView;

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
					_vm.Filters = new ObservableCollection<IChainableElementNodeFilter>(_elements.First().EffectNode.Effect.ElementNodeFilters);
				}
				else
				{
					_vm.Filters = new ObservableCollection<IChainableElementNodeFilter>();
				}
				//_effectPropertyEditorGridEffectEffectPropertiesEditor.SelectedObjects = _elements.Select(x => x.EffectNode.Effect).ToArray();
			}
		}

		private void TimelineControl_SelectionChanged(object sender, EventArgs e)
		{
			Elements = _sequenceEditorForm.TimelineControl.SelectedElements.ToArray();
		}

		private void _vm_FiltersChanged(object sender, EventArgs e)
		{
			foreach (var element in Elements)
			{
				element.EffectNode.Effect.ElementNodeFilters = _vm.Filters.ToList();
				element.EffectNode.Effect.FilterNodes();
				element.UpdateNotifyContentChanged();
			}
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
			if (_ElementNodeFiltersEditorView != null)
			{
				//_ElementNodeFiltersEditorView.CollectionChanged -= LayerEditorViewCollectionChanged;
				//_ElementNodeFiltersEditorView.LayerChanged -= LayerEditorViewOnLayerChanged;
			}
			base.Dispose(disposing);
		}
	}
}
