using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Common.Controls.Timeline;
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
		private readonly ElementNodeFilterDockerViewModel _vm;
		
		public ElementNodeFiltersEditor(TimedSequenceEditorForm sequenceEditorForm)
		{
		
			InitializeComponent();
			
			var host = new ElementHost { Dock = DockStyle.Fill };

			Controls.Add(host);

			_vm = new ElementNodeFilterDockerViewModel();
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
				//_effectPropertyEditorGridEffectEffectPropertiesEditor.SelectedObjects = _elements.Select(x => x.EffectNode.Effect).ToArray();
			}
		}

		private void TimelineControl_SelectionChanged(object sender, EventArgs e)
		{
			Elements = _sequenceEditorForm.TimelineControl.SelectedElements.ToArray();
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
