﻿using System.Runtime.Serialization;
using Vixen.Module;

namespace VixenModules.ElementNodeFilter.GroupFilter
{
	public class GroupFilterData: ModuleDataModelBase
	{
		
		public override IModuleDataModel Clone()
		{
			GroupFilterData newInstance = new GroupFilterData();
			return newInstance;
		}

		
	}
}
