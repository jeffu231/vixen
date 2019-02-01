using System;
using Vixen.Module.ElementNodeFilter;

namespace VixenModules.ElementNodeFilter.SkipFilter
{
	public class SkipFilterModuleDescriptor : ElementNodeFilterModuleDescriptorBase
	{
		private static readonly Guid _typeId = new Guid("{99316C12-5992-4029-9D6C-24AA15FDF39E}");

		public override string TypeName => "Skip N";

		public override Guid TypeId => _typeId;

		public override Type ModuleClass => typeof (SkipFilterModule);

		public override Type ModuleDataClass => typeof(SkipFilterData);

		public override string Author => "Jeff Uchitjil";

		public override string Description => "Filters target nodes to skip n elements";

		public override string Version => "1.0";
	}
}
