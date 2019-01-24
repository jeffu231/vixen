using Vixen.Sys;

namespace Vixen.Module.ElementNodeFilter
{
	public interface IElementNodeFilter : IHasSetup
	{
		/// <summary>
		/// Filters the given array of ElementNodes to a new set
		/// </summary>
		/// <param name="nodes"></param>
		/// <returns></returns>
		ElementNode[] Filter(ElementNode[] nodes);

	}
}
