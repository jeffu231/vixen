using System.Runtime.Serialization;
using Vixen.Module;

namespace VixenModules.ElementNodeFilter.SkipFilter
{
	public class SkipFilterData: ModuleDataModelBase
	{
		
		public override IModuleDataModel Clone()
		{
			SkipFilterData newInstance = new SkipFilterData { First = First, Skip = Skip, Take = Take};
			return newInstance;
		}

		[DataMember]
		public int First { get; set; }

		[DataMember]
		public int Skip { get; set; } = 1;

		[DataMember]
		public int Take { get; set; } = 1;
	}
}
