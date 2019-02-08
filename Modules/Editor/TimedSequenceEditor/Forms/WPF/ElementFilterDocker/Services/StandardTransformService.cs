using System.Collections.Generic;
using System.Linq;
using Vixen.Module;
using Vixen.Module.ElementNodeFilter;
using Vixen.Services;

namespace VixenModules.Editor.TimedSequenceEditor.Forms.WPF.ElementFilterDocker.Services
{
	public class StandardTransformService: IStandardTransformService
	{
		private static readonly List<IModuleDescriptor> Descriptors;
		static StandardTransformService()
		{
			var descriptors = ApplicationServices.GetModuleDescriptors<IElementNodeFilterInstance>();
			Descriptors = descriptors.ToList();
		}

		#region Implementation of IStandardTransformService

		/// <inheritdoc />
		public List<IModuleDescriptor> StandardDescriptors => Descriptors;

		#endregion
	}
}
