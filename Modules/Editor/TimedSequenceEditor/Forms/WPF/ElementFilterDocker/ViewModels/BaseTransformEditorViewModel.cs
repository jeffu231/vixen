using System;
using Catel.MVVM;
using VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Events;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.ViewModels
{
	public abstract class BaseTransformEditorViewModel: ViewModelBase
	{
		internal virtual void OnFiltersChanged(FiltersChangedEvent e)
		{

		}
		protected void UpdateCommandStates()
		{
			var viewModelBase = this as ViewModelBase;
			var commandManager = viewModelBase.GetViewModelCommandManager();
			commandManager.InvalidateCommands();
		}
	}
}
