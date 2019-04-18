using System;
using Vixen.Module.ElementNodeFilter;

namespace VixenModules.ElementNodeFilter.GroupFilter
{
	public class GroupFilterModuleDescriptor : ElementNodeFilterModuleDescriptorBase
	{
		private static readonly Guid _typeId = new Guid("{88644BA3-6D8E-4A0C-B52E-3E1CDEED57A4}");

		public override string TypeName => "Group";

		public override Guid TypeId => _typeId;

		public override Type ModuleClass => typeof (GroupFilterModule);

		public override Type ModuleDataClass => typeof(GroupFilterData);

		public override string Author => "Jeff Uchitjil";

		public override string Description => "Transforms target nodes to by taking all the elements and putting them in a single group.";

		public override string Version => "1.0";
	}
}
