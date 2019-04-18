using Vixen.Module;
using Vixen.Module.ElementNodeFilter;
using Vixen.Sys;

namespace VixenModules.ElementNodeFilter.GroupFilter
{
	public class GroupFilterModule : ElementNodeFilterModuleInstanceBase
	{
		private GroupFilterData _data;

		#region Overrides of ElementNodeFilterModuleInstanceBase

		/// <inheritdoc />
		public override IElementNode[] Filter(IElementNode[] nodes)
		{
			return GetNodesToRenderOn(nodes);
		}

		private IElementNode[] GetNodesToRenderOn(IElementNode[] nodes)
		{
			GroupingElementNode groupNode = new GroupingElementNode("Group");
			foreach (var elementNode in nodes)
			{
				groupNode.AddChild(elementNode);
			}

			return new IElementNode[]{groupNode};
		}

		public override IModuleDataModel ModuleData
		{
			get => _data;
			set => _data = (GroupFilterData)value;
		}

		/// <inheritdoc />
		public override bool HasSetup => false;

		

		#endregion
	}	
}