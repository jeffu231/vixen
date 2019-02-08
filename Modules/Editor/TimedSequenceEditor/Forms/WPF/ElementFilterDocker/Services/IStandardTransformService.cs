using System.Collections.Generic;
using Vixen.Module;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Services
{
	public interface IStandardTransformService
	{
		List<IModuleDescriptor> StandardDescriptors { get; }
	}
}
