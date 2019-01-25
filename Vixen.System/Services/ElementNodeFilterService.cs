using System;
using Vixen.Module.ElementNodeFilter;
using Vixen.Sys;

namespace Vixen.Services
{
	public class ElementNodeFilterService
	{
		private static ElementNodeFilterService _instance;

		private ElementNodeFilterService()
		{
		}

		public static ElementNodeFilterService Instance => _instance ?? (_instance = new ElementNodeFilterService());

		public IElementNodeFilterInstance GetInstance(Guid id)
		{
			ElementNodeFilterModuleManagement moduleManagement =
				Modules.GetManager<IElementNodeFilterInstance, ElementNodeFilterModuleManagement>();
			IElementNodeFilterInstance module = moduleManagement.Get(id);

			return module;
		}
	}
}
