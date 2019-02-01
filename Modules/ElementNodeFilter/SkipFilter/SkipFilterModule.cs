using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vixen.Module;
using Vixen.Module.ElementNodeFilter;
using Vixen.Sys;

namespace VixenModules.ElementNodeFilter.SkipFilter
{
	public class SkipFilterModule : ElementNodeFilterModuleInstanceBase
	{
		private SkipFilterData _data;

		public int Skip
		{
			get { return _data.Skip; }
			set { _data.Skip = value; }
		}

		#region Overrides of ElementNodeFilterModuleInstanceBase

		/// <inheritdoc />
		public override ElementNode[] Filter(ElementNode[] nodes)
		{
			return GetNodesToRenderOn(nodes);
		}

		private ElementNode[] GetNodesToRenderOn(ElementNode[] nodes)
		{
			if (Skip == 0)
			{
				return nodes;
			}
			
			List<ElementNode> renderNodes = new List<ElementNode>();
			for (int i = 0; i < nodes.Length; i+=1+Skip)
			{
				renderNodes.Add(nodes[i]);
			}
			
			return renderNodes.ToArray();
		}

		public override IModuleDataModel ModuleData
		{
			get => _data;
			set => _data = (SkipFilterData)value;
		}

		/// <inheritdoc />
		public override bool HasSetup => true;

		/// <inheritdoc />
		public override bool Setup()
		{
			using (SkipFilterSetup setup = new SkipFilterSetup(_data.Skip))
			{
				if (setup.ShowDialog() == DialogResult.OK)
				{
					_data.Skip = setup.Skip;
					return true;
				}
			}
			return false;
		}

		#endregion
	}	
}