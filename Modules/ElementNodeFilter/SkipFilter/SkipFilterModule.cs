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

		public int First
		{
			get => _data.First;
			set => _data.First = value;
		}

		public int Skip
		{
			get => _data.Skip;
			set => _data.Skip = value;
		}

		public int Take
		{
			get => _data.Take;
			set => _data.Take = value;
		}

		#region Overrides of ElementNodeFilterModuleInstanceBase

		/// <inheritdoc />
		public override IElementNode[] Filter(IElementNode[] nodes)
		{
			return GetNodesToRenderOn(nodes);
		}

		private IElementNode[] GetNodesToRenderOn(IElementNode[] nodes)
		{
			List<IElementNode> renderNodes = new List<IElementNode>();

			if (First > 0)
			{
				if (First > nodes.Length)
				{
					First = nodes.Length;
				}
				renderNodes.AddRange(nodes.Take(First));
			}

			if (Skip > 0)
			{
				for (int i = First+Skip; i < nodes.Length; i += 1 + Skip)
				{
					int x = 0;
					for (; x < Take; x++)
					{
						if (i + x < nodes.Length)
						{
							renderNodes.Add(nodes[i+x]);
						}
						else
						{
							break;
						}
					}

					i += x - 1;
				}
			}
			else if(Take > 0)
			{
				renderNodes.AddRange(nodes.Skip(First).Take(Take));
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
			using (SkipFilterSetup setup = new SkipFilterSetup(_data.First, _data.Skip, _data.Take))
			{
				if (setup.ShowDialog() == DialogResult.OK)
				{
					_data.First = setup.First;
					_data.Skip = setup.Skip;
					_data.Take = setup.Take;
					return true;
				}
			}
			return false;
		}

		#endregion
	}	
}