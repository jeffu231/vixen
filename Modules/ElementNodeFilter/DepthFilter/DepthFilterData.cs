using System.Runtime.Serialization;
using Vixen.Module;

namespace VixenModules.ElementNodeFilter.DepthFilter
{
	public class DepthFilterData: ModuleDataModelBase
	{
		
		public override IModuleDataModel Clone()
		{
			DepthFilterData newInstance = new DepthFilterData { Depth = Depth};
			return newInstance;
		}

		[DataMember] public int Depth { get; set; } = 1;
	}
}
