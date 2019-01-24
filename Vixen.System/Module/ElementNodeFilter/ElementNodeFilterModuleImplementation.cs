using Vixen.Sys.Attribute;

namespace Vixen.Module.ElementNodeFilter
{
	[TypeOfModule("ElementNodeFilter")]
	internal class ElementNodeFilterModuleImplementation: ModuleImplementation<IElementNodeFilterInstance>
	{
		public ElementNodeFilterModuleImplementation() 
			: base(new ElementNodeFilterModuleManagement(), new ElementNodeFilterModuleRepository())
		{
		}
	}
}
