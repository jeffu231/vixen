using System.Collections.Generic;
using System.Windows.Forms;
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
			if (SingleGroup)
			{
				return new IElementNode[] { GroupAll(nodes) };
			}

			var groupNum = 0;
			GroupingElementNode groupNode = new GroupingElementNode($"Group {++groupNum}"); 
			List<IElementNode> resultNodes = new List<IElementNode>();
			for (int i = 1; i <= nodes.Length; i++)
			{
				groupNode.AddChild(nodes[i-1]);

				if ( i % ElementsPerGroup == 0)
				{
					resultNodes.Add(groupNode);
					if (i <= nodes.Length)
					{
						groupNode = new GroupingElementNode($"Group {++groupNum}");
					}
				}
			}
			return resultNodes.ToArray();
		}

		private static GroupingElementNode GroupAll(IElementNode[] nodes)
		{
			GroupingElementNode groupNode = new GroupingElementNode("Group");
			foreach (var elementNode in nodes)
			{
				groupNode.AddChild(elementNode);
			}

			return groupNode;
		}

		public int ElementsPerGroup
		{
			get => _data.ElementsPerGroup;
			set => _data.ElementsPerGroup = value;
		}

		public bool SingleGroup
		{
			get => _data.SingleGroup;
			set => _data.SingleGroup = value;
		}

		public override IModuleDataModel ModuleData
		{
			get => _data;
			set => _data = (GroupFilterData)value;
		}

		/// <inheritdoc />
		public override bool HasSetup => true;


		/// <inheritdoc />
		public override bool Setup()
		{
			using (GroupFilterSetup setup = new GroupFilterSetup(_data.SingleGroup, _data.ElementsPerGroup))
			{
				if (setup.ShowDialog() == DialogResult.OK)
				{
					_data.SingleGroup = setup.SingleGroup;
					_data.ElementsPerGroup = setup.ElementsPerGroup;
					return true;
				}
			}
			return false;
		}



		#endregion
	}
}