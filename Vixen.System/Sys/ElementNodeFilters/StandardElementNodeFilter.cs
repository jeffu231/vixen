using Vixen.Services;

namespace Vixen.Sys.ElementNodeFilters
{
	public class StandardElementNodeFilter:ChainableElementNodeFilterBase
	{
		#region Overrides of ChainableElementNodeFilterBase

		/// <inheritdoc />
		public override IChainableElementNodeFilter Clone()
		{
			var filter = new StandardElementNodeFilter
			{
				Name = Name,
				ElementNodeFilter = ElementNodeFilterService.Instance.GetInstance(ElementNodeFilter.TypeId),
				ChainLevel = ChainLevel
			};

			filter.ElementNodeFilter.ModuleData = ElementNodeFilter.ModuleData.Clone();
			return filter;
		}

		#endregion
	}
}
