using Catel.Windows;
using Vixen.Extensions;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Views
{
	public partial class ElementPreviewWindow:Window
	{
		public ElementPreviewWindow():this(new ElementNodeTransformEditorViewModel())
		{
			
		}

		public ElementPreviewWindow(ElementNodeTransformEditorViewModel editorViewModel)
		{
			InitializeComponent();
			Icon = Common.Resources.Properties.Resources.Icon_Vixen3.ToImageSource();
			ElementPreviewViewModel model = new ElementPreviewViewModel(editorViewModel);
			DataContext = model;
		}

	}
}
