using System.Runtime.Serialization;
using Vixen.Module;

namespace VixenModules.ElementNodeFilter.SkipFilter
{
	public class SkipFilterData: ModuleDataModelBase
	{
		
		public override IModuleDataModel Clone()
		{
			SkipFilterData newInstance = new SkipFilterData { Skip = Skip};
			return newInstance;
		}

		[DataMember] public int Skip { get; set; } = 1;
	}
}
