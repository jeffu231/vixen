using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vixen.Module;
using Vixen.Module.ElementNodeFilter;
using Vixen.Sys;

namespace VixenModules.ElementNodeFilter.DepthFilter
{
	public class DepthFilterModule : ElementNodeFilterModuleInstanceBase
	{
		private DepthFilterData _data;

		public int Depth { get; set; }

		#region Overrides of ElementNodeFilterModuleInstanceBase

		/// <inheritdoc />
		public override ElementNode[] Filter(ElementNode[] nodes)
		{
			return GetNodesToRenderOn(nodes);
		}

		private ElementNode[] GetNodesToRenderOn(ElementNode[] nodes)
		{
			if (Depth == 0)
			{
				return nodes;
			}
			
			IEnumerable<ElementNode> renderNodes = nodes;
			for (int i = 0; i < Depth; i++)
			{
				renderNodes = renderNodes.SelectMany(x => x.Children);
			}
			
			// If the given Depth results in no nodes (because it goes "too deep" and misses all nodes), 
			// then we'll default to the LeafElements, which will at least return 1 element (the TargetNode)
			if (!renderNodes.Any())
			{
				renderNodes = nodes.SelectMany(x => x.GetLeafEnumerator());
			}

			return renderNodes.ToArray();
		}

		public override IModuleDataModel ModuleData
		{
			get => _data;
			set => _data = (DepthFilterData)value;
		}

		/// <inheritdoc />
		public override bool HasSetup => true;

		/// <inheritdoc />
		public override bool Setup()
		{
			using (DepthFilterSetup setup = new DepthFilterSetup(_data.Depth))
			{
				if (setup.ShowDialog() == DialogResult.OK)
				{
					_data.Depth = setup.Depth;
					return true;
				}
			}
			return false;
		}

		#endregion
	}	
}