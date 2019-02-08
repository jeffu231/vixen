using Catel.Windows.Controls;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Views
{
	public partial class ElementNodeTransformEditorView: UserControl
	{
		public ElementNodeTransformEditorView():this(new ElementNodeTransformEditorViewModel())
		{
			InitializeComponent();
		}

		public ElementNodeTransformEditorView(ElementNodeTransformEditorViewModel vm) : base(vm)
		{
			InitializeComponent();
		}


	}
}
