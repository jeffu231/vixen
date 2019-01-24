using System;
using Vixen.Module.ElementNodeFilter;
using VixenModules.ElementNodeFilter.DepthFilter;

namespace VixenModules.LayerMixingFilter.HighestValueWins
{
	public class DepthFilterModuleDescriptor : ElementNodeFilterModuleDescriptorBase
	{
		private static readonly Guid _typeId = new Guid("{C6D2ADFC-2C29-4C25-B1E1-5FA9BF0863C1}");

		public override string TypeName => "Element Depth";

		public override Guid TypeId => _typeId;

		public override Type ModuleClass => typeof (DepthFilterModule);

		public override Type ModuleDataClass => typeof(DepthFilterData);

		public override string Author => "Jeff Uchitjil";

		public override string Description => "Filters target nodes to a depth";

		public override string Version => "1.0";
	}
}
