using System.Runtime.Serialization;
using Vixen.Module;

namespace VixenModules.ElementNodeFilter.GroupFilter
{
	[DataContract]
	public class GroupFilterData: ModuleDataModelBase
	{
		
		public override IModuleDataModel Clone()
		{
			GroupFilterData newInstance = new GroupFilterData{SingleGroup = SingleGroup, ElementsPerGroup = ElementsPerGroup};
			return newInstance;
		}

		[DataMember]
		public bool SingleGroup { get; set; } = true;

		[DataMember]
		public int ElementsPerGroup { get; set; } = 1;
	}
}
